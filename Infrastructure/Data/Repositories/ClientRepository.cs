using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;

namespace Infrastructure.Data.Repositories;

public interface IClientRepository
{
}
public class ClientRepository(AppDbContext context) : BaseRepository<ClientEntity>(context), IClientRepository
{
}
