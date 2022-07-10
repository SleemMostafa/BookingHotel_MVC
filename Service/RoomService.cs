using BookingHotel_MVC.Models;

namespace BookingHotel_MVC.Service
{
    public class RoomService : IServiceRoom
    {
        string baseUrl = "https://localhost:7212/";
        HttpClient httpClient = new HttpClient();
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
        public List<Room> GetAllForReport(string token)
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage httpResponse = httpClient.GetAsync("api/Room/GetAll").Result;
            List<Room> rooms = httpResponse.Content.ReadAsAsync<List<Room>>().Result;
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return null;
            }

            return rooms;
        }

        public List<Room> GetAll()
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponse = httpClient.GetAsync("api/Room/GetAllAvialable").Result;
            List<Room> rooms = httpResponse.Content.ReadAsAsync<List<Room>>().Result;
            return rooms;
        }

        public Room GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetRoomsByBranchId(int branchId)
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponse = httpClient.GetAsync("api/Room/GetRoomsByBranchId/"+branchId).Result;
            List<Room> rooms = httpResponse.Content.ReadAsAsync<List<Room>>().Result;
            return rooms;
        }
        public int Insert(Room item)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, Room item)
        {
            throw new NotImplementedException();
        }
    }
}
