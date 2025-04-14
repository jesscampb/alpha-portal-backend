using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.Interfaces;
using Infrastructure.Dtos;
using Infrastructure.Factories;
using Infrastructure.Models;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ClientService(IClientRepository clientRepository)
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<ClientModel?> CreateClientAsync(AddClientForm formData)
    {
        if (formData == null) return null;

        try
        {
            var entity = ClientFactory.ToEntity(formData);
            await _clientRepository.AddAsync(entity);

            var model = ClientFactory.ToModel(entity);
            return model;


        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<ClientModel?> UpdateClientAsync(UpdateClientForm formData)
    {
        if (formData == null) return null;

        try
        {
            var entity = ClientFactory.ToEntity(formData);
            await _clientRepository.UpdateAsync(entity);

            var model = ClientFactory.ToModel(entity);
            return model;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<bool> DeleteClientAsync(string id)
    {
        try
        {
            var entity = await _clientRepository.GetAsync(x => x.Id == id);
            if (entity == null) return false;
            await _clientRepository.DeleteAsync(entity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}

// C
// R1 - RA
// U
// D