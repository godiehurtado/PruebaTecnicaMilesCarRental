namespace MilesCarRental_Entities
{
    /// <summary>
    /// Clase que representa la categoría de un vehículo en el sistema de alquiler de vehículos.
    /// </summary>
    public class VehicleCategory
    {
        /// <summary>
        /// Identificador único de la categoría del vehículo.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Nombre de la categoría del vehículo.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Identificador del tipo de vehículo asociado a la categoría.
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Objeto que representa el tipo de vehículo asociado a la categoría (opcional).
        /// </summary>
        public VehicleType Type { get; set; }
    }
}
