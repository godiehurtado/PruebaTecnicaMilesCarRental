using MilesCarRental_Entities;

namespace MilesCarRental_Repository.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones relacionadas con clientes en la base de datos.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Crea un nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="customer">Instancia del objeto Customer que representa la información del cliente.</param>
        /// <returns>Identificador único del cliente creado.</returns>
        Task<string> CreateAsync(Customer customer);
    }
}
