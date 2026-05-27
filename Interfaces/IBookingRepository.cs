using BookingSystem.Core.Models;

namespace BookingSystem.Core.Interfaces;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetByDateAsync(DateTime date);
    Task AddAsync(Booking booking);
    Task SaveChangesAsync();
}
