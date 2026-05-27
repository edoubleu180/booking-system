using BookingSystem.Api.DTOs;
using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _service;

    public BookingController(IBookingService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookingRequest request)
    {
        var booking = new Booking
        {
            CustomerName = request.CustomerName,
            StartTime = request.StartTime,
            EndTime = request.EndTime
        };

        try
        {
            var result = await _service.CreateBookingAsync(booking);
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpGet("{date}")]
    public async Task<IActionResult> GetByDate(DateTime date)
    {
        var bookings = await _service.GetBookingsByDateAsync(date);
        return Ok(bookings);
    }
}
