using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental_Api.Model
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public decimal TotalRate { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }

        // Propiedades de navegación
        public Location PickUpLocation { get; set; }
        public Location DropOffLocation { get; set; }
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }
    }
}
