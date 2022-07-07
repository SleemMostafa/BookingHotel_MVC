namespace BookingHotel_MVC.Models
{
    public class ReservationDto
    {
        public List<ReservationRoomDto> ReservationRoomInfo { get; set; } = new List<ReservationRoomDto>();
        public string Guest_Id { get; set; }
    }
}
