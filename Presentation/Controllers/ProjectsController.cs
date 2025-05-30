using Infrastructure.Dtos;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    /// <summary>
    /// Creates a new project.
    /// </summary>
    /// <param name="formData">Project data to add.</param>
    /// <returns>Status indicating success or failure of project creation.</returns>
    [HttpPost]
    public async Task<IActionResult> Create(AddProjectForm formData)
    {
        if (!ModelState.IsValid)
            return BadRequest(formData);

        var result = await _projectService.CreateProjectAsync(formData);
        
        return result ? Ok(result) : BadRequest();
    }

    /// <summary>
    /// Retrieves a project by its ID.
    /// </summary>
    /// <param name="id">The project's ID.</param>
    /// <returns>The requested project.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _projectService.GetProjectByIdAsync(id);

        return result == null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Retrieves all projects.
    /// </summary>
    /// <returns>List of all projects.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _projectService.GetAllProjectsAsync();

        return result == null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Updates a project's details.
    /// </summary>
    /// <param name="formData">Updated project data.</param>
    /// <returns>Status indicating success or failure of update operation.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateProjectForm formData)
    {
        if (!ModelState.IsValid)
            return BadRequest(formData);

        var result = await _projectService.UpdateProjectAsync(formData);

        return result ? Ok(result) : BadRequest();
    }

    /// <summary>
    /// Deletes a project by its ID.
    /// </summary>
    /// <param name="id">The project's ID.</param>
    /// <returns>Status indicating success or failure of deletion.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _projectService.DeleteProjectAsync(id);

        return result ? Ok(result) : NotFound();
    }
}
