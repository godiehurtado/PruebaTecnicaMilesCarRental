namespace MilesCarRental_Entities
{
    /// <summary>
    /// Clase que representa la información de un vehículo en el sistema de alquiler de vehículos.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Identificador único del vehículo.
        /// </summary>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Marca del vehículo.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Modelo del vehículo.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Año de fabricación del vehículo.
        /// </summary>
        public int ManufacturingYear { get; set; }

        /// <summary>
        /// Identificador de la categoría del vehículo.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Kilometraje del vehículo.
        /// </summary>
        public decimal Mileage { get; set; }

        /// <summary>
        /// Identificador del estado del vehículo.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Precio diario de alquiler del vehículo.
        /// </summary>
        public decimal DailyPrice { get; set; }

        /// <summary>
        /// Identificador de la ubicación actual del vehículo.
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Objeto que representa la categoría del vehículo (opcional).
        /// </summary>
        public VehicleCategory? Category { get; set; }

        /// <summary>
        /// Objeto que representa el estado actual del vehículo (opcional).
        /// </summary>
        public VehicleStatus? Status { get; set; }

        /// <summary>
        /// Objeto que representa la ubicación actual del vehículo (opcional).
        /// </summary>
        public Location? Location { get; set; }
    }
}
