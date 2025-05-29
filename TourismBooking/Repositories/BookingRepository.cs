using TourismBooking.Data;
using TourismBooking.Models;

namespace TourismBooking.Repositories
{
    public sealed class BookingRepository : Repository<Booking>
    {
        private readonly TourismBookingDbContext DbContext;
        public BookingRepository(TourismBookingDbContext Ctx) : base(Ctx)
        {
            DbContext = Ctx;
        }
    }
}
