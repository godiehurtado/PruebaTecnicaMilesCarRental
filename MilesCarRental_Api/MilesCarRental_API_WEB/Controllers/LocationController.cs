using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental_Services.Interfaces;
using MilesCarRental_Entities;

namespace MilesCarRental_API_WEB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public LocationController(ILocationService locationService,
            IConfiguration config, IMapper mapper)
        {
            _locationService = locationService;
            _config = config;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IList<Location>> GetLocations()
        {
            IList<Location> lstLocation = new List<Location>();
            lstLocation = (IList<Location>)await _locationService.GetAllLocationAsync();
            return lstLocation;
        }

        [HttpGet("[action]")]
        public async Task<IList<Location>> GetDropOffLocations(string locationId)
        {
            IList<Location> lstLocation = new List<Location>();
            lstLocation = (IList<Location>)await _locationService.GetDropOffLocationAsync(locationId);
            return lstLocation;
        }
    }
}
