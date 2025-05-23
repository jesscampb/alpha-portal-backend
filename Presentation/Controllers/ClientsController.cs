﻿using Infrastructure.Dtos;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions.Attributes;

namespace Presentation.Controllers;

[AdminApiKey]
[Route("api/[controller]")]
[ApiController]
public class ClientsController(IClientService clientService) : ControllerBase
{
    private readonly IClientService _clientService = clientService;

    [HttpPost]
    public async Task<IActionResult> Create(AddClientForm formData)
    {
        if (!ModelState.IsValid)
            return BadRequest(formData);

        var result = await _clientService.CreateClientAsync(formData);

        return result == null ? BadRequest() : Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _clientService.GetClientByIdAsync(id);

        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _clientService.GetAllClientsAsync();

        return result == null ? NotFound() : Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateClientForm formData)
    {
        if (!ModelState.IsValid)
            return BadRequest(formData);

        var result = await _clientService.UpdateClientAsync(formData);

        return result ? Ok(result) : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _clientService.DeleteClientAsync(id);

        return result ? Ok(result) : NotFound();
    }
}
