using MilesCarRental_Repository.Interfaces;
using MilesCarRental_UoW.Interfaces;
using MilesCarRental_Repository.DB;
using System.Data.SqlClient;

namespace MilesCarRental_UoW.DB
{
    /// <summary>
    /// Implementación de la interfaz IUoWRepository que utiliza una base de datos SQL Server.
    /// Esta clase actúa como una Unidad de Trabajo que agrupa varios repositorios.
    /// </summary>
    public class UoWSqlServerRepository : IUoWRepository
    {
        /// <summary>
        /// Obtiene el repositorio de ubicaciones asociado a esta Unidad de Trabajo.
        /// </summary>
        public ILocationRepository LocationRepository { get; }

        /// <summary>
        /// Obtiene el repositorio de vehículos asociado a esta Unidad de Trabajo.
        /// </summary>
        public IVehicleRepository VehicleRepository { get; }

        /// <summary>
        /// Obtiene el repositorio de clientes asociado a esta Unidad de Trabajo.
        /// </summary>
        public ICustomerRepository CustomerRepository { get; }

        /// <summary>
        /// Obtiene el repositorio de reservas asociado a esta Unidad de Trabajo.
        /// </summary>
        public IReservationRepository ReservationRepository { get; }

        /// <summary>
        /// Constructor de la clase UoWSqlServerRepository.
        /// Inicializa los repositorios asociados a esta Unidad de Trabajo con la conexión y transacción proporcionadas.
        /// </summary>
        /// <param name="contexto">Objeto SqlConnection que representa la conexión a la base de datos.</param>
        /// <param name="transaccion">Objeto SqlTransaction que representa la transacción asociada.</param>
        public UoWSqlServerRepository(SqlConnection contexto, SqlTransaction transaccion)
        {
            LocationRepository = new LocationRepository(contexto, transaccion);
            VehicleRepository = new VehicleRepository(contexto, transaccion);
            CustomerRepository = new CustomerRepository(contexto, transaccion);
            ReservationRepository = new ReservationRepository(contexto, transaccion);
        }
    }
}
