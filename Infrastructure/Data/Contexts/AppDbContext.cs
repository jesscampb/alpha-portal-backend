using Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<UserEntity>(options)
{
    public DbSet<UserAddressEntity> UserAddresses { get; set; }
    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<ClientAddressEntity> ClientBillingAddresses { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<ProjectStatusEntity> Statuses { get; set; }
}
