namespace MilesCarRental_Entities
{
    /// <summary>
    /// Clase que representa el estado de una reserva en el sistema de alquiler de vehículos.
    /// </summary>
    public class ReservationStatus
    {
        /// <summary>
        /// Identificador único del estado de la reserva.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Nombre del estado de la reserva.
        /// </summary>
        public string StatusName { get; set; }
    }
}
