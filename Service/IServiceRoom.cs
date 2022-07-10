using BookingHotel_MVC.Models;

namespace BookingHotel_MVC.Service
{
    public interface IServiceRoom:IService<Room,int>
    {
        List<Room> GetRoomsByBranchId(int branchId);
        List<Room> GetAllForReport(string token);

    }
}
