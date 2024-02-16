using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental_Api.Model
{
    public class VehicleCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int TypeId { get; set; }

        // Propiedad de navegación
        public VehicleType Type { get; set; }
    }
}
