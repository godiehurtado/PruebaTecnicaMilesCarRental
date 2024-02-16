using MilesCarRental_Entities;

namespace MilesCarRental_Services.Interfaces
{
    public interface IReservationService
    {
        Task<Reservation> PostReservationAsync(Reservation reservation);
    }
}
