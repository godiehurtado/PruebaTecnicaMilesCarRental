using MilesCarRental_Entities;

namespace MilesCarRental_Repository.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetVehiclesEnablesAsync(string LocationId, DateTime StartDate, DateTime EndDate, string CategoryId);
        Task<List<VehicleCategory>> GetVehicleTypeEnablesAsync(string LocationId, DateTime StartDate, DateTime EndDate);
    }
}
