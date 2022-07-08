using BookingHotel_MVC.Models;

namespace BookingHotel_MVC.Service
{
    public class ReservationService:IServiceReservation
    {
        string baseUrl = "https://localhost:7212/";
        HttpClient httpClient = new HttpClient();
        public List<Reservation> GetReservationsForGuest(string guestId)
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponse = httpClient.GetAsync("api/Reservation/ReservationDetailsForGuest/"+guestId).Result;
            List<Reservation> reservations = httpResponse.Content.ReadAsAsync<List<Reservation>>().Result;
            return reservations;
        }
    }
}
