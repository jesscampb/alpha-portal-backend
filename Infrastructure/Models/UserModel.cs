using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class UserModel
{
    public string Id { get; set; } = null!;
    public string? ImageFileName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? JobTitle { get; set; }
    public string? Role { get; set; }
    public string? StreetName { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
}
