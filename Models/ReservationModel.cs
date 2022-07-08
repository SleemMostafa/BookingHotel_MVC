namespace BookingHotel_MVC.Models
{
    public class ReservationModel
    {
        public List<ReservationRoomModel> ReservationRoomInfo { get; set; } = new List<ReservationRoomModel>();
        public string Guest_Id { get; set; }
    }
}
