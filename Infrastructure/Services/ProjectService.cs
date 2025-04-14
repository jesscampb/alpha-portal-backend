using Infrastructure.Data.Repositories.Interfaces;
using Infrastructure.Dtos;
using Infrastructure.Factories;
using Infrastructure.Models;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ProjectService(IProjectRepository projectRepository)
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
}


// Create (add project form) *
// Read (by id and all projects)
// Update (update project form) *
// Delete