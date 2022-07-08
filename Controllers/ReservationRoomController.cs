using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_MVC.Controllers
{
    public class ReservationRoomController : Controller
    {
        public ReservationRoomController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
