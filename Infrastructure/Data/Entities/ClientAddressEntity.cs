using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities;

public class ClientAddressEntity
{
    [Key, ForeignKey(nameof(Client))]
    public string ClientId { get; set; } = null!;
    [Required]
    public ClientEntity Client { get; set; } = null!;
    [Required]
    public string? StreetName { get; set; }
    [Required]
    public string? PostalCode { get; set; }
    [Required]
    public string? City { get; set; }
}