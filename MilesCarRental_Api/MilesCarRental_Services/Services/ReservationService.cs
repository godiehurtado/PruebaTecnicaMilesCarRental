using MilesCarRental_Entities;
using MilesCarRental_Services.Interfaces;
using MilesCarRental_UoW.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MilesCarRental_Services.Services
{
    /// <summary>
    /// Servicio que proporciona lógica de negocio relacionada con las reservas en el sistema de alquiler de vehículos.
    /// </summary>
    public class ReservationService : IReservationService
    {
        private IUoW _unitOfWork;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor de la clase ReservationService.
        /// </summary>
        /// <param name="unitOfWork">Unidad de trabajo que gestiona las operaciones en la capa de acceso a datos.</param>
        /// <param name="configuration">Configuración de la aplicación (opcional).</param>
        public ReservationService(IUoW unitOfWork,
            IConfiguration configuration = null)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        /// <summary>
        /// Crea una nueva reserva en el sistema.
        /// </summary>
        /// <param name="reservation">Datos de la reserva a crear.</param>
        /// <returns>La reserva creada con información adicional (por ejemplo, ID asignado).</returns>
        public async Task<Reservation> PostReservationAsync(Reservation reservation)
        {
            // Patrón de Diseño: Inyección de Dependencias (DI)

            string ReservationId = "";
            string CustomerId = "";
            try
            {
                // Utiliza la unidad de trabajo para gestionar las operaciones en la capa de acceso a datos
                using (var context = _unitOfWork.Create())
                {
                    // Crea el cliente asociado a la reserva
                    CustomerId = await context.Repositories.CustomerRepository.CreateAsync(reservation.Customer);
                    reservation.CustomerId = Guid.Parse(CustomerId);

                    // Calcula la duración de la reserva en días
                    TimeSpan difference = reservation.EndDate - reservation.StartDate;
                    int days = difference.Days;

                    // Calcula el costo total de la reserva
                    reservation.TotalRate = reservation.Vehicle.DailyPrice * days;

                    // Crea la reserva en la capa de acceso a datos
                    ReservationId = await context.Repositories.ReservationRepository.CreateAsync(reservation);
                    reservation.ReservationId = Guid.Parse(ReservationId);

                    // Guarda los cambios en la base de datos
                    context.SaveChange();

                    // Retorna la reserva con información adicional (por ejemplo, ID asignado)
                    return reservation;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw ex;
            }
        }
    }
}
