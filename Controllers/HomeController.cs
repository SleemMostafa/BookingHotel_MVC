using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
