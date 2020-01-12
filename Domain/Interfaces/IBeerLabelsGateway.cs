namespace Core.Interfaces
{
    using System.Threading.Tasks;
    using Domain.Models;

    public interface IBeerLabelsGateway
    {
        Task<BeerLabels> InsertBeerLabelsAsync(BeerLabels labels);
    }
}
