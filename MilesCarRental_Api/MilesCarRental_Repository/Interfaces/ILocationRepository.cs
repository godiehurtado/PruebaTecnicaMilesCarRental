using MilesCarRental_Entities;

namespace MilesCarRental_Repository.Interfaces
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con ubicaciones en la base de datos.
    /// </summary>
    public interface ILocationRepository
    {
        /// <summary>
        /// Obtiene todas las ubicaciones disponibles en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Location que representan las ubicaciones.</returns>
        Task<List<Location>> GetAllLocationAsync();

        /// <summary>
        /// Obtiene las ubicaciones disponibles para devolución de vehículos según el identificador de la ubicación.
        /// </summary>
        /// <param name="LocationId">Identificador de la ubicación.</param>
        /// <returns>Lista de objetos Location que representan las ubicaciones de devolución.</returns>
        Task<List<Location>> GetDropOffLocationAsync(string LocationId);
    }
}
