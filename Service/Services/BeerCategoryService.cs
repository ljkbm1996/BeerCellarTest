namespace Service.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Interfaces;
    using Domain.Models;

    public class BeerCategoryService : IBeerCategoryService
    {
        private readonly IBeerCategoryGateway beerCategoryGateway;

        public BeerCategoryService(IBeerCategoryGateway beerCategoryGateway)
        {
            this.beerCategoryGateway = beerCategoryGateway;
        }

        public async Task<ICollection<BeerCategory>> GetBeerCategoryAsync()
        {
            return await this.beerCategoryGateway.GetBeerCategoryAsync();
        }

        public async Task<ICollection<BeerCategory>> InsertBeerCategoryAsync(BeerCategory category)
        {
            return await this.beerCategoryGateway.InsertBeerCategoryAsync(category);
        }
    }
}
