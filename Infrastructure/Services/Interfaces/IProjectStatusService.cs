using Infrastructure.Models;

namespace Infrastructure.Services.Interfaces
{
    public interface IProjectStatusService
    {
        Task<List<ProjectStatusModel>> GetAllProjectStatusesAsync();
        Task<ProjectStatusModel?> GetProjectStatusByIdAsync(int id);
    }
}