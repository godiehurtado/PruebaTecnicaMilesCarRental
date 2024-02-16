using MilesCarRental_Repository.Interfaces;

namespace MilesCarRental_UoW.Interfaces
{
    public interface IUoWRepository
    {
        ILocationRepository LocationRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        IReservationRepository ReservationRepository { get; }
        ICustomerRepository CustomerRepository { get; }
    }
}
