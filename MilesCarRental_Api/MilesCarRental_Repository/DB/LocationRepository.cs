using MilesCarRental_Entities;
using MilesCarRental_Repository.Interfaces;
using System.Data.SqlClient;

namespace MilesCarRental_Repository.DB
{
    public class LocationRepository : Repository, ILocationRepository
    {
        public LocationRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public async Task<List<Location>> GetAllLocationAsync()
        {
            List<Location> ObjLocation = new List<Location>();
            try
            {
                Dictionary<string, object> lstParameters = new Dictionary<string, object>
                {
                };
                ObjLocation = MapInstance.MapearInstanciaObjeto<Location>(await ExecuteComandoBDDTAsync("GET_ALL_LOCATION", lstParameters)).ToList();
                return ObjLocation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Location>> GetDropOffLocationAsync(string LocationId)
        {
            List<Location> ObjLocation = new List<Location>();
            try
            {
                Dictionary<string, object> lstParameters = new Dictionary<string, object>
                {
                    { "@LocationId", LocationId }
                };
                ObjLocation = MapInstance.MapearInstanciaObjeto<Location>(await ExecuteComandoBDDTAsync("GET_DROPOFF_LOCATION", lstParameters)).ToList();
                return ObjLocation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
