using MilesCarRental_Entities;

namespace MilesCarRental_Services.Interfaces
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con la gestión de vehículos en el sistema de alquiler de vehículos.
    /// </summary>
    public interface IVehicleService
    {
        /// <summary>
        /// Obtiene los tipos de vehículos disponibles para un rango de fechas y una ubicación específicos.
        /// </summary>
        /// <param name="LocationId">Identificador de la ubicación.</param>
        /// <param name="StartDate">Fecha de inicio en formato MM/dd/yyyy.</param>
        /// <param name="EndDate">Fecha de fin en formato MM/dd/yyyy.</param>
        /// <returns>Lista de categorías de vehículos disponibles.</returns>
        Task<IList<VehicleCategory>> GetVehicleTypeEnablesAsync(string LocationId, string StartDate, string EndDate);

        /// <summary>
        /// Obtiene un vehículo disponible para un rango de fechas, una ubicación y una categoría específicos.
        /// </summary>
        /// <param name="LocationId">Identificador de la ubicación.</param>
        /// <param name="StartDate">Fecha de inicio en formato MM/dd/yyyy.</param>
        /// <param name="EndDate">Fecha de fin en formato MM/dd/yyyy.</param>
        /// <param name="CategoryId">Identificador de la categoría de vehículo.</param>
        /// <returns>Vehículo disponible.</returns>
        Task<Vehicle> GetVehicleEnableAsync(string LocationId, string StartDate, string EndDate, string CategoryId);
    }
}
