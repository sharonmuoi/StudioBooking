using System.ComponentModel.DataAnnotations;
namespace StudioBooking.DTO;
public sealed class CreateBookingRequest
{
    [Range(1, int.MaxValue)] public int ServiceId { get; set; }
    [Required, MaxLength(150)] public string CustomerName { get; set; } = string.Empty;
    [Required, Phone, MaxLength(30)] public string Phone { get; set; } = string.Empty;
    [Required] public DateOnly PreferredDate { get; set; }
}
public sealed record BookingCreatedDto(int Id, string BookingCode, string Status);
