using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities;

public class UserAddressEntity
{
    [Required]
    [Key, ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;
    [Required]
    public UserEntity User { get; set; } = null!;
    [Required]
    public string StreetName { get; set; } = null!;
    [Required]
    public string PostalCode { get; set; } = null!;
    [Required]
    public string City { get; set; } = null!;
}
