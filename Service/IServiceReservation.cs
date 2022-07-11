using BookingHotel_MVC.Models;
using BookingHotel_MVC.ViewModel;

namespace BookingHotel_MVC.Service
{
    public interface IServiceReservation
    {
        List<Reservation> GetReservationsForGuest(string guestId);
        ReservationRoomModel AddTempRoom(ReservationRoomModel model);
        bool CheckIfTempRoomExit(int roomId, string guestId);
        List<ReservationRoomModel> GetAllTempForGuest(string guestId);
        Reservation AddReservation(ReservationModel model);
    }
}
