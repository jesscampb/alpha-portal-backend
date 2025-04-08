using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities;

public class ClientBillingAddressEntity
{
    [Key, ForeignKey(nameof(Client))]
    public string ClientId { get; set; } = null!;
    public ClientEntity Client { get; set; } = null!;
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string City { get; set; } = null!;
}