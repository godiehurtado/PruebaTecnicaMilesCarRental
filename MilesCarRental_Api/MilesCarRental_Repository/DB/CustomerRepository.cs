using MilesCarRental_Entities;
using MilesCarRental_Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace MilesCarRental_Repository.DB
{
    /// <summary>
    /// Repositorio que maneja operaciones relacionadas con clientes en la base de datos.
    /// </summary>
    public class CustomerRepository : Repository, ICustomerRepository
    {
        /// <summary>
        /// Constructor de la clase CustomerRepository.
        /// </summary>
        /// <param name="context">Objeto SqlConnection que representa la conexión a la base de datos.</param>
        /// <param name="transaction">Objeto SqlTransaction que representa la transacción asociada.</param>
        public CustomerRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        /// <summary>
        /// Crea un nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="customer">Instancia del objeto Customer que representa la información del cliente.</param>
        /// <returns>Identificador único del cliente creado.</returns>
        public async Task<string> CreateAsync(Customer customer)
        {
            string result = "";
            try
            {
                Dictionary<string, object> lstParameters = new Dictionary<string, object>
                {
                    { "@Name", customer.Name },
                    { "@Document", customer.Document },
                    { "@Licence", customer.Licence },
                    { "@Phone", customer.Phone }
                };

                // Genera un nuevo identificador único para el cliente.
                Guid CustomerId = Guid.NewGuid();
                CustomerId = Guid.Parse(await ExecuteComandoBDAsync("INSERT_CUSTOMER", lstParameters, new SqlParameter() { ParameterName = "@CustomerId", Value = CustomerId }));

                // Establece el resultado según la creación exitosa del cliente.
                result = string.IsNullOrEmpty(CustomerId.ToString()) ? "" : CustomerId.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
