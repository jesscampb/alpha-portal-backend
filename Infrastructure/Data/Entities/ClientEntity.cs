using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities;

public class ClientEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? ImageFileName { get; set; }
    public string ClientName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public ClientBillingAddressEntity BillingAddress { get; set; } = null!;
    public string? BillingReference { get; set; }
}
