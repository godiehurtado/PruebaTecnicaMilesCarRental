using MilesCarRental_UoW.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MilesCarRental_UoW.DB
{
    public class UoWSqlServer : IUoW
    {
        private readonly IConfiguration _configuration;
        public UoWSqlServer(IConfiguration configuration = null)
        {
            _configuration = configuration;
        }
        public IUoWAdapter Create()
        {
            var connectionString = _configuration.GetSection("SqlConnectionString").Value;
            return new UoWSqlServerAdapter(connectionString);
        }
    }
}
