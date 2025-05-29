using System.ComponentModel.DataAnnotations;

namespace TourismBooking.DTO.Booking
{
    public class CreateBookingDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int DestinationId { get; set; }
        public DateTime Date { get; set; }
    }
}
