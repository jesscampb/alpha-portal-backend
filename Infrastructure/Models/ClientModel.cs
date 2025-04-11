namespace Infrastructure.Models;

public class ClientModel
{
    public string Id { get; set; } = null!;
    public string? ImageFileName { get; set; }
    public string ClientName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public ClientBillingAddressModel BillingAddress { get; set; } = null!;
    public string? BillingReference { get; set; }
}
