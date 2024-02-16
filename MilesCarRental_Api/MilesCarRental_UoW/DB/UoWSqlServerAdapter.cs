using MilesCarRental_UoW.Interfaces;
using System.Data.SqlClient;

namespace MilesCarRental_UoW.DB
{
    public class UoWSqlServerAdapter : IUoWAdapter
    {
        private SqlConnection _context { get; set; }
        private SqlTransaction _transaction { get; set; }
        public IUoWRepository Repositories { get; set; }

        public UoWSqlServerAdapter(string connectionString)
        {
            _context = new SqlConnection(connectionString);
            _context.Open();
            _transaction = _context.BeginTransaction();
            Repositories = new UoWSqlServerRepository(_context, _transaction);
        }

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

        public void SaveChange()
        {
            _transaction.Commit();
        }
    }
}
