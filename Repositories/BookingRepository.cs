using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Models;
using BookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _db;

    public BookingRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Booking>> GetByDateAsync(DateTime date) =>
        await _db.Bookings
            .Where(b => b.StartTime.Date == date.Date)
            .ToListAsync();

    public async Task AddAsync(Booking booking) =>
        await _db.Bookings.AddAsync(booking);

    public async Task SaveChangesAsync() =>
        await _db.SaveChangesAsync();
}
