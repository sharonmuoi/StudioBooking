using Microsoft.EntityFrameworkCore;
namespace StudioBooking.DAL;
public class StudioBookingDbContext(DbContextOptions<StudioBookingDbContext> options) : DbContext(options)
{
    public DbSet<StudioService> Services => Set<StudioService>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<CustomerUser> Users => Set<CustomerUser>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudioService>().Property(x => x.Price).HasPrecision(18,2);
        modelBuilder.Entity<CustomerUser>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<Booking>().Property(x => x.PriceSnapshot).HasPrecision(18,2);
        modelBuilder.Entity<Booking>().HasIndex(x => x.BookingCode).IsUnique();
        modelBuilder.Entity<Booking>().HasOne(x => x.Service).WithMany().HasForeignKey(x => x.ServiceId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<StudioService>().HasData(
            new StudioService { Id=1, Name="Chụp ảnh chân dung", Description="Gói chụp cá nhân trong studio, phù hợp hồ sơ và thương hiệu cá nhân.", Price=1200000 },
            new StudioService { Id=2, Name="Chụp ảnh couple", Description="Lưu giữ câu chuyện của hai bạn với concept được tư vấn riêng.", Price=2200000 },
            new StudioService { Id=3, Name="Chụp ảnh sự kiện", Description="Ghi lại những khoảnh khắc đáng nhớ trong sự kiện của bạn.", Price=3500000 });
    }
}
