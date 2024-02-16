using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MilesCarRental_WEB.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MilesCarRental_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";        

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            apiUrl = _configuration["ApiUrl"];
            
            
        }

        public async Task<IActionResult> Index()
        {
            RentViewModel viewModel = new RentViewModel();

            List<Location> locations = await ObtenerListaDeUbicaciones();

            viewModel.LocationsList = new SelectList(locations, "LocationId", "LocationName");
            viewModel.SelectedLocationId = 0;

            Reservation reservation = new Reservation();
            TempData["GlobalReservation"] = JsonConvert.SerializeObject(reservation);
            TempData["GlobalLocations"] = JsonConvert.SerializeObject(locations);

            return View(viewModel);
        }

        private async Task<List<Location>> ObtenerListaDeUbicaciones()
        {
            string apiUrlGetLocations = apiUrl + "Location/GetLocations";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrlGetLocations);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    List<Location> locations = JsonConvert.DeserializeObject<List<Location>>(responseData);

                    return locations;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return new List<Location>();
                }
            }
        }

        public async Task<IActionResult> GetDropOffLocationData(int locationId)
        {
            Reservation reservation = JsonConvert.DeserializeObject<Reservation>(TempData["GlobalReservation"].ToString());
            reservation.PickUpLocationId = locationId;
            TempData["GlobalReservation"] = JsonConvert.SerializeObject(reservation);
            string apiUrlGetLocations = apiUrl + "Location/GetDropOffLocations?locationId=" + locationId;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrlGetLocations);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    List<Location> locations = JsonConvert.DeserializeObject<List<Location>>(responseData);

                    return Json(locations);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return Json(new List<Location>());
                }
            }
        }

        public async Task<IActionResult> GetVehicleTypeEnables(int locationId, int dropoffLocationId, string startDate, string endDate)
        {
            Reservation reservation = JsonConvert.DeserializeObject<Reservation>(TempData["GlobalReservation"].ToString());
            reservation.DropOffLocationId = dropoffLocationId;
            string format = "MM/dd/yyyy";
            DateTime _startDate = DateTime.ParseExact(startDate, format, System.Globalization.CultureInfo.InvariantCulture);
            DateTime _endDate = DateTime.ParseExact(endDate, format, System.Globalization.CultureInfo.InvariantCulture);

            reservation.StartDate = _startDate;
            reservation.EndDate = _endDate;
            TempData["GlobalReservation"] = JsonConvert.SerializeObject(reservation);
            string apiUrlGetLocations = apiUrl + "Vehicle/GetVehicleTypeEnables?locationId=" + locationId + "&pickupDate=" + startDate + "&dropoffDate=" + endDate;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrlGetLocations);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    List<VehicleCategory> vehiclecategory = JsonConvert.DeserializeObject<List<VehicleCategory>>(responseData);

                    return Json(vehiclecategory);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return Json(new List<VehicleCategory>());
                }
            }
        }

        public async Task<IActionResult> GetVehicleEnable(int locationId, int dropoffLocationId, string startDate, string endDate, int categoryId)
        {
            string apiUrlGetLocations = apiUrl + "Vehicle/GetVehicleEnable?locationId=" + locationId + "&pickupDate=" + startDate + "&dropoffDate=" + endDate + "&categoryId=" + categoryId;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrlGetLocations);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    Vehicle vehicle = JsonConvert.DeserializeObject<Vehicle>(responseData);
                    Reservation reservation = JsonConvert.DeserializeObject<Reservation>(TempData["GlobalReservation"].ToString());
                    reservation.Vehicle = vehicle;
                    reservation.VehicleId = vehicle.VehicleId;
                    TempData["GlobalReservation"] = JsonConvert.SerializeObject(reservation);

                    return Json(vehicle);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return Json(new Vehicle());
                }
            }
        }

        public async Task<IActionResult> PostReservation(string customerName, string customerLicence, string customerPhone, string VehicleId)
        {
            Reservation reservation = JsonConvert.DeserializeObject<Reservation>(TempData["GlobalReservation"].ToString());
            Customer customer = new Customer();
            customer.Name = customerName;
            customer.Licence = customerLicence;
            customer.Document = customer.Licence;
            customer.Phone = customerPhone;
            reservation.Customer = customer;
            string apiUrlGetLocations = apiUrl + "Reservation/PostReservation";
            string requestBody = JsonConvert.SerializeObject(reservation);
            TempData["GlobalReservation"] = JsonConvert.SerializeObject(reservation);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(apiUrlGetLocations, new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Reservation reservationResult = JsonConvert.DeserializeObject<Reservation>(responseData);
                    reservationResult.Vehicle = reservation.Vehicle;

                    List<Location> locations = JsonConvert.DeserializeObject<List<Location>>(TempData["GlobalLocations"].ToString());

                    string pickupLocation = locations.FirstOrDefault(x => x.LocationId == reservationResult.PickUpLocationId)?.LocationName;
                    string dropoffLocation = locations.FirstOrDefault(x => x.LocationId == reservationResult.DropOffLocationId)?.LocationName;

                    // Devolver la respuesta JSON con detalles de la reserva
                    return Json(new
                    {
                        reservationResult,
                        pickupLocation,
                        dropoffLocation
                    });
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return Json(new Reservation());
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}