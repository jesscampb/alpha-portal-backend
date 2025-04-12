using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Interfaces;

namespace Infrastructure.Data.Repositories;
public class ProjectStatusRepository(AppDbContext context) : BaseRepository<ProjectStatusEntity>(context), IProjectStatusRepository
{
}
