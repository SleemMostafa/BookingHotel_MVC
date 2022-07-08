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
