namespace MilesCarRental_Entities
{
    /// <summary>
    /// Clase que representa la información de una ubicación en el sistema de alquiler de vehículos.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Identificador único de la ubicación.
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Nombre de la ubicación.
        /// </summary>
        public string LocationName { get; set; }
    }
}
