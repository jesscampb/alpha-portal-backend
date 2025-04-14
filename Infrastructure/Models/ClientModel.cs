namespace Infrastructure.Models;

public class ClientModel
{
    public string Id { get; set; } = null!;
    public string? ImageFileName { get; set; }
    public string ClientName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string? Reference { get; set; }
    public bool IsActive { get; set; } = false;
}
