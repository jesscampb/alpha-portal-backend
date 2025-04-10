using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;

namespace Infrastructure.Data.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<UserEntity>(context)
{
}
