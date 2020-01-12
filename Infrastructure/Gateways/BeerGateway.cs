namespace Infrastructure.Gateways
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Dapper;
    using Domain.Interfaces;
    using Domain.Models;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class BeerGateway : IBeerGateway
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration config;

        public BeerGateway(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            this.httpClientFactory = httpClientFactory;
            this.config = config;
        }

        public async Task<Beer> GetBeersAsync()
        {
            using (var connection = new SqlConnection(this.config["DBConnectionString"]))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var client = this.httpClientFactory.CreateClient("breweryDB");
                        var httpResponse = await client.GetAsync($"/v2/beers/?key={config["BreweryDbKey"]}");
                        var result = JsonConvert.DeserializeObject<Beer>(await httpResponse.Content.ReadAsStringAsync());

                        var query = $"SELECT * FROM [dbo].[BeerData] WHERE Page = {result.CurrentPage}";
                        var beerData = await connection.QueryAsync<BeerData>(query, transaction: transaction);

                        if (beerData.AsList<BeerData>().Count > 0)
                        {
                            query = "SELECT COUNT(*) FROM [dbo].[BeerData]";
                            var totalResults = await connection.QuerySingleAsync<int>(query, transaction: transaction);
                            result.BeerData.ToList().AddRange(beerData.ToList());
                            result.TotalResults += totalResults;
                        }

                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<Beer> GetBeersByPageAsync(int pageNumber)
        {
            using (var connection = new SqlConnection(this.config["DBConnectionString"]))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var client = this.httpClientFactory.CreateClient("breweryDB");
                        var httpResponse = await client.GetAsync($"/v2/beers/?key={config["BreweryDbKey"]}&p={pageNumber}");
                        var result = JsonConvert.DeserializeObject<Beer>(await httpResponse.Content.ReadAsStringAsync());

                        var query = $"SELECT * FROM [dbo].[BeerData] WHERE Page = {result.CurrentPage}";
                        var beerData = await connection.QueryAsync<BeerData>(query, transaction: transaction);

                        if (beerData.AsList<BeerData>().Count > 0)
                        {
                            query = "SELECT COUNT(*) FROM [dbo].[BeerData]";
                            var totalResults = await connection.QuerySingleAsync<int>(query, transaction: transaction);
                            result.BeerData.ToList().AddRange(beerData.ToList());
                            result.TotalResults += totalResults;
                        }

                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task InsertBeerAsync(BeerData data, int page)
        {
            using (var connection = new SqlConnection(this.config["DBConnectionString"]))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var result = await connection.QueryAsync<BeerCategory>("InsertBeerData", this.GetParameters(data, page), commandType: CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private DynamicParameters GetParameters(BeerData data, int page)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", data.Id);
            queryParameters.Add("@Name", data.Name);
            queryParameters.Add("@NameDisplay", data.NameDisplay);
            queryParameters.Add("@Abv", data.Abv);
            queryParameters.Add("@CreateDate", DateTime.Now);
            queryParameters.Add("@UpdateDate", DateTime.Now);
            queryParameters.Add("@IsOrganic", data.IsOrganic);
            queryParameters.Add("@IsRetired", data.IsRetired);
            queryParameters.Add("@BeerLabelsId", data.Labels.Id);
            queryParameters.Add("@BeerStylesId", data.Style.Id);
            queryParameters.Add("@Page", page);

            return queryParameters;
        }
    }
}
