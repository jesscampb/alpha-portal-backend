using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Interfaces;

namespace Infrastructure.Data.Repositories;
public class ClientRepository(AppDbContext context) : BaseRepository<ClientEntity>(context), IClientRepository
{
}
