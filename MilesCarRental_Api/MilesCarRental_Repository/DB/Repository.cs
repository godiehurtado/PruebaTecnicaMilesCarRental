using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MilesCarRental_Repository.DB
{
    public abstract class Repository
    {
        protected SqlConnection _context;
        protected SqlTransaction _transaction;

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
