using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class AddUserForm
{
    public IFormFile? ImageFile { get; set; }
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? JobTitle { get; set; }
    public string? Role { get; set; }
    public string? StreetName { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
}