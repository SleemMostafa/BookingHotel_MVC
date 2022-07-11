using BookingHotel_MVC.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_MVC.Controllers
{
    public class RoomController : Controller
    {
        private readonly IServiceRoom serviceRoom;

        public RoomController(IServiceRoom serviceRoom)
        {
            this.serviceRoom = serviceRoom;
        }
        public IActionResult GetAllForReport()
        {
            string token  = Request.Cookies["token"];

            var data = serviceRoom.GetAllForReport(token);
            if(data == null)
            {
                return RedirectToAction("Login", "Account");
            }
            
            return View(data);
        }
        public IActionResult Index()
        {
            return View(serviceRoom.GetAll());
        }

        [HttpGet]
        public IActionResult GetAllRoomInOneBranch(int branchId)
        
        {
            var rooms = serviceRoom.GetRoomsByBranchId(branchId);
            if(rooms != null)
            {
                return View(rooms);
            }
            return BadRequest();
        }
    }
}
