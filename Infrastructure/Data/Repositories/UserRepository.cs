using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data.Repositories;

public interface IUserRepository : IBaseRepository<UserEntity>
{

}
public class UserRepository(AppDbContext context, UserManager<UserEntity> userManager) : BaseRepository<UserEntity>(context), IUserRepository
{
    private readonly UserManager<UserEntity> _userManager = userManager;
}
