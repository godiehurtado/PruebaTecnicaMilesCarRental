using MilesCarRental_Entities;

namespace MilesCarRental_Repository.Interfaces
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con vehículos en la base de datos.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Obtiene la lista de vehículos habilitados para alquilar en una ubicación específica y un rango de fechas.
        /// </summary>
        /// <param name="LocationId">Identificador de la ubicación.</param>
        /// <param name="StartDate">Fecha de inicio del período de alquiler.</param>
        /// <param name="EndDate">Fecha de fin del período de alquiler.</param>
        /// <param name="CategoryId">Identificador de la categoría de vehículo (opcional).</param>
        /// <returns>Lista de objetos Vehicle que representan los vehículos disponibles.</returns>
        Task<List<Vehicle>> GetVehiclesEnablesAsync(string LocationId, DateTime StartDate, DateTime EndDate, string CategoryId);

        /// <summary>
        /// Obtiene la lista de tipos de vehículos habilitados para alquilar en una ubicación específica y un rango de fechas.
        /// </summary>
        /// <param name="LocationId">Identificador de la ubicación.</param>
        /// <param name="StartDate">Fecha de inicio del período de alquiler.</param>
        /// <param name="EndDate">Fecha de fin del período de alquiler.</param>
        /// <returns>Lista de objetos VehicleCategory que representan los tipos de vehículos disponibles.</returns>
        Task<List<VehicleCategory>> GetVehicleTypeEnablesAsync(string LocationId, DateTime StartDate, DateTime EndDate);
    }
}
