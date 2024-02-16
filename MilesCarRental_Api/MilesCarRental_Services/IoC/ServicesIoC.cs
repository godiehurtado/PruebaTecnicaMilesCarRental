using MilesCarRental_Services.Interfaces;
using MilesCarRental_Services.Services;
using MilesCarRental_UoW.Interfaces;
using MilesCarRental_UoW.DB;
using Microsoft.Extensions.DependencyInjection;

namespace MilesCarRental_Services.IoC
{
    public static class ServicesIoC
    {
        public static void AplicationServicesIoC(this IServiceCollection services)
        {
            services.AddTransient<IUoW, UoWSqlServer>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IReservationService, ReservationService>();
        }
    }
}
