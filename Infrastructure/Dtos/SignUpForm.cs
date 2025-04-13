using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class SignUpForm
{
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

    [Required]
    [MinLength(8)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$")]
    public string Password { get; set; } = null!;

    [Required]
    public bool IsAgreedToTerms { get; set; }
}
