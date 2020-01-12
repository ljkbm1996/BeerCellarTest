using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Service.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerGateway beerGateway;
        private readonly IBeerLabelsGateway beerLabelsGateway;
        private readonly IBeerStylesGateway beerStylesGateway;

        public BeerService(IBeerGateway beerGateway, IBeerLabelsGateway beerLabelsGateway, IBeerStylesGateway beerStylesGateway)
        {
            this.beerGateway = beerGateway;
            this.beerLabelsGateway = beerLabelsGateway;
            this.beerStylesGateway = beerStylesGateway;
        }

        public async Task<Beer> GetBeersAsync()
        {
            var result = await this.beerGateway.GetBeersAsync();

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

        public async Task InsertBeerAsync(Beer beer)
        {
            foreach (var data in beer.BeerData)
            {
                var id = new Random();
                var labels = await this.beerLabelsGateway.InsertBeerLabelsAsync(data.Labels);
                var styles = await this.beerStylesGateway.InsertBeerStylesAsync(data.Style);

                data.Id = id.Next(0, 99999).ToString();
                data.Labels = labels;
                data.Style = styles;

                await this.beerGateway.InsertBeerAsync(data, beer.CurrentPage);
            }
        }
    }
}
