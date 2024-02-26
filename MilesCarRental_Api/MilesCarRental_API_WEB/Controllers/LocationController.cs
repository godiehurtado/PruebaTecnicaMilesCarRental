using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental_Services.Interfaces;
using MilesCarRental_Entities;

namespace MilesCarRental_API_WEB.Controllers
{
    /// <summary>
    /// Controlador que gestiona las operaciones relacionadas con las ubicaciones en el sistema de alquiler de vehículos.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor del controlador de ubicaciones.
        /// </summary>
        /// <param name="locationService">Servicio de ubicaciones.</param>
        /// <param name="config">Configuración de la aplicación.</param>
        /// <param name="mapper">Instancia de AutoMapper.</param>
        public LocationController(ILocationService locationService, IConfiguration config, IMapper mapper)
        {
            _locationService = locationService;
            _config = config;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todas las ubicaciones disponibles.
        /// </summary>
        /// <returns>Lista de ubicaciones.</returns>
        [HttpGet("[action]")]
        public async Task<IList<Location>> GetLocations()
        {
            IList<Location> lstLocation = new List<Location>();
            lstLocation = (IList<Location>)await _locationService.GetAllLocationAsync();
            return lstLocation;
        }

        /// <summary>
        /// Obtiene las ubicaciones de devolución para una ubicación específica.
        /// </summary>
        /// <param name="locationId">Identificador de la ubicación.</param>
        /// <returns>Lista de ubicaciones de devolución.</returns>
        [HttpGet("[action]")]
        public async Task<IList<Location>> GetDropOffLocations(string locationId)
        {
            IList<Location> lstLocation = new List<Location>();
            lstLocation = (IList<Location>)await _locationService.GetDropOffLocationAsync(locationId);
            return lstLocation;
        }
    }
}
