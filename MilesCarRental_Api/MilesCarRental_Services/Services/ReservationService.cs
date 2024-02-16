using MilesCarRental_Entities;
using MilesCarRental_Services.Interfaces;
using MilesCarRental_UoW.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MilesCarRental_Services.Services
{
    public class ReservationService : IReservationService
    {
        private IUoW _unitOfWork;
        private readonly IConfiguration _configuration;

        public ReservationService(IUoW unitOfWork,
            IConfiguration configuration = null)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<Reservation> PostReservationAsync(Reservation reservation)
        {
            string ReservationId = "";
            string CustomerId = "";
            try
            {
                using (var context = _unitOfWork.Create())
                {
                    CustomerId = await context.Repositories.CustomerRepository.CreateAsync(reservation.Customer);
                    reservation.CustomerId = Guid.Parse(CustomerId);
                    TimeSpan difference = reservation.EndDate - reservation.StartDate;
                    int days = difference.Days;
                    reservation.TotalRate = reservation.Vehicle.DailyPrice * days;
                    ReservationId = await context.Repositories.ReservationRepository.CreateAsync(reservation);
                    reservation.ReservationId = Guid.Parse(ReservationId);
                    context.SaveChange();
                    return reservation;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
