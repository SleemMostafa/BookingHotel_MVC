using BookingHotel_MVC.Models;
using BookingHotel_MVC.Service;
using BookingHotel_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingHotel_MVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IServiceReservation serviceReservation;

        public ReservationController(IServiceReservation serviceReservation)
        {
            this.serviceReservation = serviceReservation;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OpenEditReservation(int id)
        {
            var data = serviceReservation.GetTempRoomByID(id);
            return View(data);
        }
        public IActionResult EditReservation(int id, ReservationRoomModel reservationRoomModel)
        {
            var response = serviceReservation.EditTempRoom(id, reservationRoomModel);
            if (response > 0)
            {
                return RedirectToAction("GetAllTempGuest");
            }
            else
            {
                var data = serviceReservation.GetTempRoomByID(id);

                return View("OpenEditReservation", data);
            }
        }
        public IActionResult SetRoomInfo(int roomId, int branchId)
        {
            TempData["RoomId"] = roomId;
            TempData["BranchId"] = branchId;
            string userId = Request.Cookies["userId"];
            if (userId != null)
            {
                if (!serviceReservation.CheckIfTempRoomExit(roomId, userId))
                {
                    return Json(false);
                }
                return Json(true);
            }

            return Json("UnAuth");
        }
        public IActionResult OpenFormRoomInfo()
        {
            string userId = Request.Cookies["userId"];
            ViewBag.RoomId = int.Parse(TempData["RoomId"].ToString());
            ViewBag.BranchId = int.Parse(TempData["BranchId"].ToString());
            return View();
        }


        public IActionResult AddReservationInTempGuest(ReservationRoomModel model)
        {
            string userId = Request.Cookies["userId"];
            model.GuestId = userId;
            model.NumberOfDays = model.DateOut.Day - model.DateIn.Day;
            if (ModelState.IsValid)
            {
                var data = serviceReservation.AddTempRoom(model);
                if (data != null)
                {
                    return RedirectToAction("GetAllRoomInOneBranch", "Room", new { branchId = model.BranchId });
                }
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult AddReservation()
        {
            string guestId = Request.Cookies["userId"];
            if (guestId != null)
            {
                var data = serviceReservation.GetAllTempForGuest(guestId);

                ReservationModel newReservation = new ReservationModel();
                newReservation.Guest_Id = guestId;
                foreach (var item in data)
                {
                    newReservation.ReservationRoomInfo.Add(item);
                }
                Reservation response = serviceReservation.AddReservation(newReservation);
                if (response.Status)
                {
                    return View(data);
                }
                else
                {
                    return RedirectToAction("GetReservationsForGuest", "Reservation");
                }
            }
            return RedirectToAction("Login", "Account");

        }


        [HttpGet]
        public IActionResult GetReservationsForGuest()
        {
            string guestId = Request.Cookies["userId"];
            var data = serviceReservation.GetReservationsForGuest(guestId);
            if (data != null)
            {
                return View(data);
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetAllTempGuest()
        {
            string guestId = Request.Cookies["userId"];
            if (guestId != null)
            {


                var data = serviceReservation.GetAllTempForGuest(guestId);
                if (data != null)
                {
                    return View(data);
                }
                return BadRequest();
            }
            return RedirectToAction("Login", "Account");
        }
        public IActionResult DeleteTempGuestRoom(int id)
        {
            var data = serviceReservation.DeleteFromTempGuest(id);
                if(data.Status)
            {
                return Json(data);
            }
            return Json(data);
        }
    }
}