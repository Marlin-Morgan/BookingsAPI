using BookingsAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookingsAPI.Infrustructure
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
        : base(options) { }

        public DbSet<Booking> Bookings => Set<Booking>();
    }
}
