using MilesCarRental_Entities;

namespace MilesCarRental_Services.Interfaces
{
    public interface ILocationService
    {
        Task<IList<Location>> GetAllLocationAsync();
        Task<IList<Location>> GetDropOffLocationAsync(string LocationId);
    }
}
