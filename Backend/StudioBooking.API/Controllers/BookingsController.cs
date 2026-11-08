using Microsoft.AspNetCore.Mvc;
using StudioBooking.BUS;
using StudioBooking.DTO;
namespace StudioBooking.API.Controllers;
[ApiController, Route("api/bookings")]
public class BookingsController(BookingBus bus) : ControllerBase
{
    [HttpPost] public async Task<IActionResult> Create(CreateBookingRequest request)
    {
        try { var result=await bus.CreateAsync(request); return result is null ? NotFound(new { message="Không tìm thấy dịch vụ." }) : Created($"/api/bookings/{result.Id}",result); }
        catch(ArgumentException ex) { return BadRequest(new { message=ex.Message }); }
    }
}
