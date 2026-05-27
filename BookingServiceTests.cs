using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Models;
using BookingSystem.Core.Services;
using NSubstitute;

namespace BookingSystem.Tests;

public class BookingServiceTests
{
    [Fact]
    public async Task Should_Throw_When_Booking_Conflicts()
    {
        var repo = Substitute.For<IBookingRepository>();
        repo.GetByDateAsync(Arg.Any<DateTime>())
            .Returns(new List<Booking>
            {
                new Booking
                {
                    StartTime = new DateTime(2025, 1, 1, 10, 0, 0),
                    EndTime = new DateTime(2025, 1, 1, 11, 0, 0)
                }
            });

        var service = new BookingService(repo);

        var newBooking = new Booking
        {
            StartTime = new DateTime(2025, 1, 1, 10, 30, 0),
            EndTime = new DateTime(2025, 1, 1, 11, 30, 0)
        };

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.CreateBookingAsync(newBooking));
    }
}
