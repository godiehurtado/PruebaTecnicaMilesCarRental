using MilesCarRental_Api.Model;
using Newtonsoft.Json;

namespace MilesCarRental_Api.Controllers
{
    public class VehicleController
    {
        public async Task<List<VehicleCategory>> GetVehicleTypeEnables(string apiUrl, string locationId, string pickupDate, string dropoffDate)
        {
            string apiUrlGetLocations = apiUrl + "Vehicle/GetVehicleTypeEnables?locationId=" + locationId + "&pickupDate=" + pickupDate + "&dropoffDate=" + dropoffDate;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrlGetLocations);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    List<VehicleCategory> vehiclecategory = JsonConvert.DeserializeObject<List<VehicleCategory>>(responseData);

                    return vehiclecategory;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return new List<VehicleCategory>();
                }
            }
        }

        public async Task<Vehicle> GetVehicleEnable(string apiUrl, string locationId, string pickupDate, string dropoffDate, string categoryId)
        {
            string apiUrlGetLocations = apiUrl + "Vehicle/GetVehicleEnable?locationId=" + locationId + "&pickupDate=" + pickupDate + "&dropoffDate=" + dropoffDate + "&categoryId=" + categoryId;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrlGetLocations);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    Vehicle vehicle = JsonConvert.DeserializeObject<Vehicle>(responseData);

                    return vehicle;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return new Vehicle();
                }
            }
        }
    }
}
