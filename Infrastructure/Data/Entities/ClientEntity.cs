using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities;

[Index(nameof(ClientName), IsUnique = true)]
public class ClientEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? ImageFileName { get; set; }
    [Required]
    public string ClientName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    [Required]
    public ClientAddressEntity? Address { get; set; }
    public string? Reference { get; set; }
    [Required]
    public bool IsActive { get; set; } = false;
}
