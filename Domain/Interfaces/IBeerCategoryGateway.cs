namespace Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IBeerCategoryGateway
    {
        Task<ICollection<BeerCategory>> GetBeerCategoryAsync();

        Task<ICollection<BeerCategory>> InsertBeerCategoryAsync(BeerCategory category);
    }
}
