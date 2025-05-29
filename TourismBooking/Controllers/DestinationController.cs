using Microsoft.AspNetCore.Mvc;
using TourismBooking.Data;
using TourismBooking.Repositories;

namespace TourismBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DestinationController : ControllerBase
    {
        private readonly TourismBookingDbContext _context;
        private readonly DestinationRepository _destinationRepository;
        private readonly ILogger<DestinationController> _logger;

        public DestinationController(TourismBookingDbContext dbContext, ILogger<DestinationController> logger) { 
            _context = dbContext;
            _destinationRepository = new DestinationRepository(dbContext);
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _destinationRepository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {   
            var destination = await _destinationRepository.GetById(id);
            if (destination is null) { 
                return NotFound();
            }

            return Ok(destination);
        }
    }
}
