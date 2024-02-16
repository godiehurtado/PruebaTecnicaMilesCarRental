using MilesCarRental_Entities;
using MilesCarRental_Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace MilesCarRental_Repository.DB
{
    public class CustomerRepository : Repository, ICustomerRepository
    {
        public CustomerRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public async Task<string> CreateAsync(Customer customer)
        {
            string result = "";
            try
            {
                Dictionary<string, object> lstParameters = new Dictionary<string, object>
                {
                    { "@Name", customer.Name },
                    { "@Document", customer.Document },
                    { "@Licence", customer.Licence },
                    { "@Phone", customer.Phone }
                };
                Guid CustomerId = Guid.NewGuid();
                CustomerId = Guid.Parse(await ExecuteComandoBDAsync("INSERT_CUSTOMER", lstParameters, new SqlParameter() { ParameterName = "@CustomerId", Value = CustomerId }));
                result = string.IsNullOrEmpty(CustomerId.ToString()) == true ? "" : CustomerId.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
