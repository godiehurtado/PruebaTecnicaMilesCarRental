namespace MilesCarRental_Entities
{
    /// <summary>
    /// Clase que representa el tipo de un vehículo en el sistema de alquiler de vehículos.
    /// </summary>
    public class VehicleType
    {
        /// <summary>
        /// Identificador único del tipo de vehículo.
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Nombre del tipo de vehículo.
        /// </summary>
        public string TypeName { get; set; }
    }
}
