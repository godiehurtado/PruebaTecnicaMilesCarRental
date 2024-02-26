using MilesCarRental_Repository.Interfaces;

namespace MilesCarRental_UoW.Interfaces
{
    /// <summary>
    /// Interfaz que define los repositorios asociados a una Unidad de Trabajo (Unit of Work).
    /// </summary>
    public interface IUoWRepository
    {
        /// <summary>
        /// Obtiene el repositorio de ubicaciones asociado a esta Unidad de Trabajo.
        /// </summary>
        ILocationRepository LocationRepository { get; }

        /// <summary>
        /// Obtiene el repositorio de vehículos asociado a esta Unidad de Trabajo.
        /// </summary>
        IVehicleRepository VehicleRepository { get; }

        /// <summary>
        /// Obtiene el repositorio de reservas asociado a esta Unidad de Trabajo.
        /// </summary>
        IReservationRepository ReservationRepository { get; }

        /// <summary>
        /// Obtiene el repositorio de clientes asociado a esta Unidad de Trabajo.
        /// </summary>
        ICustomerRepository CustomerRepository { get; }
    }
}
