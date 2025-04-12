using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class SignUpForm
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    public bool IsAgreedToTerms { get; set; }
}
