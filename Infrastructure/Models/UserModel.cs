namespace Infrastructure.Models;

public class UserModel
{
    public string Id { get; set; } = null!;
    public string? ImageFileName { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? JobTitle { get; set; }
    public string? MemberRole { get; set; }
    public UserAddressModel? Address { get; set; }
}
