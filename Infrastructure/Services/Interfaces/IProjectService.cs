using Infrastructure.Dtos;
using Infrastructure.Models;

namespace Infrastructure.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectModel?> CreateProjectAsync(AddProjectForm formData);
        Task<bool> DeleteProjectAsync(string id);
        Task<IEnumerable<ProjectModel>> GetAllProjectsAsync();
        Task<ProjectModel?> GetProjectByIdAsync(string id);
        Task<ProjectModel?> UpdateProjectAsync(UpdateProjectForm formData);
    }
}