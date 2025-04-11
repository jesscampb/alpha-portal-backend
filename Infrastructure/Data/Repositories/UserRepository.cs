using Infrastructure.Common;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace Infrastructure.Data.Repositories;
public class UserRepository(AppDbContext context, UserManager<UserEntity> userManager) : BaseRepository<UserEntity>(context), IUserRepository
{
    private readonly UserManager<UserEntity> _userManager = userManager;

    public async Task<OperationResult> CreateUserAsync(UserEntity entity, string password)
    {
        if (entity == null)
            return new OperationResult { Succeeded = false, StatusCode = 400 };

		try
		{
            var result = await _userManager.CreateAsync(entity, password);
            if (result.Succeeded)
                return new OperationResult { Succeeded = true, StatusCode = 201 };

            throw new Exception("Unable to create user by using UserManager.");
        }
		catch (Exception ex)
		{
            Debug.WriteLine(ex.Message);

            return new OperationResult { Succeeded = false, StatusCode = 500, ErrorMessage = ex.Message };
        }
    }
}
