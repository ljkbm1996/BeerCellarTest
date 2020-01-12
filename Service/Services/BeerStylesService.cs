using System.Threading.Tasks;
using Core.Interfaces;
using Domain.Models;

namespace Service.Services
{
    public class BeerStylesService : IBeerStylesService
    {
        private readonly IBeerStylesGateway beerStylesGateway;

        public BeerStylesService(IBeerStylesGateway beerStylesGateway)
        {
            this.beerStylesGateway = beerStylesGateway;
        }

        public async Task<BeerStyle> InsertBeerStylesAsync(BeerStyle styles)
        {
            return await this.beerStylesGateway.InsertBeerStylesAsync(styles);
        }
    }
}
