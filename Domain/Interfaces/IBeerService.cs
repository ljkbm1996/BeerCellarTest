namespace Domain.Interfaces
{
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IBeerService
    {
        Task<Beer> GetBeers();

        Task<Beer> GetBeersByPageAsync(string page);
    }
}
