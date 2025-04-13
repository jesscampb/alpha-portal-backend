using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class UpdateClientForm
{
    [Required]
    public string Id { get; set; } = null!;

    public string? ExistingImageFileName { get; set; }
    public IFormFile? NewImageFile { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string ClientName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [RegularExpression(@"^\+46\d{7,11}$")]
    public string? PhoneNumber { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string StreetName { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\d{5}$")]
    public string PostalCode { get; set; } = null!;

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string City { get; set; } = null!;

    [StringLength(100, MinimumLength = 2)]
    public string? Reference { get; set; }
}
