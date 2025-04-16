using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class UpdateProjectForm
{
    [Required]
    public string Id { get; set; } = null!;

    public string? ExistingImageFileName { get; set; }
    public IFormFile? NewImageFile { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string ProjectName { get; set; } = null!;

    [Required]
    public string ClientId { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [Required]
    public string UserId { get; set; } = null!;

    [Range(0, 10_000_000)]
    public decimal? Budget { get; set; }

    [Required]
    public int ProjectStatusId { get; set; }
}
