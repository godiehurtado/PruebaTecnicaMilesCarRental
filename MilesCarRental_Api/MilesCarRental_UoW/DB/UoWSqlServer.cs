using MilesCarRental_UoW.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MilesCarRental_UoW.DB
{
    /// <summary>
    /// Implementación de IUoW que utiliza una base de datos SQL Server.
    /// Esta clase es responsable de crear instancias de IUoWAdapter asociadas a SQL Server.
    /// </summary>
    public class UoWSqlServer : IUoW
    {
        /// <summary>
        /// Configuración de la aplicación que puede contener la cadena de conexión a la base de datos.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor de la clase UoWSqlServer.
        /// </summary>
        /// <param name="configuration">Configuración de la aplicación.</param>
        public UoWSqlServer(IConfiguration configuration = null)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Crea una nueva instancia de IUoWAdapter asociada a SQL Server.
        /// </summary>
        /// <returns>Instancia de IUoWAdapter.</returns>
        public IUoWAdapter Create()
        {
            // Obtiene la cadena de conexión desde la configuración.
            var connectionString = _configuration.GetSection("SqlConnectionString").Value;

            // Crea y devuelve una nueva instancia de UoWSqlServerAdapter.
            return new UoWSqlServerAdapter(connectionString);
        }
    }
}
