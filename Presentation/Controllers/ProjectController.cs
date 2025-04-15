using Infrastructure.Dtos;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpPost]
    public async Task<IActionResult> Create(AddProjectForm formData)
    {
        if (!ModelState.IsValid)
            return BadRequest(formData);

        var result = await _projectService.CreateProjectAsync(formData);
        
        if (result == null)
            return BadRequest("Failed to create project");

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _projectService.GetProjectByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _projectService.GetAllProjectsAsync();

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}
