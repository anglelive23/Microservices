namespace Gateway.API.Controllers
{
    //[Route("gateway/[controller]")]
    [Route("gateway/odata")]
    [ApiController]
    public class ProjectsController : ODataController
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

        #region GET
        [HttpGet("projects")]
        [ProducesResponseType(200, Type = typeof(List<ProjectResponseDto>))]
        [OutputCache(PolicyName = "Projects")]
        [EnableQuery]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                Log.Information("--> Trying to get all projects using gRPC...");
                var projects = _grpc.GetAllProjects();

                if (!projects.Any())
                    return NotFound("Projects is null or empty.");

                Log.Information($"--> {projects.Count} projects has been retrieved...");
                return await Task.FromResult(Ok(projects));
            }
            catch (Exception ex)
            {
                Log.Information($"--> Couldn't retrieve projects using gRPC: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("projects({id})")]
        [ProducesResponseType(200, Type = typeof(ProjectResponseDto))]
        [OutputCache(PolicyName = "Project")]
        [EnableQuery]
        public async Task<IActionResult> GetProjectById(int id)
        {
            try
            {
                Log.Information($"--> Trying to get project with id: {id} using gRPC...");
                var project = _grpc.GetProjectById(id);

                if (project is null)
                    return NotFound();

                Log.Information($"--> project with id: {id} has been retrieved...");
                return await Task.FromResult(Ok(project));
            }
            catch (Exception ex)
            {
                Log.Information($"--> Couldn't retrieve project with id: {id} using gRPC: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
