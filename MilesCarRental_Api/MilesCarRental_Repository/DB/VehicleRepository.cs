using MilesCarRental_Entities;
using MilesCarRental_Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace MilesCarRental_Repository.DB
{
    /// <summary>
    /// Repositorio que maneja operaciones relacionadas con vehículos en la base de datos.
    /// </summary>
    public class VehicleRepository : Repository, IVehicleRepository
    {
        /// <summary>
        /// Constructor de la clase VehicleRepository.
        /// </summary>
        /// <param name="context">Objeto SqlConnection que representa la conexión a la base de datos.</param>
        /// <param name="transaction">Objeto SqlTransaction que representa la transacción asociada.</param>
        public VehicleRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        /// <summary>
        /// Obtiene la lista de vehículos habilitados para alquilar en una ubicación específica y un rango de fechas.
        /// </summary>
        /// <param name="LocationId">Identificador de la ubicación.</param>
        /// <param name="StartDate">Fecha de inicio del período de alquiler.</param>
        /// <param name="EndDate">Fecha de fin del período de alquiler.</param>
        /// <param name="CategoryId">Identificador de la categoría de vehículo (opcional).</param>
        /// <returns>Lista de objetos Vehicle que representan los vehículos disponibles.</returns>
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

                // Ejecuta el procedimiento almacenado y mapea el resultado a objetos Vehicle.
                ObjVehicle = MapInstance.MapearInstanciaObjeto<Vehicle>(await ExecuteComandoBDDTAsync("GET_VEHICLE_ENABLE", lstParameters)).ToList();
                return ObjVehicle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene la lista de tipos de vehículos habilitados para alquilar en una ubicación específica y un rango de fechas.
        /// </summary>
        /// <param name="LocationId">Identificador de la ubicación.</param>
        /// <param name="StartDate">Fecha de inicio del período de alquiler.</param>
        /// <param name="EndDate">Fecha de fin del período de alquiler.</param>
        /// <returns>Lista de objetos VehicleCategory que representan los tipos de vehículos disponibles.</returns>
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

                // Ejecuta el procedimiento almacenado y mapea el resultado a objetos VehicleCategory.
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
