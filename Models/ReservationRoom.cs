using System.ComponentModel.DataAnnotations;

namespace BookingHotel_MVC.Models
{
    public class ReservationRoom
    {
        public int Id { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime DateIn { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime DateOut { get; set; }
        public  Reservation Reservation { get; set; }
        public double TotalPriceForOneRoom { get; set; }
        public  Room Room { get; set; }
    }
}
