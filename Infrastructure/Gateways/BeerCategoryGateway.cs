namespace Infrastructure.Gateways
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
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
            var client = this.httpClientFactory.CreateClient("breweryDB");
            var httpResponse = await client.GetAsync($"/v2/categories/?key={config["BreweryDbKey"]}");
            var data = JObject.Parse(await httpResponse.Content.ReadAsStringAsync());
            var result = JsonConvert.DeserializeObject<ICollection<BeerCategory>>(data["data"].ToString());

            return result;
        }
    }
}
