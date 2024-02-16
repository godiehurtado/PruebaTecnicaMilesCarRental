using MilesCarRental_Entities;
using MilesCarRental_Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace MilesCarRental_Repository.DB
{
    public class VehicleRepository : Repository, IVehicleRepository
    {
        public VehicleRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public async Task<List<Vehicle>> GetVehiclesEnablesAsync(string LocationId, DateTime StartDate, DateTime EndDate, string CategoryId)
        {
            List<Vehicle> ObjVehicle = new List<Vehicle>();
            try
            {
                Dictionary<string, object> lstParameters = new Dictionary<string, object>
                {
                    { "@LocationId", LocationId },
                    { "@StartDate", StartDate },
                    { "@EndDate", EndDate },
                    { "@CategoryId", CategoryId }
                };

                ObjVehicle = MapInstance.MapearInstanciaObjeto<Vehicle>(await ExecuteComandoBDDTAsync("GET_VEHICLE_ENABLE", lstParameters)).ToList();
                return ObjVehicle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<VehicleCategory>> GetVehicleTypeEnablesAsync(string LocationId, DateTime StartDate, DateTime EndDate)
        {
            List<VehicleCategory> ObjVehicle = new List<VehicleCategory>();
            try
            {
                Dictionary<string, object> lstParameters = new Dictionary<string, object>
                {
                    { "@LocationId", LocationId },
                    { "@StartDate", StartDate },
                    { "@EndDate", EndDate }
                };

                DataTable resultTable = await ExecuteComandoBDDTAsync("GET_VEHICLE_TYPE_ENABLE", lstParameters);

                foreach (DataRow row in resultTable.Rows)
                {
                    VehicleCategory vehicleCategory = new VehicleCategory
                    {
                        CategoryId = Convert.ToInt32(row["categoryId"]),
                        CategoryName = Convert.ToString(row["categoryName"]),
                        TypeId = Convert.ToInt32(row["typeId"]),
                        Type = new VehicleType 
                        {
                            TypeId = Convert.ToInt32(row["typeId"]),
                            TypeName = Convert.ToString(row["typeName"])
                        }
                    };

                    ObjVehicle.Add(vehicleCategory);
                }

                return ObjVehicle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
