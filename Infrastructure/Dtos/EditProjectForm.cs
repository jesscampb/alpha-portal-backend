using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class EditProjectForm
{
    [Required]
    public string Id { get; set; } = null!;
    public string? ImageFileName { get; set; }
    public IFormFile? NewImageFile { get; set; }
    [Required]
    public string ProjectName { get; set; } = null!;
    [Required]
    public int ClientId { get; set; }
    public string? Description { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }
    [Required]
    public string UserId { get; set; } = null!;
    public decimal? Budget { get; set; }
    [Required]
    public int ProjectStatusId { get; set; }
}
