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

    public static UserEntity ToEntity(UpdateUserForm formData, UserEntity entity, string? newImageFileName = null)
    {
        if (formData == null) return null!;
        if (entity == null) return null!;

        entity.ImageFileName = newImageFileName ?? formData.ExistingImageFileName;
        entity.FirstName = (formData.FirstName != entity.FirstName)? formData.FirstName : entity.FirstName;
        entity.LastName = (formData.LastName != entity.LastName) ? formData.LastName : entity.LastName;
        entity.Email = (formData.Email != entity.Email) ? formData.Email : entity.Email;
        entity.PhoneNumber = (formData.PhoneNumber != entity.PhoneNumber) ? formData.PhoneNumber : entity.PhoneNumber;
        entity.JobTitle = (formData.JobTitle != entity.JobTitle) ? formData.JobTitle : entity.JobTitle;
        entity.UserName = (formData.Email != entity.Email) ? formData.Email : entity.Email;

        if (entity.Address != null)
        {
            entity.Address.StreetName = (formData.StreetName != entity.Address.StreetName) ? formData.StreetName : entity.Address.StreetName;
            entity.Address.PostalCode = (formData.PostalCode != entity.Address.PostalCode) ? formData.PostalCode : entity.Address.PostalCode;
            entity.Address.City = (formData.City != entity.Address.City) ? formData.City : entity.Address.City;
        }

        return entity;
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
            StreetName = entity.Address?.StreetName ?? string.Empty,
            PostalCode = entity.Address?.PostalCode ?? string.Empty,
            City = entity.Address?.City ?? string.Empty,
        };
    }
}
