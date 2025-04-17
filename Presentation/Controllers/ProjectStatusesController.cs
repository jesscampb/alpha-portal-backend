using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectStatusesController(IProjectStatusService projectStatusService) : ControllerBase
{
    private readonly IProjectStatusService _projectStatusService = projectStatusService;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _projectStatusService.GetProjectStatusByIdAsync(id);

        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _projectStatusService.GetAllProjectStatusesAsync();

        return result == null ? NotFound() : Ok(result);
    }
}
