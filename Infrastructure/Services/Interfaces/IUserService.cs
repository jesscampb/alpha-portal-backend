using Infrastructure.Dtos;
using Infrastructure.Models;

namespace Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel?> CreateUserAsync(AddUserForm formData);
        Task<bool> DeleteUserAsync(string id);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel?> GetUserByIdAsync(string id);
        Task<UserModel?> UpdateUserAsync(UpdateUserForm formData);
    }
}