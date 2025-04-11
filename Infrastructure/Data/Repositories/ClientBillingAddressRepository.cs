using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Interfaces;

namespace Infrastructure.Data.Repositories;

public interface IClientBillingAddressRepository : IBaseRepository<ClientBillingAddressEntity>
{
}
public class ClientBillingAddressRepository(AppDbContext context) : BaseRepository<ClientBillingAddressEntity>(context), IClientBillingAddressRepository
{
}
