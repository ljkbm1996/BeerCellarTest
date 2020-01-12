namespace Core.Interfaces
{
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IBeerStylesGateway
    {
        Task<BeerStyle> InsertBeerStylesAsync(BeerStyle styles);
    }
}
