using MilesCarRental_Api.Model;
using Newtonsoft.Json;

namespace MilesCarRental_Api.Controllers
{
    public class LocationController
    {
        public async Task<List<Location>> GetLocations(string apiUrl)
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

        public async Task<List<Location>> GetDropOffLocations(string apiUrl,string locationId)
        {
            string apiUrlGetDropOffLocations = apiUrl + "Location/GetDropOffLocations?locationId=" + locationId;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrlGetDropOffLocations);

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
    }
}
