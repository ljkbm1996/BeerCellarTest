namespace Domain.Interfaces
{
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IBeerGateway
    {
        Task<Beer> GetBeers();

        Task<Beer> GetBeersByPageAsync(int pageNumber);
    }
}
