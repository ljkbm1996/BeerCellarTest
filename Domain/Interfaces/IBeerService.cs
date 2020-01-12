namespace Domain.Interfaces
{
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IBeerService
    {
        Task<Beer> GetBeersAsync();

        Task<Beer> GetBeersByPageAsync(string page);

        Task InsertBeerAsync(Beer beer);
    }
}
