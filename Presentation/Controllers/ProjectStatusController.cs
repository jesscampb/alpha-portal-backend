using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectStatusController(IProjectStatusService projectStatusService) : ControllerBase
    {
        private readonly IProjectStatusService _projectStatusService = projectStatusService;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _projectStatusService.GetProjectStatusByIdAsync(id);

            return result == null ? Ok() : NotFound();
        }


    }
}
