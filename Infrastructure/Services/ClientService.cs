﻿using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.Interfaces;
using Infrastructure.Dtos;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Services.Interfaces;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
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

    public async Task<bool> UpdateClientAsync(UpdateClientForm formData)
    {
        if (formData == null) return false;

        try
        {
            var clientEntity = await _clientRepository.GetAsync(x => x.Id == formData.Id, includes: x => x.Address);
            if (clientEntity == null) return false;

            ClientFactory.ToEntity(formData, clientEntity);

            await _clientRepository.UpdateAsync(clientEntity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
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

    public async Task<ClientModel?> GetClientByIdAsync(string id)
    {
        if (string.IsNullOrEmpty(id)) return null;

        try
        {
            var entity = await _clientRepository.GetAsync(x => x.Id == id, i => i.Address);
            if (entity == null) return null;

            var model = ClientFactory.ToModel(entity);
            return model;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<ClientModel>> GetAllClientsAsync()
    {
        try
        {
            var entities = await _clientRepository.GetAllAsync(
                orderByDescending: true,
                sortByExpression: i => i.ClientName,
                filterByExpression: null,
                i => i.Address);

            if (entities == null || !entities.Any()) return Enumerable.Empty<ClientModel>();

            var models = entities.Select(ClientFactory.ToModel).ToList();
            return models;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Enumerable.Empty<ClientModel>();
        }
    }
}