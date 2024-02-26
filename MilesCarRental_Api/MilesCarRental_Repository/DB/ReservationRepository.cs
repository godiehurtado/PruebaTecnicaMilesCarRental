using MilesCarRental_Entities;
using MilesCarRental_Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace MilesCarRental_Repository.DB
{
    /// <summary>
    /// Repositorio que maneja operaciones relacionadas con reservas en la base de datos.
    /// </summary>
    public class ReservationRepository : Repository, IReservationRepository
    {
        /// <summary>
        /// Constructor de la clase ReservationRepository.
        /// </summary>
        /// <param name="context">Objeto SqlConnection que representa la conexión a la base de datos.</param>
        /// <param name="transaction">Objeto SqlTransaction que representa la transacción asociada.</param>
        public ReservationRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        /// <summary>
        /// Crea una nueva reserva en la base de datos.
        /// </summary>
        /// <param name="reservation">Instancia del objeto Reservation que representa la información de la reserva.</param>
        /// <returns>Identificador único de la reserva creada.</returns>
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
                    { "@StatusId", 1 }, // Establece el estado inicial de la reserva.
                    { "@TotalRate", reservation.TotalRate },
                    { "@VehicleId", reservation.VehicleId }
                };

                // Genera un nuevo identificador único para la reserva.
                Guid ReservationId = Guid.NewGuid();
                ReservationId = Guid.Parse(await ExecuteComandoBDAsync("INSERT_RESERVATION", lstParameters, new SqlParameter() { ParameterName = "@ReservationId", Value = ReservationId }));

                // Establece el resultado según la creación exitosa de la reserva.
                result = string.IsNullOrEmpty(ReservationId.ToString()) ? "" : ReservationId.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
