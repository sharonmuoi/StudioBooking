using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudioBooking.DAL;
namespace StudioBooking.API.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthController(StudioBookingDbContext db) : ControllerBase {
 private readonly PasswordHasher<CustomerUser> hasher = new();
 [HttpPost("register")] public async Task<IActionResult> Register(RegisterRequest request) {
  if(string.IsNullOrWhiteSpace(request.FullName)||string.IsNullOrWhiteSpace(request.Email)||string.IsNullOrWhiteSpace(request.Phone)||string.IsNullOrWhiteSpace(request.Password)) return BadRequest(new {message="Vui lòng nhập đầy đủ thông tin."});
  var email=request.Email.Trim().ToLowerInvariant();
  if(!System.Text.RegularExpressions.Regex.IsMatch(email,@"^[^\s@]+@[^\s@]+\.[^\s@]+$")) return BadRequest(new {message="Email không hợp lệ."});
  if(request.Password.Length<8) return BadRequest(new {message="Mật khẩu phải có ít nhất 8 ký tự."});
  if(await db.Users.AnyAsync(x=>x.Email==email)) return Conflict(new {message="Email này đã được đăng ký."});
  var user=new CustomerUser {FullName=request.FullName.Trim(),Email=email,Phone=request.Phone.Trim()}; user.PasswordHash=hasher.HashPassword(user,request.Password); db.Users.Add(user); await db.SaveChangesAsync();
  return Ok(new {message="Đăng ký thành công.",user=new {user.Id,user.FullName,user.Email,user.Phone,user.Role}});
 }
}
public record RegisterRequest(string FullName,string Email,string Phone,string Password);
