using MilesCarRental_Entities;
using MilesCarRental_Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace MilesCarRental_Repository.DB
{
    public class ReservationRepository : Repository, IReservationRepository
    {
        public ReservationRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public async Task<string> CreateAsync(Reservation reservation)
        {
            string result = "";
            try
            {
                Dictionary<string, object> lstParameters = new Dictionary<string, object>
                {
                    { "@CustomerId", reservation.CustomerId },
                    { "@DropOffLocationId", reservation.DropOffLocationId },
                    { "@EndDate", reservation.EndDate },
                    { "@PickUpLocationId", reservation.PickUpLocationId },
                    { "@StartDate", reservation.StartDate },
                    { "@StatusId", 1 },
                    { "@TotalRate", reservation.TotalRate },
                    { "@VehicleId", reservation.VehicleId }
                };
                Guid ReservationId = Guid.NewGuid();
                ReservationId = Guid.Parse(await ExecuteComandoBDAsync ("INSERT_RESERVATION", lstParameters, new SqlParameter() { ParameterName = "@ReservationId", Value = ReservationId }));
                result = string.IsNullOrEmpty(ReservationId.ToString()) == true ? "" : ReservationId.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
