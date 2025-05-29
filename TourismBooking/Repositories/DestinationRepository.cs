using TourismBooking.Data;
using TourismBooking.Models;

namespace TourismBooking.Repositories
{
    public sealed class DestinationRepository : Repository<Destination>
    {
        private readonly TourismBookingDbContext DbContext;
        public DestinationRepository(TourismBookingDbContext Ctx) : base(Ctx)
        {
            DbContext = Ctx;
        }
    }
}
