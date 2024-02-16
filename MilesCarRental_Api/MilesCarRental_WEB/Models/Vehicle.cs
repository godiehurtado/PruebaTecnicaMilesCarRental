namespace MilesCarRental_WEB.Models
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
