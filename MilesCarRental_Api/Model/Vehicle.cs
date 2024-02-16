using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental_Api.Model
{
    public class Vehicle
    {
        public Guid VehicleId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ManufacturingYear { get; set; }
        public int CategoryId { get; set; }
        public decimal Mileage { get; set; }
        public int StatusId { get; set; }
        public decimal DailyPrice { get; set; }
        public int LocationId { get; set; }

    }
}
