using Microsoft.AspNetCore.Mvc.Rendering;

namespace MilesCarRental_WEB.Models
{
    public class RentViewModel
    {
        public int SelectedLocationId { get; set; }

        public SelectList LocationsList { get; set; }

        public int SelectedDropOffLocationId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}
