using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MilesCarRental_Repository.DB
{
    /// <summary>
    /// Clase base abstracta para implementar operaciones comunes de base de datos.
    /// </summary>
    public abstract class Repository
    {
        /// <summary>
        /// Conexión a la base de datos.
        /// </summary>
        protected SqlConnection _context;

        /// <summary>
        /// Transacción asociada a la operación en la base de datos.
        /// </summary>
        protected SqlTransaction _transaction;

        /// <summary>
        /// Ejecuta un comando no asincrónico en la base de datos.
        /// </summary>
        /// <param name="nameSP">Nombre del procedimiento almacenado.</param>
        /// <param name="lstParameterIn">Diccionario de parámetros de entrada.</param>
        /// <returns>True si la ejecución fue exitosa; de lo contrario, false.</returns>
        public async Task<bool> ExecuteComandoBDNonAsync(string nameSP, Dictionary<string, object> lstParameterIn)
        {
            bool result = false;
            try
            {
                SqlCommand comando = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = nameSP, Connection = _context, Transaction = _transaction };
                if (lstParameterIn.Count > 0)
                {
                    foreach (var item in lstParameterIn)
                    {
                        comando.Parameters.Add(new SqlParameter() { ParameterName = item.Key, Value = item.Value, IsNullable = true });
                    }
                }
                try
                {
                    int reader = comando.ExecuteNonQuery();
                    result = true;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            { throw ex; }
            return result;
        }

        /// <summary>
        /// Ejecuta un comando asincrónico en la base de datos.
        /// </summary>
        /// <param name="nameSP">Nombre del procedimiento almacenado.</param>
        /// <param name="lstParameterIn">Diccionario de parámetros de entrada.</param>
        /// <param name="parameterOut">Parámetro de salida.</param>
        /// <returns>Valor del parámetro de salida después de la ejecución.</returns>
        public async Task<string> ExecuteComandoBDAsync(string nameSP, Dictionary<string, object> lstParameterIn, SqlParameter parameterOut)
        {
            string parameterOutValue = string.Empty;
            try
            {
                SqlCommand comando = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = nameSP, Connection = _context, Transaction = _transaction };
                if (lstParameterIn.Count > 0)
                {
                    foreach (var item in lstParameterIn)
                    {
                        comando.Parameters.Add(new SqlParameter() { ParameterName = item.Key, Value = item.Value, IsNullable = true });
                    }
                }
                parameterOut.Direction = ParameterDirection.Output; parameterOut.IsNullable = true;
                comando.Parameters.Add(parameterOut);
                try
                {
                    var reader = await comando.ExecuteNonQueryAsync();
                    parameterOutValue = Convert.ToString(comando.Parameters[parameterOut.ParameterName].Value);
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            { throw ex; }
            return parameterOutValue;
        }

        /// <summary>
        /// Ejecuta un comando asincrónico en la base de datos y devuelve un DataTable con el resultado.
        /// </summary>
        /// <param name="nameSP">Nombre del procedimiento almacenado.</param>
        /// <param name="lstParameterIn">Diccionario de parámetros de entrada.</param>
        /// <returns>DataTable con el resultado de la ejecución.</returns>
        public async Task<DataTable> ExecuteComandoBDDTAsync(string nameSP, Dictionary<string, object> lstParameterIn)
        {
            var dt = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand { CommandType = CommandType.StoredProcedure, CommandText = nameSP, Connection = _context, Transaction = _transaction };

                if (lstParameterIn.Count > 0)
                {
                    foreach (var item in lstParameterIn)
                    {
                        comando.Parameters.Add(new SqlParameter() { ParameterName = item.Key, Value = item.Value, IsNullable = true });
                    }
                }
                var reader = await comando.ExecuteReaderAsync();
                dt.Load(reader);
                return dt;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
