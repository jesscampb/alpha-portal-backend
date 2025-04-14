using Infrastructure.Data.Entities;
using Infrastructure.Dtos;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class UserFactory
{
    public static UserEntity ToEntity(AddUserForm formData, string? newImageFileName = null)
    {
        if (formData == null) return null!;

        return new UserEntity
        {
            ImageFileName = newImageFileName,
            FirstName = formData.FirstName,
            LastName = formData.LastName,
            Email = formData.Email,
            PhoneNumber = formData.PhoneNumber,
            JobTitle = formData.JobTitle,
            UserName = formData.Email,
            Address = new UserAddressEntity
            {
                StreetName = formData.StreetName ?? null!,
                PostalCode = formData.PostalCode ?? null!,
                City = formData.City ?? null!
            }
        };
    }

    public static UserEntity ToEntity(UpdateUserForm formData, string? newImageFileName = null)
    {
        if (formData == null) return null!;

        return new UserEntity
        {
            Id = formData.Id,
            ImageFileName = newImageFileName ?? formData.ExistingImageFileName,
            FirstName = formData.FirstName,
            LastName = formData.LastName,
            Email = formData.Email,
            PhoneNumber = formData.PhoneNumber,
            JobTitle = formData.JobTitle,
            UserName = formData.Email,
            Address = new UserAddressEntity
            {
                StreetName = formData.StreetName ?? String.Empty,
                PostalCode = formData.PostalCode ?? String.Empty,
                City = formData.City ?? String.Empty
            }
        };
    }

    public static UserModel ToModel(UserEntity entity)
    {
        if (entity == null) return null!;

        return new UserModel
        {
            Id = entity.Id,
            ImageFileName = entity.ImageFileName,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email!,
            PhoneNumber = entity.PhoneNumber,
            JobTitle = entity.JobTitle,
            StreetName = entity.Address?.StreetName ?? String.Empty,
            PostalCode = entity.Address?.PostalCode ?? String.Empty,
            City = entity.Address?.City ?? String.Empty,
        };
    }
}
