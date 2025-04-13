using Infrastructure.Data.Repositories.Interfaces;
using Infrastructure.Dtos;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class ProjectService(IProjectRepository projectRepository)
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<ProjectModel> CreateProjectAsync(AddProjectForm formData)
    {

    }
}

// Create (add project form)
// Read (by id and all projects)
// Update (update project form)
// Delete