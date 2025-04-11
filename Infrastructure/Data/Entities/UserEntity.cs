using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities;

public class UserEntity : IdentityUser
{
    public string? ImageFileName { get; set; }
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    public string? JobTitle { get; set; }
    public UserAddressEntity? Address { get; set; }
}
