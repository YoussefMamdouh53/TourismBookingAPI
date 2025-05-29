namespace TourismBooking.DTO.Booking
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int DestinationId { get; set; }
        public string? DestinationName { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
