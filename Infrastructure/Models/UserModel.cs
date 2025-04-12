namespace Infrastructure.Models;

public class UserModel
{
    public string Id { get; set; } = null!;
    public string? ImageFileName { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? JobTitle { get; set; }
    public string? Role { get; set; }
    public UserAddressModel? Address { get; set; }
}
