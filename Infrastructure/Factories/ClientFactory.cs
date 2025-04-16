using Infrastructure.Data.Entities;
using Infrastructure.Dtos;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ClientFactory
{
    public static ClientEntity ToEntity(AddClientForm formData, string? newImageFileName = null)
    {
        if (formData == null) return null!;

        return new ClientEntity
        {
            ImageFileName = newImageFileName,
            ClientName = formData.ClientName,
            Email = formData.Email,
            PhoneNumber = formData.PhoneNumber,
            Reference = formData.Reference,
            Address = new ClientAddressEntity
            {
                StreetName = formData.StreetName,
                PostalCode = formData.PostalCode,
                City = formData.City
            },
        };
    }

    public static ClientEntity ToEntity(UpdateClientForm formData, ClientEntity entity, string? newImageFileName = null)
    {
        if (formData == null) return null!;
        if (entity == null) return null!;

        entity.ImageFileName = newImageFileName ?? formData.ExistingImageFileName;
        entity.ClientName = (formData.ClientName != entity.ClientName)? formData.ClientName : entity.ClientName;
        entity.Email = (formData.Email != entity.Email)? formData.Email : entity.Email;
        entity.PhoneNumber = (formData.PhoneNumber != entity.PhoneNumber)? formData.PhoneNumber : entity.PhoneNumber;
        entity.Reference = (formData.Reference != entity.Reference)? formData.Reference : entity.Reference;

        if (entity.Address != null)
        {
            entity.Address.StreetName = (formData.StreetName != entity.Address.StreetName) ? formData.StreetName : entity.Address.StreetName;
            entity.Address.PostalCode = (formData.PostalCode != entity.Address.PostalCode) ? formData.PostalCode : entity.Address.PostalCode;
            entity.Address.City = (formData.City != entity.Address.City) ? formData.City : entity.Address.City;
        }

        return entity;
    }

    public static ClientModel ToModel(ClientEntity entity)
    {
        if (entity == null) return null!;

        return new ClientModel
        {
            Id = entity.Id,
            ImageFileName = entity.ImageFileName,
            ClientName = entity.ClientName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            Reference = entity.Reference,
            StreetName = entity.Address.StreetName,
            PostalCode = entity.Address.PostalCode,
            City = entity.Address.City
        };
    }
}
