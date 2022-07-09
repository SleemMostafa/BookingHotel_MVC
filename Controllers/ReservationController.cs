using BookingHotel_MVC.Models;
using BookingHotel_MVC.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingHotel_MVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IServiceReservation serviceReservation;

        public ReservationController(IServiceReservation  serviceReservation)
        {
            this.serviceReservation = serviceReservation;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetRoomInfo(int roomId)
        {
            ViewBag.RoomId = roomId;
            return View();
        }
        public IActionResult AddReservation(ReservationRoomModel model)
        {
            string userId = Request.Cookies["userId"];
            model.GuestId = userId;
            model.NumberOfDays = model.DateIn.Day - model.DateOut.Day ;
            if (ModelState.IsValid)
            {
                var data =  serviceReservation.AddTempRoom(model);
                return  RedirectToAction("Index","Branch");
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetReservationsForGuest()
        {
            var guestId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = serviceReservation.GetReservationsForGuest("3f73164a-2ccb-4e5c-a5a4-abe8c836ef47");
            if(data != null)
            {
                return View(data);
            }
            return BadRequest();
        }
    }
}
