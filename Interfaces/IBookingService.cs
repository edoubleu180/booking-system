using BookingSystem.Core.Models;

namespace BookingSystem.Core.Interfaces;

public interface IBookingService
{
    Task<Booking> CreateBookingAsync(Booking booking);
    Task<IEnumerable<Booking>> GetBookingsByDateAsync(DateTime date);
}
