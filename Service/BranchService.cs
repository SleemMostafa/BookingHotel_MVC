using BookingHotel_MVC.Models;

namespace BookingHotel_MVC.Service
{
    public class BranchService : IServiceBranch
    {
        string baseUrl = "https://localhost:7212/";
        HttpClient httpClient = new HttpClient();
        public  int Delete(int id)
        {
            throw new NotImplementedException();
        }
        public List<Branch> GetAll()
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponse = httpClient.GetAsync("api/Branch").Result;
            List<Branch> branches = httpResponse.Content.ReadAsAsync<List<Branch>>().Result;
            return branches;
        }

        public Branch GetById(int id)
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponse = httpClient.GetAsync("api/Branch/" + id).Result;
            Branch branch = httpResponse.Content.ReadAsAsync<Branch>().Result;
            return (branch);
        }

        public int Insert(Branch item)
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.PostAsJsonAsync<Branch>("api/Branch", item);
            return 1;
        }

        public int Update(int id, Branch item)
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.PostAsJsonAsync<Branch>("api/Branch", item);
            return 1;
        }
        public void SendToken(string token)
        {

        }
    }
}
