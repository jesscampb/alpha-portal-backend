namespace Infrastructure.Models;

public class ClientModel
{
    public string Id { get; set; } = null!;
    public string? ImageFileName { get; set; }
    public string ClientName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public ClientAddressModel Address { get; set; } = null!;
    public string? Reference { get; set; }
    public bool IsActive { get; set; } = false;
}
