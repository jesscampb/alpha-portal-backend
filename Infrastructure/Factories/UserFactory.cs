using Infrastructure.Data.Entities;
using Infrastructure.Dtos;

namespace Infrastructure.Factories
{
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
                ImageFileName = newImageFileName ?? formData.ExistingImageFileName,
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
    }
}
