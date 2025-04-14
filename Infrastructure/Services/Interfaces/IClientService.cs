using Infrastructure.Dtos;
using Infrastructure.Models;

namespace Infrastructure.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClientModel?> CreateClientAsync(AddClientForm formData);
        Task<bool> DeleteClientAsync(string id);
        Task<IEnumerable<ClientModel>> GetAllClientsAsync();
        Task<ClientModel?> GetClientByIdAsync(string id);
        Task<ClientModel?> UpdateClientAsync(UpdateClientForm formData);
    }
}