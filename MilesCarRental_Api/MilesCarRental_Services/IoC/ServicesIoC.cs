using MilesCarRental_Services.Interfaces;
using MilesCarRental_Services.Services;
using MilesCarRental_UoW.Interfaces;
using MilesCarRental_UoW.DB;
using Microsoft.Extensions.DependencyInjection;

namespace MilesCarRental_Services.IoC
{
    /// <summary>
    /// Configuración de Inyección de Dependencias para servicios de la aplicación.
    /// </summary>
    public static class ServicesIoC
    {
        /// <summary>
        /// Configura las dependencias de servicios de la aplicación.
        /// </summary>
        /// <param name="services">Colección de servicios de inyección de dependencias.</param>
        public static void AplicationServicesIoC(this IServiceCollection services)
        {
            // Patrón de Diseño: Inyección de Dependencias (DI)

            // Agrega la implementación de la interfaz IUoW con la implementación concreta UoWSqlServer
            services.AddTransient<IUoW, UoWSqlServer>();

            // Agrega la implementación de la interfaz ILocationService con la implementación concreta LocationService
            services.AddTransient<ILocationService, LocationService>();

            // Agrega la implementación de la interfaz IVehicleService con la implementación concreta VehicleService
            services.AddTransient<IVehicleService, VehicleService>();

            // Agrega la implementación de la interfaz IReservationService con la implementación concreta ReservationService
            services.AddTransient<IReservationService, ReservationService>();
        }
    }
}
