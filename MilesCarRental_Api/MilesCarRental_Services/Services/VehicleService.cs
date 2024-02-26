using MilesCarRental_Entities;
using MilesCarRental_Services.Interfaces;
using MilesCarRental_UoW.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MilesCarRental_Services.Services
{
    /// <summary>
    /// Servicio que proporciona lógica de negocio relacionada con los vehículos en el sistema de alquiler de vehículos.
    /// </summary>
    public class VehicleService : IVehicleService
    {
        private IUoW _unitOfWork;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor de la clase VehicleService.
        /// </summary>
        /// <param name="unitOfWork">Unidad de trabajo que gestiona las operaciones en la capa de acceso a datos.</param>
        /// <param name="configuration">Configuración de la aplicación (opcional).</param>
        public VehicleService(IUoW unitOfWork,
            IConfiguration configuration = null)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        /// <summary>
        /// Obtiene los tipos de vehículos disponibles para un rango de fechas y una ubicación específicos.
        /// </summary>
        /// <param name="LocationId">Identificador de la ubicación.</param>
        /// <param name="StartDate">Fecha de inicio en formato MM/dd/yyyy.</param>
        /// <param name="EndDate">Fecha de fin en formato MM/dd/yyyy.</param>
        /// <returns>Lista de categorías de vehículos disponibles.</returns>
        public async Task<IList<VehicleCategory>> GetVehicleTypeEnablesAsync(string LocationId, string StartDate, string EndDate)
        {
            // Patrón de Diseño: Inyección de Dependencias (DI)

            string format = "MM/dd/yyyy";

            DateTime _startDate = DateTime.ParseExact(StartDate, format, System.Globalization.CultureInfo.InvariantCulture);
            DateTime _endDate = DateTime.ParseExact(EndDate, format, System.Globalization.CultureInfo.InvariantCulture);

            List<VehicleCategory> ObjVehicleCategory = new List<VehicleCategory>();
            try
            {
                using (var contexto = _unitOfWork.Create())
                {
                    ObjVehicleCategory = await contexto.Repositories.VehicleRepository.GetVehicleTypeEnablesAsync(LocationId, _startDate, _endDate);
                }

                return ObjVehicleCategory;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un vehículo disponible para un rango de fechas, una ubicación y una categoría específicos.
        /// </summary>
        /// <param name="LocationId">Identificador de la ubicación.</param>
        /// <param name="StartDate">Fecha de inicio en formato MM/dd/yyyy.</param>
        /// <param name="EndDate">Fecha de fin en formato MM/dd/yyyy.</param>
        /// <param name="CategoryId">Identificador de la categoría de vehículo.</param>
        /// <returns>Vehículo disponible.</returns>
        public async Task<Vehicle> GetVehicleEnableAsync(string LocationId, string StartDate, string EndDate, string CategoryId)
        {
            string format = "MM/dd/yyyy";

            DateTime _startDate = DateTime.ParseExact(StartDate, format, System.Globalization.CultureInfo.InvariantCulture);
            DateTime _endDate = DateTime.ParseExact(EndDate, format, System.Globalization.CultureInfo.InvariantCulture);

            List<Vehicle> ObjVehicleCategory = new List<Vehicle>();
            try
            {
                using (var contexto = _unitOfWork.Create())
                {
                    ObjVehicleCategory = await contexto.Repositories.VehicleRepository.GetVehiclesEnablesAsync(LocationId, _startDate, _endDate, CategoryId);
                }

                return ObjVehicleCategory.FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw ex;
            }
        }
    }
}
