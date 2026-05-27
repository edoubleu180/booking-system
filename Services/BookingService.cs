using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Models;

namespace BookingSystem.Core.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _repo;

    public BookingService(IBookingRepository repo)
    {
        _repo = repo;
    }

    public async Task<Booking> CreateBookingAsync(Booking booking)
    {
        var existing = await _repo.GetByDateAsync(booking.StartTime);

        bool conflict = existing.Any(b =>
            booking.StartTime < b.EndTime &&
            booking.EndTime > b.StartTime
        );

        if (conflict)
            throw new InvalidOperationException("Time slot already booked.");

        await _repo.AddAsync(booking);
        await _repo.SaveChangesAsync();

        return booking;
    }

    public Task<IEnumerable<Booking>> GetBookingsByDateAsync(DateTime date) =>
        _repo.GetByDateAsync(date);
}
