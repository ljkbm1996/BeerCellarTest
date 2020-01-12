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

    public class BeerCategoryGateway : IBeerCategoryGateway
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration config;

        public BeerCategoryGateway(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            this.httpClientFactory = httpClientFactory;
            this.config = config;
        }

        public async Task<ICollection<BeerCategory>> GetBeerCategoryAsync()
        {
            using (var connection = new SqlConnection(this.config["DBConnectionString"]))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var query = "SELECT * FROM [dbo].[BeerCategories]";
                        var result = await connection.QueryAsync<BeerCategory>(query, transaction: transaction);

                        if (result.AsList<BeerCategory>().Count > 0)
                        {
                            return result.ToList();
                        }
                        else
                        {
                            result = new List<BeerCategory>();
                            var client = this.httpClientFactory.CreateClient("breweryDB");
                            var httpResponse = await client.GetAsync($"/v2/categories/?key={config["BreweryDbKey"]}");
                            var data = JObject.Parse(await httpResponse.Content.ReadAsStringAsync());
                            var jsonResult = JsonConvert.DeserializeObject<ICollection<BeerCategory>>(data["data"].ToString());
                            
                            
                            foreach(var beer in jsonResult)
                            {
                                result.ToList().AddRange(await this.InsertBeerCategoryAsync(beer));
                            }

                            return result.ToList();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<ICollection<BeerCategory>> InsertBeerCategoryAsync(BeerCategory category)
        {
            using (var connection = new SqlConnection(this.config["DBConnectionString"]))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var result = await connection.QueryAsync<BeerCategory>("InsertBeerCategories", this.GetParameters(category), commandType: CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();

                        return (ICollection<BeerCategory>)result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private DynamicParameters GetParameters(BeerCategory category)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Name", category.Name);

            return queryParameters;
        }
    }
}
