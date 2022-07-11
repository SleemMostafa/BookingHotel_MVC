using BookingHotel_MVC.Models;
using BookingHotel_MVC.ViewModel;
using System.Net.Http.Headers;

namespace BookingHotel_MVC.Service
{
    public class AccountService:IServiceAccount
    {
        string baseUrl = "https://localhost:7212/";
        HttpClient httpClient = new HttpClient();
        public ResponseAuth AddRole(Role model)
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseAuth> Login(Login model)
        {
            if (model != null)
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync<Login>("api/Auth/Login", model);
                ResponseAuth response = httpResponse.Content.ReadAsAsync<ResponseAuth>().Result;

                return response;
            }
            return new ResponseAuth { Message = "Error" ,IsAuthenticated=false};
        }
        public async Task<ResponseAuth> Register(Register model)
        {
            if (model != null)
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                //string token =  ;

                httpClient.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync<Register>("api/Auth/Register", model);
                ResponseAuth response = httpResponse.Content.ReadAsAsync<ResponseAuth>().Result;
                return response;
            }
            return new ResponseAuth { Message = "Error",IsAuthenticated=false};
        }
    }
}
