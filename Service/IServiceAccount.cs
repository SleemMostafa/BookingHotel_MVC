using BookingHotel_MVC.Models;
using BookingHotel_MVC.ViewModel;

namespace BookingHotel_MVC.Service
{
    public interface IServiceAccount
    {
        Task<ResponseAuth> Register(Register model);
        Task<ResponseAuth> Login(Login model);
        ResponseAuth AddRole(Role model);
    }
}
