namespace Infrastructure.Gateways
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Core.Interfaces;
    using Dapper;
    using Domain.Models;
    using Microsoft.Extensions.Configuration;

    public class BeerLabelsGateway : IBeerLabelsGateway
    {
        private readonly IConfiguration config;

        public BeerLabelsGateway(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<BeerLabels> InsertBeerLabelsAsync(BeerLabels labels)
        {
            using (var connection = new SqlConnection(this.config["DBConnectionString"]))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var result = await connection.QuerySingleAsync<BeerLabels>("InsertBeerLabels", this.GetParameters(labels), commandType: CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();

                        return (BeerLabels)result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private DynamicParameters GetParameters(BeerLabels labels)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Icon", labels.Icon);
            queryParameters.Add("@Medium", labels.Medium);
            queryParameters.Add("@Large", labels.Large);
            queryParameters.Add("@ContentAwareIcon", labels.ContentAwareIcon);
            queryParameters.Add("@ContentAwareMedium", labels.ContentAwareMedium);
            queryParameters.Add("@ContentAwareLarge", labels.ContentAwareLarge);

            return queryParameters;
        }
    }
}
