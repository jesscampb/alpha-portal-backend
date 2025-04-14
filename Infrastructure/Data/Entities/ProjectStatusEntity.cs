using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Entities;

[Index(nameof(StatusName), IsUnique = true)]
public class ProjectStatusEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string StatusName { get; set; } = null!;
}