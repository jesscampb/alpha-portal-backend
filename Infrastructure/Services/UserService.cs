using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.Interfaces;
using Infrastructure.Dtos;
using Infrastructure.Factories;
using Infrastructure.Models;
using System.Diagnostics;

namespace Infrastructure.Services;

public class UserService(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserModel?> CreateUserAsync(AddUserForm formData)
    {
        if (formData == null) return null;

        try
        {
            var entity = UserFactory.ToEntity(formData);
            await _userRepository.AddAsync(entity);

            var model = UserFactory.ToModel(entity);
            return model;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
    public async Task<UserModel?> UpdateUserAsync(UpdateUserForm formData)
    {
        if (formData == null) return null;

        try
        {
            var entity = UserFactory.ToEntity(formData);
            await _userRepository.UpdateAsync(entity);

            var model = UserFactory.ToModel(entity);
            return model;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
    public async Task<bool> DeleteUserAsync(string id)
    {
        try
        {
            var entity = await _userRepository.GetAsync(x => x.Id == id);

            if (entity == null) return false;

            await _userRepository.DeleteAsync(entity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<UserModel?> GetUserByIdAsync(string id)
    {
        if (string.IsNullOrEmpty(id)) return null;

        try
        {
            var entity = await _userRepository.GetAsync(x => x.Id == id, i => i.Address);
            if (entity == null) return null;

            if (entity.Address == null)
            {
                entity.Address = new UserAddressEntity
                {
                    StreetName = string.Empty,
                    PostalCode = string.Empty,
                    City = string.Empty
                };
            }

            var model = UserFactory.ToModel(entity);
            return model;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
}
