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
        
        return result == null ? Ok() : BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _projectService.GetProjectByIdAsync(id);

        return result == null ? Ok() : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _projectService.GetAllProjectsAsync();

        return result == null ? Ok() : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProjectForm formData)
    {
        if (!ModelState.IsValid)
            return BadRequest(formData);

        var result = await _projectService.UpdateProjectAsync(formData);

        return result == null ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _projectService.DeleteProjectAsync(id);

        return result ? Ok() : NotFound();
    }
}
