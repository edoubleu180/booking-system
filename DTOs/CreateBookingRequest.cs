namespace BookingSystem.Api.DTOs;

public class CreateBookingRequest
{
    public string CustomerName { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
