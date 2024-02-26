namespace MilesCarRental_Entities
{
    /// <summary>
    /// Clase que representa el estado de un vehículo en el sistema de alquiler de vehículos.
    /// </summary>
    public class VehicleStatus
    {
        /// <summary>
        /// Identificador único del estado del vehículo.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Nombre del estado del vehículo.
        /// </summary>
        public string StatusName { get; set; }
    }
}
