namespace Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IBeerCategoryService
    {
        Task<ICollection<BeerCategory>> GetBeerCategoryAsync();
    }
}
