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
            ClientId = formData.ClientId,
            UserId = formData.UserId,
            StatusId = 1, // Default status, "STARTED"
        };
    }

    public static ProjectEntity ToEntity(UpdateProjectForm formData, string? newImageFileName = null)
    {
        if (formData == null) return null!;

        return new ProjectEntity
        {
            Id = formData.Id,
            ImageFileName = newImageFileName ?? formData.ExistingImageFileName,
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
                Id = formData.ProjectStatusId
            }
        };
    }

    public static ProjectModel ToModel(ProjectEntity entity)
    {
        if (entity == null) return null!;

        return new ProjectModel
        {
            Id = entity.Id,
            ImageFileName = entity.ImageFileName,
            ProjectName = entity.ProjectName,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Created = entity.Created,
            Budget = entity.Budget,
            Client = new ClientModel
            {
                Id = entity.Client.Id,
                ClientName = entity.Client.ClientName
            },
            User = new UserModel
            {
                Id = entity.User.Id,
                FirstName = entity.User.FirstName,
                LastName = entity.User.LastName
            },
            Status = new ProjectStatusModel
            {
                Id = entity.Status.Id,
                StatusName = entity.Status.StatusName
            }
        };
    }
}
