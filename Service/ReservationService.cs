using BookingHotel_MVC.Models;
using BookingHotel_MVC.ViewModel;

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
        public List<ReservationRoomModel> GetAllTempForGuest(string guestId)
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponse = httpClient.GetAsync($"api/TempGuestRoom/GetAllTempByGuestId?guestId={guestId}").Result;
            List<ReservationRoomModel> tempReservations = httpResponse.Content.ReadAsAsync<List<ReservationRoomModel>>().Result;
            return tempReservations;
        }
        public ReservationRoomModel AddTempRoom(ReservationRoomModel  model)
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponse = httpClient.PostAsJsonAsync<ReservationRoomModel>("api/TempGuestRoom", model).Result;
            ReservationRoomModel tempGuestRoom = httpResponse.Content.ReadAsAsync<ReservationRoomModel>().Result;
            return tempGuestRoom;
        }
        public bool CheckIfTempRoomExit(int roomId, string guestId)
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponse = httpClient.GetAsync("api/TempGuestRoom?roomId="+roomId+"&"+"guestId="+guestId).Result;
            bool roomIsExist = httpResponse.Content.ReadAsAsync<bool>().Result;
            return roomIsExist;
        }
        public Reservation AddReservation(ReservationModel model)
        {
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponse = httpClient.PostAsJsonAsync<ReservationModel>("api/Reservation", model).Result;
            Reservation response = httpResponse.Content.ReadAsAsync<Reservation>().Result;
            return response;
        }

    }
}
