using MilesCarRental_Api.Model;
using Newtonsoft.Json;

namespace MilesCarRental_Api.Controllers
{
    public class ReservationController
    {
        public async Task<Reservation> PostReservation(string apiUrl, Reservation reservation)
        {
            string apiUrlGetLocations = apiUrl + "Reservation/PostReservation";
            string requestBody = JsonConvert.SerializeObject(reservation);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(apiUrlGetLocations, new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    Reservation reservationresult = JsonConvert.DeserializeObject<Reservation>(responseData);

                    return reservationresult;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return new Reservation();
                }
            }
        }
    }
}
