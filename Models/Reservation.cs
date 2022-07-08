namespace BookingHotel_MVC.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public double TotalPrice { get; set; }
        public  ICollection<ReservationRoom> ReservationRooms { get; set; }
    }
}
