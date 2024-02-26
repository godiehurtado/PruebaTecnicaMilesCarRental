using MilesCarRental_Entities;
using MilesCarRental_Services.Interfaces;
using MilesCarRental_UoW.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MilesCarRental_Services.Services
{
    /// <summary>
    /// Servicio que proporciona lógica de negocio relacionada con las ubicaciones en el sistema de alquiler de vehículos.
    /// </summary>
    public class LocationService : ILocationService
    {
        private IUoW _unitOfWork;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor de la clase LocationService.
        /// </summary>
        /// <param name="unitOfWork">Unidad de trabajo que gestiona las operaciones en la capa de acceso a datos.</param>
        /// <param name="configuration">Configuración de la aplicación (opcional).</param>
        public LocationService(IUoW unitOfWork,
            IConfiguration configuration = null)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        /// <summary>
        /// Obtiene todas las ubicaciones disponibles.
        /// </summary>
        /// <returns>Lista de ubicaciones.</returns>
        public async Task<IList<Location>> GetAllLocationAsync()
        {
            // Patrón de Diseño: Inyección de Dependencias (DI)

            List<Location> ObjLocation = new List<Location>();
            try
            {
                // Utiliza la unidad de trabajo para gestionar las operaciones en la capa de acceso a datos
                using (var contexto = _unitOfWork.Create())
                {
                    ObjLocation = await contexto.Repositories.LocationRepository.GetAllLocationAsync();
                }

                return ObjLocation;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene las ubicaciones de devolución para una ubicación específica.
        /// </summary>
        /// <param name="LocationId">Identificador de la ubicación.</param>
        /// <returns>Lista de ubicaciones de devolución.</returns>
        public async Task<IList<Location>> GetDropOffLocationAsync(string LocationId)
        {
            List<Location> ObjLocation = new List<Location>();
            try
            {
                using (var contexto = _unitOfWork.Create())
                {
                    ObjLocation = await contexto.Repositories.LocationRepository.GetDropOffLocationAsync(LocationId);
                }

                return ObjLocation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
