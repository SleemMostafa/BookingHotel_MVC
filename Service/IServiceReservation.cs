using BookingHotel_MVC.Models;

namespace BookingHotel_MVC.Service
{
    public interface IServiceReservation
    {
        List<Reservation> GetReservationsForGuest(string guestId);
        ReservationRoomModel AddTempRoom(ReservationRoomModel model);
        bool CheckIfTempRoomExit(int roomId, string guestId);
        List<ReservationRoomModel> GetAllTempForGuest(string guestId);
    }
}
