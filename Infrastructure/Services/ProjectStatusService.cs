using Infrastructure.Data.Repositories.Interfaces;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services;

public class ProjectStatusService(IProjectStatusRepository projectStatusRepository) : IProjectStatusService
{
    private readonly IProjectStatusRepository _projectStatusRepository = projectStatusRepository;

    public async Task<List<ProjectStatusModel>> GetAllProjectStatusesAsync()
    {
        var entities = await _projectStatusRepository.GetAllAsync();
        return entities.Select(ProjectStatusFactory.ToModel).ToList();
    }

    public async Task<ProjectStatusModel?> GetProjectStatusByIdAsync(int id)
    {
        var entity = await _projectStatusRepository.GetAsync(x => x.Id == id);

        if (entity == null) return null;

        return ProjectStatusFactory.ToModel(entity);
    }
}
