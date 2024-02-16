using MilesCarRental_Entities;

namespace MilesCarRental_Services.Interfaces
{
    public interface IVehicleService
    {
        Task<IList<VehicleCategory>> GetVehicleTypeEnablesAsync(string LocationId, string StartDate, string EndDate);
        Task<Vehicle> GetVehicleEnableAsync(string LocationId, string StartDate, string EndDate, string CategoryId);
    }
}
