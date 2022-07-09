using System.ComponentModel.DataAnnotations;

namespace BookingHotel_MVC.ViewModel
{
    public class RoomInfoFromGuest
    {
        public int Room_Id { get; set; }

        [DataType(DataType.Date), Required]
        public DateTime DateIn { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime DateOut { get; set; }
        public int NumberOfDays { get { return DateOut.Day - DateIn.Day; } set { } }
    }
}
