using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data.Entities;

public class UserEntity : IdentityUser
{
    public string? ImageFileName { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public UserAddressEntity? Address { get; set; }
}
