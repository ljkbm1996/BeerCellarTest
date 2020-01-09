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

    public class BeerGateway : IBeerGateway
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration config;

        public BeerGateway(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            this.httpClientFactory = httpClientFactory;
            this.config = config;
        }

        public async Task<Beer> GetBeers()
        {
            var client = this.httpClientFactory.CreateClient("breweryDB");
            var httpResponse = await client.GetAsync($"/v2/beers/?key={config["BreweryDbKey"]}");
            var result = JsonConvert.DeserializeObject<Beer>(await httpResponse.Content.ReadAsStringAsync());

            return result;
        }

        public async Task<Beer> GetBeersByPageAsync(int pageNumber)
        {
            var client = this.httpClientFactory.CreateClient("breweryDB");
            var httpResponse = await client.GetAsync($"/v2/beers/?key={config["BreweryDbKey"]}&p={pageNumber}");
            var result = JsonConvert.DeserializeObject<Beer>(await httpResponse.Content.ReadAsStringAsync());

            return result;
        }
    }
}
