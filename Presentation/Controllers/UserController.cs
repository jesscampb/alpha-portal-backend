using Infrastructure.Dtos;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost]
    public async Task<IActionResult> Create(AddUserForm formData)
    {
        if (!ModelState.IsValid)
            return BadRequest(formData);

        var result = await _userService.CreateUserAsync(formData);

        return result == null ? BadRequest() : Ok(result);
    }
}
