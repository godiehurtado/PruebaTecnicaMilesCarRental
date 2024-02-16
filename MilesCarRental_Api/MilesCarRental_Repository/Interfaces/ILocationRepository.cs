using MilesCarRental_Entities;

namespace MilesCarRental_Repository.Interfaces
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocationAsync();
        Task<List<Location>> GetDropOffLocationAsync(string LocationId);
    }
}
