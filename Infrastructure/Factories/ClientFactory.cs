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

    public static ClientEntity ToEntity(UpdateClientForm formData, string? newImageFileName = null)
    {
        if (formData == null) return null!;

        return new ClientEntity
        {
            Id = formData.Id,
            ImageFileName = newImageFileName ?? formData.ExistingImageFileName,
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
