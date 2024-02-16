using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental_Services.Interfaces;
using MilesCarRental_Entities;

namespace MilesCarRental_API_WEB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService reservationService,
            IConfiguration config, IMapper mapper)
        {
            _reservationService = reservationService;
            _config = config;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<Reservation> PostReservation(Reservation reservation)
        {
            reservation = await _reservationService.PostReservationAsync(reservation);
            return reservation;
        }
    }
}
