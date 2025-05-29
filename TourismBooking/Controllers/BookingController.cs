using Microsoft.AspNetCore.Mvc;
using TourismBooking.Data;
using TourismBooking.DTO.Booking;
using TourismBooking.Models;
using TourismBooking.Repositories;

namespace TourismBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly TourismBookingDbContext _context;
        private readonly DestinationRepository _destinationRepository;
        private readonly BookingRepository _bookingRepository;
        private readonly ILogger<BookingController> _logger;

        public BookingController(TourismBookingDbContext dbContext, ILogger<BookingController> logger)
        {
            _context = dbContext;
            _destinationRepository = new DestinationRepository(dbContext);
            _bookingRepository = new BookingRepository(dbContext);
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Book([FromBody] CreateBookingDTO bookDto)
        {
            var destination = await _destinationRepository.GetById(bookDto.DestinationId);
            if (destination is null)
            {
                return BadRequest("Destination doesn't exist");
            }

            Booking booking = new Booking
            {
                UserName = bookDto.UserName,
                Email = bookDto.Email,
                Date = bookDto.Date,
                Destination = destination
            };

            await _bookingRepository.Insert(booking);

            _context.SaveChanges();
            
            return Ok(booking.Id);
        }
        
        [HttpGet]
        public async Task<ActionResult> getAllBookings()
        {
            var bookings = await _bookingRepository.GetAll();
            return Ok(bookings.Select(booking => new BookingDTO() {
                Id = booking.Id,
                UserName = booking.UserName,
                Email = booking.Email,
                Date = booking.Date,
                DestinationName = _destinationRepository.GetById(booking.DestinationId).Result.Name,
                CreatedAt = booking.CreatedAt
            }));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> getBookingById(int id) {
            var booking = await _bookingRepository.GetById(id);
            if (booking is null) {
                return NotFound("Booking doesn't exist");
            }

            var destination = await _destinationRepository.GetById(booking.DestinationId);

            BookingDTO bookingDto = new BookingDTO()
            {
                Id = booking.Id,
                UserName = booking.UserName,
                Email = booking.Email,
                Date = booking.Date,
                DestinationName = destination.Name,
                CreatedAt = booking.CreatedAt
            };
            return Ok(bookingDto);
        }
    }
}
