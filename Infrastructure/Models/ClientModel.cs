namespace Infrastructure.Models;

public class ClientModel
{
    public string Id { get; set; } = null!;
    public string? ImageFileName { get; set; }
    public string? ClientName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? StreetName { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? Reference { get; set; }
    public bool IsActive { get; set; } = false;
}
