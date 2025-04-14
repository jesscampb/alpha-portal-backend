using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities;

public class ProjectEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? ImageFileName { get; set; }

    [Required]
    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Required]
    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Budget { get; set; }

    [Required]
    [ForeignKey(nameof(Client))]
    public string ClientId { get; set; } = null!;

    [Required]
    public ClientEntity Client { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;

    [Required]
    public UserEntity User { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Status))]
    public int StatusId { get; set; }

    [Required]
    public ProjectStatusEntity Status { get; set; } = null!;
}
