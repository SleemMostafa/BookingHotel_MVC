using System.ComponentModel.DataAnnotations;

namespace BookingHotel_MVC.Models
{
    public class ReservationRoomModel
    {
        public string? GuestId { get; set; }
        public int? BranchId { get; set; }
        public int? RoomId { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime DateIn { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime DateOut { get; set; }
        public int? NumberOfDays { get; set; }

    }
}
