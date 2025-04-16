using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class UpdateUserForm
{
    [Required]
    public string Id { get; set; } = null!;
    public string? ExistingImageFileName { get; set; }
    public IFormFile? NewImageFile { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [RegularExpression(@"^\d{7,15}$")]
    public string? PhoneNumber { get; set; }

    [StringLength(100)]
    public string? JobTitle { get; set; }

    public string? Role { get; set; }

    [StringLength(100, MinimumLength = 2)]
    public string? StreetName { get; set; }

    [RegularExpression(@"^\d{5}$")]
    public string? PostalCode { get; set; }

    [StringLength(50, MinimumLength = 2)]
    public string? City { get; set; }
}
