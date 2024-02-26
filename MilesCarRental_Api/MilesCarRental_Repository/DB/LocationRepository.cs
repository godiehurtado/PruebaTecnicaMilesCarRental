using MilesCarRental_Entities;
using MilesCarRental_Repository.Interfaces;
using System.Data.SqlClient;

namespace MilesCarRental_Repository.DB
{
    /// <summary>
    /// Repositorio que maneja operaciones relacionadas con ubicaciones en la base de datos.
    /// </summary>
    public class LocationRepository : Repository, ILocationRepository
    {
        /// <summary>
        /// Constructor de la clase LocationRepository.
        /// </summary>
        /// <param name="context">Objeto SqlConnection que representa la conexión a la base de datos.</param>
        /// <param name="transaction">Objeto SqlTransaction que representa la transacción asociada.</param>
        public LocationRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        /// <summary>
        /// Obtiene todas las ubicaciones disponibles en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Location que representan las ubicaciones.</returns>
        public async Task<List<Location>> GetAllLocationAsync()
        {
            List<Location> ObjLocation = new List<Location>();
            try
            {
                Dictionary<string, object> lstParameters = new Dictionary<string, object> { };

                // Ejecuta el procedimiento almacenado y mapea el resultado a objetos Location.
                ObjLocation = MapInstance.MapearInstanciaObjeto<Location>(await ExecuteComandoBDDTAsync("GET_ALL_LOCATION", lstParameters)).ToList();
                return ObjLocation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene las ubicaciones disponibles para devolución de vehículos según el identificador de la ubicación.
        /// </summary>
        /// <param name="LocationId">Identificador de la ubicación.</param>
        /// <returns>Lista de objetos Location que representan las ubicaciones de devolución.</returns>
        public async Task<List<Location>> GetDropOffLocationAsync(string LocationId)
        {
            List<Location> ObjLocation = new List<Location>();
            try
            {
                Dictionary<string, object> lstParameters = new Dictionary<string, object>
                {
                    { "@LocationId", LocationId }
                };

                // Ejecuta el procedimiento almacenado y mapea el resultado a objetos Location.
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
