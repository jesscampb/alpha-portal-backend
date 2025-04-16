using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data.Repositories;
public class UserRepository(AppDbContext context, UserManager<UserEntity> userManager) : BaseRepository<UserEntity>(context), IUserRepository
{
    private readonly UserManager<UserEntity> _userManager = userManager;

    public async Task<bool> CreateUserAsync(UserEntity entity, string password)
    {
        entity.Address = new UserAddressEntity
        {
            UserId = entity.Id,
        };

        var result = await _userManager.CreateAsync(entity, password);
        return result.Succeeded;
    }
}
