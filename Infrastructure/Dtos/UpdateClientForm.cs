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
    public string ClientName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    [Required]
    public string StreetName { get; set; } = null!;
    [Required]
    public string PostalCode { get; set; } = null!;
    [Required]
    public string City { get; set; } = null!;
    public string? Reference { get; set; }
}
