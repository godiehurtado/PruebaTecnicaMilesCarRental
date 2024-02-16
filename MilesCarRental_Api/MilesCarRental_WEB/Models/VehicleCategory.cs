
namespace MilesCarRental_WEB.Models
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
