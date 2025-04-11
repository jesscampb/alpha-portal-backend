using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Interfaces;

namespace Infrastructure.Data.Repositories;

public interface IUserAddressRepository : IBaseRepository<UserAddressEntity>
{
}
public class UserAddressRepository(AppDbContext context) : BaseRepository<UserAddressEntity>(context), IUserAddressRepository
{
}
