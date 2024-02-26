namespace MilesCarRental_Entities
{
    /// <summary>
    /// Clase que representa la información de un cliente en el sistema de alquiler de vehículos.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Identificador único del cliente.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Número de documento del cliente.
        /// </summary>
        public string Document { get; set; }

        /// <summary>
        /// Nombre del cliente.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Número de licencia del cliente.
        /// </summary>
        public string Licence { get; set; }

        /// <summary>
        /// País de residencia del cliente (opcional).
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Dirección de correo electrónico del cliente (opcional).
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Número de teléfono del cliente.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Dirección del cliente (opcional).
        /// </summary>
        public string? Address { get; set; }
    }
}
