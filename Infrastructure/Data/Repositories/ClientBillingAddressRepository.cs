using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Interfaces;

namespace Infrastructure.Data.Repositories;

public class ClientBillingAddressRepository(AppDbContext context) : BaseRepository<ClientAddressEntity>(context), IClientBillingAddressRepository
{
}
