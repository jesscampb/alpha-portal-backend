using Infrastructure.Data.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ProjectStatusFactory
{
    public static ProjectStatusModel ToModel(ProjectStatusEntity entity)
    {
        if (entity == null) return null!;

        return new ProjectStatusModel
        {
            Id = entity.Id,
            StatusName = entity.StatusName
        };
    }

    public static ProjectStatusEntity ToEntity(ProjectStatusModel model)
    {
        if (model == null) return null!;

        return new ProjectStatusEntity
        {
            Id = model.Id,
            StatusName = model.StatusName
        };
    }
}

