using System.Threading.Tasks;
using Core.Interfaces;
using Domain.Models;

namespace Service.Services
{
    public class BeerLabelsService : IBeerLabelsService
    {
        private readonly IBeerLabelsGateway beerLabelsGateway;

        public BeerLabelsService(IBeerLabelsGateway beerLabelsGateway)
        {
            this.beerLabelsGateway = beerLabelsGateway;
        }

        public async Task<BeerLabels> InsertBeerLabelsAsync(BeerLabels labels)
        {
            return await this.beerLabelsGateway.InsertBeerLabelsAsync(labels);
        }
    }
}
