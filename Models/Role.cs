using System.ComponentModel.DataAnnotations;

namespace BookingHotel_MVC.Models
{
    public class Role
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
