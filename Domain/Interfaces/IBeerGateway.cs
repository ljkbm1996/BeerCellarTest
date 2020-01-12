namespace Domain.Interfaces
{
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IBeerGateway
    {
        Task<Beer> GetBeersAsync();

        Task<Beer> GetBeersByPageAsync(int pageNumber);

        Task InsertBeerAsync(BeerData data, int page);
    }
}
