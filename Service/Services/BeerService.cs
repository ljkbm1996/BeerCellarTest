using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Service.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerGateway beerGateway;

        public BeerService(IBeerGateway beerGateway)
        {
            this.beerGateway = beerGateway;
        }

        public async Task<Beer> GetBeers()
        {
            var result = await this.beerGateway.GetBeers();

            foreach(var beer in result.BeerData)
            {
                if(beer.Abv == null)
                {
                    beer.Abv = Convert.ToString(0);
                }
            }

            return result;
        }

        public async Task<Beer> GetBeersByPageAsync(string page)
        {
            var pageNumber = Convert.ToInt32(page);
            var result = await this.beerGateway.GetBeersByPageAsync(pageNumber);

            foreach (var beer in result.BeerData)
            {
                if (beer.Abv == null)
                {
                    beer.Abv = Convert.ToString(0);
                }
            }

            return result;
        }
    }
}
