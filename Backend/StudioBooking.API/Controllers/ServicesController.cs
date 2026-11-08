using Microsoft.AspNetCore.Mvc;
using StudioBooking.BUS;
namespace StudioBooking.API.Controllers;
[ApiController, Route("api/services")]
public class ServicesController(StudioServiceBus bus) : ControllerBase
{
    [HttpGet] public async Task<IActionResult> GetAll() => Ok(await bus.GetAllAsync());
    [HttpGet("{id:int}")] public async Task<IActionResult> GetById(int id) { var item=await bus.GetByIdAsync(id); return item is null ? NotFound() : Ok(item); }
}
