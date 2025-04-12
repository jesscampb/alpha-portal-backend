﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class AddProjectForm
{
    public IFormFile? ImageFile { get; set; }
    [Required]
    public string ProjectName { get; set; } = null!;
    [Required]
    public string ClientId { get; set; } = null!;
    public string? Description { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [Required]
    public string UserId { get; set; } = null!;
    public decimal? Budget { get; set; }
}
