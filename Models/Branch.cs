using System.ComponentModel.DataAnnotations;

namespace BookingHotel_MVC.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; }
        [MaxLength(50), Required]
        public string Location { get; set; }
        [MaxLength(50), Required]
        public string City { get; set; }

    }
}
