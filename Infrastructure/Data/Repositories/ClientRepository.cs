using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data.Repositories;
public class ClientRepository(AppDbContext context) : BaseRepository<ClientEntity>(context), IClientRepository
{
    public override async Task<bool> AddAsync(ClientEntity entity)
    {
        if (entity == null) return false;

        entity.Address = new ClientAddressEntity
        {
            ClientId = entity.Id,
        };

        return await base.AddAsync(entity);
    }
}
