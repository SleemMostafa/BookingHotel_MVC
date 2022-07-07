using BookingHotel_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_MVC.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ReservationDto model)
        {
            return RedirectToAction("Index");
        }
    }
}
