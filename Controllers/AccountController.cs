using BookingHotel_MVC.Helper;
using BookingHotel_MVC.Models;
using BookingHotel_MVC.Service;
using BookingHotel_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IServiceAccount accountService;

        public AccountController(IServiceAccount accountService)
        {
            this.accountService = accountService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                ResponseAuth response = await accountService.Register(model);
                if (response.IsAuthenticated)
                {
                    Response.Cookies.Append("token", response.Token);
                    Response.Cookies.Append("userId", response.Id);
                    return RedirectToAction("Index","Branch");
                }
                return View(response);
            }
            return View(model);
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                ResponseAuth response = await accountService.Login(model);
                if (response.IsAuthenticated)
                {
                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTimeOffset.Now.AddMonths(1);
                    Response.Cookies.Append("token", response.Token,cookieOptions);
                    Response.Cookies.Append("userId", response.Id);
                    return RedirectToAction("Index", "Branch");
                }
                return View(response);
            }
            return View(model);
        }
    }
}
