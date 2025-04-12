using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class AddClientForm
{
    public IFormFile? ImageFile { get; set; }
    [Required]
    [MinLength(1)]
    public string ClientName { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [RegularExpression(@"^\+?[0-9]{8,15}$")]
    public string? PhoneNumber { get; set; }
    [Required]
    [MinLength(2)]
    public string StreetName { get; set; } = null!;
    [Required]
    [StringLength(5, MinimumLength = 5)]
    public string PostalCode { get; set; } = null!;
    [Required]
    [MinLength(2)]
    public string City { get; set; } = null!;
    [MinLength(2)]
    public string? Reference { get; set; }
}
