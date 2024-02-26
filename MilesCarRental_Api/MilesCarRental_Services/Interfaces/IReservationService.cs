using MilesCarRental_Entities;

namespace MilesCarRental_Services.Interfaces
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con las reservaciones en el sistema de alquiler de vehículos.
    /// </summary>
    public interface IReservationService
    {
        /// <summary>
        /// Crea una nueva reservación en el sistema.
        /// </summary>
        /// <param name="reservation">Datos de la reservación a crear.</param>
        /// <returns>La reservación creada.</returns>
        Task<Reservation> PostReservationAsync(Reservation reservation);
    }
}
