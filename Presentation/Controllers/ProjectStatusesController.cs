using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectStatusesController(IProjectStatusService projectStatusService) : ControllerBase
{
    private readonly IProjectStatusService _projectStatusService = projectStatusService;

    /// <summary>
    /// Retrieves a project status by its ID.
    /// </summary>
    /// <param name="id">The status ID.</param>
    /// <returns>The requested project status.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _projectStatusService.GetProjectStatusByIdAsync(id);

        return result == null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Retrieves all project statuses.
    /// </summary>
    /// <returns>List of all project statuses.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _projectStatusService.GetAllProjectStatusesAsync();

        return result == null ? NotFound() : Ok(result);
    }
}
