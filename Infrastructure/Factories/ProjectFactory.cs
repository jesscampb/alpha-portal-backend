using Infrastructure.Data.Entities;
using Infrastructure.Dtos;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ProjectFactory
{
    public static ProjectEntity ToEntity(AddProjectForm formData, string? newImageFileName = null)
    {
        if (formData == null) return null!;

        return new ProjectEntity
        {
            ImageFileName = newImageFileName,
            ProjectName = formData.ProjectName,
            Description = formData.Description,
            StartDate = formData.StartDate,
            EndDate = formData.EndDate,
            Budget = formData.Budget,
            Client = new ClientEntity
            {
                Id = formData.ClientId
            },
            User = new UserEntity
            {
                Id = formData.UserId
            },
            Status = new ProjectStatusEntity
            {
                Id = 1
            }
        };
    }
}
