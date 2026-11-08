using Microsoft.EntityFrameworkCore;
using StudioBooking.DAL;
using StudioBooking.DTO;
namespace StudioBooking.BUS;
public class StudioServiceBus(StudioBookingDbContext db)
{
    public async Task<List<ServiceDto>> GetAllAsync() => await db.Services.AsNoTracking().Where(x=>x.IsActive).OrderBy(x=>x.Id).Select(x=>new ServiceDto(x.Id,x.Name,x.Description,x.Price)).ToListAsync();
    public async Task<ServiceDto?> GetByIdAsync(int id) => await db.Services.AsNoTracking().Where(x=>x.Id==id && x.IsActive).Select(x=>new ServiceDto(x.Id,x.Name,x.Description,x.Price)).FirstOrDefaultAsync();
}
