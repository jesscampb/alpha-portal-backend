using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Interfaces;

namespace Infrastructure.Data.Repositories;

public interface IUserRepository : IBaseRepository<UserEntity>
{

}
public class UserRepository(AppDbContext context) : BaseRepository<UserEntity>(context), IUserRepository
{

}
