using CSV_Import.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSV_Import.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    public async Task<IActionResult> ImportPersonData(IFormFile file)
    {
        if (file == null)
        {
            //if file was not submitted go to index page
            return Redirect("Index");
        }
        return Ok(await _userService.AddUsers(file));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] bool asc=true, [FromQuery] int limit = 10, [FromQuery] int offset = 1)
    {
        return Ok(await _userService.GetUsers(limit,offset,asc));
    }
}