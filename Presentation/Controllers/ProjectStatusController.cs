using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectStatusController(IProjectService projectService) : ControllerBase
    {
        private readonly IProjectService _projectService = projectService;


    }
}
