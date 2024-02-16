using MilesCarRental_Entities;
using MilesCarRental_Services.Interfaces;
using MilesCarRental_UoW.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MilesCarRental_Services.Services
{
    public class VehicleService : IVehicleService
    {
        private IUoW _unitOfWork;
        private readonly IConfiguration _configuration;

        public VehicleService(IUoW unitOfWork,
            IConfiguration configuration = null)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<IList<VehicleCategory>> GetVehicleTypeEnablesAsync(string LocationId, string StartDate, string EndDate)
        {
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
                throw ex;
            }
        }

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
                throw ex;
            }
        }
    }
}
