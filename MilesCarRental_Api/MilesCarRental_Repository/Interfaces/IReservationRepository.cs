using MilesCarRental_Entities;

namespace MilesCarRental_Repository.Interfaces
{
    public interface IReservationRepository
    {
        Task<string> CreateAsync(Reservation reservation);
    }
}
