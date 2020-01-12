namespace Core.Interfaces
{
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IBeerStylesService
    {
        Task<BeerStyle> InsertBeerStylesAsync(BeerStyle styles);
    }
}
