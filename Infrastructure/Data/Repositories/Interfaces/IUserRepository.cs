using Infrastructure.Common;
using Infrastructure.Data.Entities;

namespace Infrastructure.Data.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task<OperationResult> CreateUserAsync(UserEntity entity, string password);
}
