namespace Infrastructure.Models;

public class ClientAddressModel
{
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public string City { get; set; } = null!;
}