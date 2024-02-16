using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental_Services.Interfaces;
using MilesCarRental_Entities;

namespace MilesCarRental_API_WEB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleService vehicleService,
            IConfiguration config, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _config = config;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IList<VehicleCategory>> GetVehicleTypeEnables(string locationId, string pickupDate, string dropoffDate)
        {
            IList<VehicleCategory> lstVehicleCategory = new List<VehicleCategory>();
            lstVehicleCategory = (IList<VehicleCategory>)await _vehicleService.GetVehicleTypeEnablesAsync(locationId,pickupDate,dropoffDate);
            return lstVehicleCategory;
        }

        [HttpGet("[action]")]
        public async Task<Vehicle> GetVehicleEnable(string locationId, string pickupDate, string dropoffDate, string categoryId)
        {
            Vehicle vehicle = new Vehicle();
            vehicle = (Vehicle)await _vehicleService.GetVehicleEnableAsync(locationId, pickupDate, dropoffDate, categoryId);
            return vehicle;
        }
    }
}
