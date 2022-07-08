using System.ComponentModel.DataAnnotations;

namespace BookingHotel_MVC.Models
{
    [Flags]
    public enum TypeOfRoom
    {
        Single,
        Double,
        Suite
    }
    public class RoomType
    {
        public int Id { get; set; }
        [Required]
        public TypeOfRoom TypeRoom { get; set; }
        [Required]
        public int Capacity { get; set; }
    }
}
