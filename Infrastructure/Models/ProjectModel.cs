namespace Infrastructure.Models;

public class ProjectModel
{
    public string Id { get; set; } = null!;
    public string? ImageFileName { get; set; }
    public string ProjectName { get; set; } = null!;
    public ClientModel Client { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Budget { get; set; }
    public UserModel User { get; set; } = null!;
    public ProjectStatusModel Status { get; set; } = null!;
}
