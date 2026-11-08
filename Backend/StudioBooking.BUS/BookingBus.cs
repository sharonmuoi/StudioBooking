using Microsoft.EntityFrameworkCore;
using StudioBooking.DAL;
using StudioBooking.DTO;
namespace StudioBooking.BUS;
public class BookingBus(StudioBookingDbContext db)
{
    public async Task<BookingCreatedDto?> CreateAsync(CreateBookingRequest request)
    {
        var service = await db.Services.FirstOrDefaultAsync(x=>x.Id==request.ServiceId && x.IsActive);
        if(service is null) return null;
        if(request.PreferredDate < DateOnly.FromDateTime(DateTime.Today)) throw new ArgumentException("Ngày đặt lịch không hợp lệ.");
        var booking = new Booking { BookingCode=$"SB{DateTime.UtcNow:yyyyMMddHHmmss}{Random.Shared.Next(100,999)}", ServiceId=service.Id, CustomerName=request.CustomerName.Trim(), Phone=request.Phone.Trim(), PreferredDate=request.PreferredDate, PriceSnapshot=service.Price, ServiceNameSnapshot=service.Name };
        db.Bookings.Add(booking); await db.SaveChangesAsync();
        return new BookingCreatedDto(booking.Id,booking.BookingCode,booking.Status);
    }
}
