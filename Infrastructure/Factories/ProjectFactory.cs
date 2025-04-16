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

    public static ProjectEntity ToEntity(UpdateProjectForm formData, ProjectEntity entity, string? newImageFileName = null)
    {
        if (formData == null) return null!;
        if (entity == null) return null!;

        entity.ImageFileName = newImageFileName ?? formData.ExistingImageFileName;
        entity.ProjectName = (formData.ProjectName != entity.ProjectName) ? formData.ProjectName : entity.ProjectName;
        entity.Description = (formData.Description != entity.Description) ? formData.Description : entity.Description;
        entity.StartDate = (formData.StartDate != entity.StartDate) ? formData.StartDate : entity.StartDate;
        entity.EndDate = (formData.EndDate != entity.EndDate) ? formData.EndDate : entity.EndDate;
        entity.Budget = (formData.Budget != entity.Budget) ? formData.Budget : entity.Budget;
        entity.ClientId = (formData.ClientId != entity.ClientId) ? formData.ClientId : entity.ClientId;
        entity.UserId = (formData.UserId != entity.UserId) ? formData.UserId : entity.UserId;
        entity.StatusId = (formData.ProjectStatusId != entity.StatusId) ? formData.ProjectStatusId : entity.StatusId;

        return entity;
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
