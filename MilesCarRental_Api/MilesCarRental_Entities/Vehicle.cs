
namespace MilesCarRental_Entities
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

        // Propiedades de navegación
        public VehicleCategory? Category { get; set; }
        public VehicleStatus? Status { get; set; }
        public Location? Location { get; set; }
    }
}
