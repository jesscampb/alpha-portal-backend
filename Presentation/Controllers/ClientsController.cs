using Infrastructure.Dtos;
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

    /// <summary>
    /// Creates a new client.
    /// </summary>
    /// <param name="formData">Client data to add.</param>
    /// <returns>The newly created client.</returns>
    [HttpPost]
    public async Task<IActionResult> Create(AddClientForm formData)
    {
        if (!ModelState.IsValid)
            return BadRequest(formData);

        var result = await _clientService.CreateClientAsync(formData);

        return result == null ? BadRequest() : Ok(result);
    }

    /// <summary>
    /// Retrieves a client by its ID.
    /// </summary>
    /// <param name="id">The client's ID.</param>
    /// <returns>The requested client.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _clientService.GetClientByIdAsync(id);

        return result == null ? NotFound() : Ok(result);
    }


    /// <summary>
    /// Retrieves all clients.
    /// </summary>
    /// <returns>List of all clients.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _clientService.GetAllClientsAsync();

        return result == null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Updates a client's details.
    /// </summary>
    /// <param name="formData">Updated client data.</param>
    /// <returns>Status indicating success or failure of update operation.</returns>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateClientForm formData)
    {
        if (!ModelState.IsValid)
            return BadRequest(formData);

        var result = await _clientService.UpdateClientAsync(formData);

        return result ? Ok(result) : BadRequest();
    }

    /// <summary>
    /// Deletes a client by its ID.
    /// </summary>
    /// <param name="id">The client's ID.</param>
    /// <returns>Status indicating success or failure of deletion.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _clientService.DeleteClientAsync(id);

        return result ? Ok(result) : NotFound();
    }
}
