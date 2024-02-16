using MilesCarRental_Entities;
using MilesCarRental_Services.Interfaces;
using MilesCarRental_UoW.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MilesCarRental_Services.Services
{
    public class LocationService : ILocationService
    {
        private IUoW _unitOfWork;
        private readonly IConfiguration _configuration;

        public LocationService(IUoW unitOfWork,
            IConfiguration configuration = null)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<IList<Location>> GetAllLocationAsync()
        {
            List<Location> ObjLocation = new List<Location>();
            try
            {
                using (var contexto = _unitOfWork.Create())
                {
                    ObjLocation = await contexto.Repositories.LocationRepository.GetAllLocationAsync();
                }

                return ObjLocation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
