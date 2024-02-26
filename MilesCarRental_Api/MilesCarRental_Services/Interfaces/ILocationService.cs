using MilesCarRental_Entities;

namespace MilesCarRental_Services.Interfaces
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con las ubicaciones en el sistema de alquiler de vehículos.
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Obtiene todas las ubicaciones disponibles.
        /// </summary>
        /// <returns>Lista de ubicaciones.</returns>
        Task<IList<Location>> GetAllLocationAsync();

        /// <summary>
        /// Obtiene las ubicaciones de devolución para una ubicación específica.
        /// </summary>
        /// <param name="LocationId">Identificador de la ubicación.</param>
        /// <returns>Lista de ubicaciones de devolución.</returns>
        Task<IList<Location>> GetDropOffLocationAsync(string LocationId);
    }
}
