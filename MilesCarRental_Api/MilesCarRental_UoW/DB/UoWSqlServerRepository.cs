using MilesCarRental_Repository.Interfaces;
using MilesCarRental_UoW.Interfaces;
using MilesCarRental_Repository.DB;
using System.Data.SqlClient;

namespace MilesCarRental_UoW.DB
{
    public class UoWSqlServerRepository : IUoWRepository
    {
        public ILocationRepository LocationRepository { get; }
        public IVehicleRepository VehicleRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IReservationRepository ReservationRepository { get; }

        public UoWSqlServerRepository(SqlConnection contexto, SqlTransaction transaccion)
        {
            LocationRepository = new LocationRepository(contexto, transaccion);
            VehicleRepository = new VehicleRepository(contexto, transaccion);
            CustomerRepository = new CustomerRepository(contexto, transaccion);
            ReservationRepository = new ReservationRepository(contexto, transaccion);
        }
    }
}
