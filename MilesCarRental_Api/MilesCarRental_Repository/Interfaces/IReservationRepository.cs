using MilesCarRental_Entities;

namespace MilesCarRental_Repository.Interfaces
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con reservas en la base de datos.
    /// </summary>
    public interface IReservationRepository
    {
        /// <summary>
        /// Crea una nueva reserva en la base de datos.
        /// </summary>
        /// <param name="reservation">Instancia del objeto Reservation que representa la información de la reserva.</param>
        /// <returns>Identificador único de la reserva creada.</returns>
        Task<string> CreateAsync(Reservation reservation);
    }
}
