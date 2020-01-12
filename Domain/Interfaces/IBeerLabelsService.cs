namespace Core.Interfaces
{
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IBeerLabelsService
    {
        Task<BeerLabels> InsertBeerLabelsAsync(BeerLabels labels);
    }
}
