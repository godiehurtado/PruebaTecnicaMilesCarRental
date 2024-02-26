namespace MilesCarRental_Entities
{
    /// <summary>
    /// Clase que representa la información de una reserva en el sistema de alquiler de vehículos.
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Identificador único de la reserva.
        /// </summary>
        public Guid ReservationId { get; set; }

        /// <summary>
        /// Identificador único del cliente asociado a la reserva.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Identificador único del vehículo reservado.
        /// </summary>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Fecha de inicio de la reserva.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Fecha de fin de la reserva.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Identificador del estado de la reserva.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Tarifa total de la reserva.
        /// </summary>
        public decimal TotalRate { get; set; }

        /// <summary>
        /// Identificador de la ubicación de recogida del vehículo.
        /// </summary>
        public int PickUpLocationId { get; set; }

        /// <summary>
        /// Identificador de la ubicación de devolución del vehículo.
        /// </summary>
        public int DropOffLocationId { get; set; }

        /// <summary>
        /// Objeto que representa la ubicación de recogida del vehículo (opcional).
        /// </summary>
        public Location? PickUpLocation { get; set; }

        /// <summary>
        /// Objeto que representa la ubicación de devolución del vehículo (opcional).
        /// </summary>
        public Location? DropOffLocation { get; set; }

        /// <summary>
        /// Objeto que representa el vehículo reservado.
        /// </summary>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Objeto que representa el cliente asociado a la reserva.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Objeto que representa el estado de la reserva (opcional).
        /// </summary>
        public ReservationStatus? Status { get; set; }
    }
}
