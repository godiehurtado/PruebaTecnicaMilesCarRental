using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental_Services.Interfaces;
using MilesCarRental_Entities;

namespace MilesCarRental_API_WEB.Controllers
{
    /// <summary>
    /// Controlador que gestiona las operaciones relacionadas con los vehículos en el sistema de alquiler de vehículos.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor del controlador de vehículos.
        /// </summary>
        /// <param name="vehicleService">Servicio de vehículos.</param>
        /// <param name="config">Configuración de la aplicación.</param>
        /// <param name="mapper">Instancia de AutoMapper.</param>
        public VehicleController(IVehicleService vehicleService, IConfiguration config, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _config = config;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene las categorías de vehículos disponibles para alquiler en una ubicación y período de tiempo específicos.
        /// </summary>
        /// <param name="locationId">Identificador de la ubicación.</param>
        /// <param name="pickupDate">Fecha de recogida del vehículo.</param>
        /// <param name="dropoffDate">Fecha de devolución del vehículo.</param>
        /// <returns>Lista de categorías de vehículos disponibles.</returns>
        [HttpGet("[action]")]
        public async Task<IList<VehicleCategory>> GetVehicleTypeEnables(string locationId, string pickupDate, string dropoffDate)
        {
            IList<VehicleCategory> lstVehicleCategory = new List<VehicleCategory>();
            lstVehicleCategory = (IList<VehicleCategory>)await _vehicleService.GetVehicleTypeEnablesAsync(locationId, pickupDate, dropoffDate);
            return lstVehicleCategory;
        }

        /// <summary>
        /// Obtiene un vehículo disponible para alquiler en una ubicación y período de tiempo específicos.
        /// </summary>
        /// <param name="locationId">Identificador de la ubicación.</param>
        /// <param name="pickupDate">Fecha de recogida del vehículo.</param>
        /// <param name="dropoffDate">Fecha de devolución del vehículo.</param>
        /// <param name="categoryId">Identificador de la categoría de vehículo.</param>
        /// <returns>El vehículo disponible.</returns>
        [HttpGet("[action]")]
        public async Task<Vehicle> GetVehicleEnable(string locationId, string pickupDate, string dropoffDate, string categoryId)
        {
            Vehicle vehicle = new Vehicle();
            vehicle = (Vehicle)await _vehicleService.GetVehicleEnableAsync(locationId, pickupDate, dropoffDate, categoryId);
            return vehicle;
        }
    }
}
