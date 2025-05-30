using Infrastructure.Dtos;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions.Attributes;

namespace Presentation.Controllers;

[AdminApiKey]
[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="formData">User data to add.</param>
    /// <returns>The newly created user.</returns>
    [HttpPost]
    public async Task<IActionResult> Create(AddUserForm formData)
    {
        if (!ModelState.IsValid)
            return BadRequest(formData);

        var result = await _userService.CreateUserAsync(formData);

        return result == null ? BadRequest() : Ok(result);
    }


    /// <summary>
    /// Retrieves a user by ID.
    /// </summary>
    /// <param name="id">The user's ID.</param>
    /// <returns>The requested user.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _userService.GetUserByIdAsync(id);

        return result == null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Retrieves all users.
    /// </summary>
    /// <returns>List of all users.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _userService.GetAllUsersAsync();

        return result == null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Updates a user's details.
    /// </summary>
    /// <param name="formData">Updated user data.</param>
    /// <returns>Status indicating success or failure of update operation.</returns>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateUserForm formData)
    {
        if (!ModelState.IsValid)
            return BadRequest(formData);

        var result = await _userService.UpdateUserAsync(formData);

        return result ? Ok(result) : BadRequest();
    }

    /// <summary>
    /// Deletes a user by its ID.
    /// </summary>
    /// <param name="id">The user's ID.</param>
    /// <returns>Status indicating success or failure of deletion.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _userService.DeleteUserAsync(id);

        return result ? Ok(result) : NotFound();
    }
}
