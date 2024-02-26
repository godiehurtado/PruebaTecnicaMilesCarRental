using MilesCarRental_UoW.Interfaces;
using System.Data.SqlClient;

namespace MilesCarRental_UoW.DB
{
    /// <summary>
    /// Implementación de IUoWAdapter que adapta el uso de una base de datos SQL Server.
    /// Esta clase se encarga de gestionar la conexión, la transacción y proporciona un IUoWRepository.
    /// </summary>
    public class UoWSqlServerAdapter : IUoWAdapter
    {
        /// <summary>
        /// Objeto SqlConnection que representa la conexión a la base de datos.
        /// </summary>
        private SqlConnection _context { get; set; }

        /// <summary>
        /// Objeto SqlTransaction que representa la transacción asociada.
        /// </summary>
        private SqlTransaction _transaction { get; set; }

        /// <summary>
        /// Obtiene el IUoWRepository asociado a esta adaptación.
        /// </summary>
        public IUoWRepository Repositories { get; set; }

        /// <summary>
        /// Constructor de la clase UoWSqlServerAdapter.
        /// Inicializa la conexión, la transacción y el IUoWRepository asociado.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos SQL Server.</param>
        public UoWSqlServerAdapter(string connectionString)
        {
            _context = new SqlConnection(connectionString);
            _context.Open();
            _transaction = _context.BeginTransaction();
            Repositories = new UoWSqlServerRepository(_context, _transaction);
        }

        /// <summary>
        /// Libera los recursos asociados, como la transacción y la conexión.
        /// </summary>
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            if (_context != null)
            {
                _context.Close();
                _context.Dispose();
            }
            Repositories = null;
        }

        /// <summary>
        /// Confirma los cambios realizados en la transacción.
        /// </summary>
        public void SaveChange()
        {
            _transaction.Commit();
        }
    }
}
