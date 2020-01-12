namespace Infrastructure.Gateways
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Core.Interfaces;
    using Dapper;
    using Domain.Models;
    using Microsoft.Extensions.Configuration;

    public class BeerStylesGateway : IBeerStylesGateway
    {
        private readonly IConfiguration config;

        public BeerStylesGateway(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<BeerStyle> InsertBeerStylesAsync(BeerStyle styles)
        {
            using (var connection = new SqlConnection(this.config["DBConnectionString"]))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var result = await connection.QuerySingleAsync<BeerStyle>("InsertBeerStyles", this.GetParameters(styles), commandType: CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();

                        return (BeerStyle)result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private DynamicParameters GetParameters(BeerStyle styles)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", styles.Id);
            queryParameters.Add("@CategoryId", styles.CategoryId);
            queryParameters.Add("@Name", styles.Name);
            queryParameters.Add("@ShortName", styles.ShortName);
            queryParameters.Add("@Description", styles.Description);

            return queryParameters;
        }
    }
}
