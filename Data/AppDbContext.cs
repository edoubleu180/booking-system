using BookingSystem.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Booking> Bookings => Set<Booking>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
