using Gateway.API.gRPC;
using Microsoft.AspNetCore.OutputCaching;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        #region Services
        private readonly IProjectsGrpcDataClient _grpc;
        #endregion

        #region Constructors
        public ProjectsController(IProjectsGrpcDataClient grpc)
        {
            _grpc = grpc;
        }
        #endregion

        [HttpGet("Projects")]
        [ProducesResponseType(200, Type = typeof(List<ProjectResponseDto>))]
        [OutputCache(PolicyName = "Projects")]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                Log.Information("Starting controller Company action GetAllProjects.");
                var projects = _grpc.GetAllProjects();

                if (!projects.Any())
                    return NotFound("Projects is null or empty.");

                Log.Information("Returning all Projects to the caller.");
                return await Task.FromResult(Ok(projects));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
