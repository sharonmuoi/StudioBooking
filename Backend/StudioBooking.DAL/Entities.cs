namespace StudioBooking.DAL;
public class StudioService
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
}
public class Booking
{
    public int Id { get; set; }
    public string BookingCode { get; set; } = string.Empty;
    public int ServiceId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateOnly PreferredDate { get; set; }
    public decimal PriceSnapshot { get; set; }
    public string ServiceNameSnapshot { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public StudioService? Service { get; set; }
}

public class CustomerUser { public int Id { get; set; } public string FullName { get; set; } = ""; public string Email { get; set; } = ""; public string Phone { get; set; } = ""; public string PasswordHash { get; set; } = ""; public string Role { get; set; } = "Customer"; public DateTime CreatedAt { get; set; } = DateTime.UtcNow; }
