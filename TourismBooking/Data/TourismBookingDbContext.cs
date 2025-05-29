using Microsoft.EntityFrameworkCore;
using TourismBooking.Models;

namespace TourismBooking.Data
{
    public class TourismBookingDbContext : DbContext
    {
        public TourismBookingDbContext(DbContextOptions<TourismBookingDbContext> options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data (example)
            modelBuilder.Entity<Destination>().HasData(
                new Destination { Id = 1, Name = "Paris", Description = "The city of lights, art, and romance.", Location = "France", ImageUrl = "https://images.unsplash.com/photo-1502602898657-3e91760cbb34?q=80&w=1773&auto=format&fit=crop" },
                new Destination { Id = 2, Name = "Rome", Description = "Eternal city with ancient ruins and vibrant culture.", Location = "Italy", ImageUrl = "https://images.unsplash.com/photo-1529260830199-42c24126f198?q=80&w=1827&auto=format&fit=crop" },
                new Destination { Id = 3, Name = "Kyoto", Description = "Historic temples, serene gardens, and traditional tea houses.", Location = "Japan", ImageUrl = "https://images.unsplash.com/photo-1545569341-9eb8b30979d9?q=80&w=1770&auto=format&fit=crop" }
            );
        }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Destination> destinations { get; set; }
    }
}
