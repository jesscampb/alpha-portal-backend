using Infrastructure.Data.Repositories.Interfaces;
using Infrastructure.Dtos;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Services.Interfaces;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<ProjectModel?> CreateProjectAsync(AddProjectForm formData)
    {
        if (formData == null) return null;

        try
        {
            var entity = ProjectFactory.ToEntity(formData);
            await _projectRepository.AddAsync(entity);

            var model = ProjectFactory.ToModel(entity);
            return model;


        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<ProjectModel?> UpdateProjectAsync(UpdateProjectForm formData)
    {
        if (formData == null) return null;

        try
        {
            var entity = ProjectFactory.ToEntity(formData);
            await _projectRepository.UpdateAsync(entity);

            var model = ProjectFactory.ToModel(entity);
            return model;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<bool> DeleteProjectAsync(string id)
    {
        try
        {
            var entity = await _projectRepository.GetAsync(x => x.Id == id);
            if (entity == null) return false;
            await _projectRepository.DeleteAsync(entity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<ProjectModel?> GetProjectByIdAsync(string id)
    {
        if (string.IsNullOrEmpty(id)) return null;

        try
        {
            var entity = await _projectRepository.GetAsync(x => x.Id == id, i => i.Client, i => i.User, i => i.Status);
            if (entity == null) return null;

            var model = ProjectFactory.ToModel(entity);
            return model;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<ProjectModel>> GetAllProjectsAsync()
    {
        try
        {
            var entities = await _projectRepository.GetAllAsync(
                orderByDescending: true,
                sortByExpression: i => i.Created,
                filterByExpression: null,
                i => i.Client,
                i => i.User,
                i => i.Status);

            if (entities == null || !entities.Any()) return Enumerable.Empty<ProjectModel>();

            var models = entities.Select(ProjectFactory.ToModel).ToList();
            return models;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Enumerable.Empty<ProjectModel>();
        }
    }
}
