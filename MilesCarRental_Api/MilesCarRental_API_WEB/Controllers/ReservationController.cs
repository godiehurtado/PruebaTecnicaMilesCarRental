using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental_Services.Interfaces;
using MilesCarRental_Entities;

namespace MilesCarRental_API_WEB.Controllers
{
    /// <summary>
    /// Controlador que gestiona las operaciones relacionadas con las reservaciones en el sistema de alquiler de vehículos.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor del controlador de reservaciones.
        /// </summary>
        /// <param name="reservationService">Servicio de reservaciones.</param>
        /// <param name="config">Configuración de la aplicación.</param>
        /// <param name="mapper">Instancia de AutoMapper.</param>
        public ReservationController(IReservationService reservationService, IConfiguration config, IMapper mapper)
        {
            _reservationService = reservationService;
            _config = config;
            _mapper = mapper;
        }

        /// <summary>
        /// Crea una nueva reservación en el sistema.
        /// </summary>
        /// <param name="reservation">Datos de la reservación a crear.</param>
        /// <returns>La reservación creada.</returns>
        [HttpPost("[action]")]
        public async Task<Reservation> PostReservation(Reservation reservation)
        {
            reservation = await _reservationService.PostReservationAsync(reservation);
            return reservation;
        }
    }
}
