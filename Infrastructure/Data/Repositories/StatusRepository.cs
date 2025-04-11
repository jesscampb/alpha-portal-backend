using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Interfaces;

namespace Infrastructure.Data.Repositories;

internal interface IStatusRepository : IBaseRepository<StatusEntity>
{
}
public class StatusRepository(AppDbContext context) : BaseRepository<StatusEntity>(context), IStatusRepository
{
}
