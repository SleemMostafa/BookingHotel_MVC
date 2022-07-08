using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingHotel_MVC.Models
{
    [Flags]
    public enum StatusRoom
    {
        Available,
        Booked,
    }
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public StatusRoom Status { get; set; }
        [Required]
        public  Branch Branch { get; set; }
        [Required]
        public  RoomType Room_Type { get; set; }
    }
}
