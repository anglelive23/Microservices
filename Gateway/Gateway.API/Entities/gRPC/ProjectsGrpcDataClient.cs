using ProjectService;

namespace Gateway.API.Entities.gRPC
{
    public interface IProjectsGrpcDataClient
    {
        IList<ProjectResponseDto> GetAllProjects();
        ProjectResponseDto? GetProjectById(int id);
    }
    public class ProjectsGrpcDataClient : IProjectsGrpcDataClient
    {
        #region Services
        private readonly IConfiguration _config;
        private readonly string _serviceUrl;
        private readonly GrpcChannel _channel;
        private readonly GrpcProjectServiceClient _client;
        #endregion

        #region Constructors
        public ProjectsGrpcDataClient(IConfiguration config)
        {
            _config = config;
            _serviceUrl = _config["GrpcProjectsServiceUrl"] ?? "https://localhost:7247";
            _channel = GrpcChannel.ForAddress(_serviceUrl);
            _client = new GrpcProjectServiceClient(_channel);
        }
        #endregion

        #region GET
        public IList<ProjectResponseDto> GetAllProjects()
        {
            try
            {
                Log.Information($"--> Calling gRPC Service [{_serviceUrl}] to get All Projects...");
                var projects = _client.GetAllProjects(new Empty());
                Log.Information($"--> {projects.Project.Count} projects has been retrieved...");
                return projects.Project.Adapt<IList<ProjectResponseDto>>();
            }
            catch (Exception ex)
            {
                Log.Information($"--> Could not call gRPC server {ex.Message}");
                return Enumerable.Empty<ProjectResponseDto>().ToList();
            }
        }

        public ProjectResponseDto? GetProjectById(int id)
        {
            try
            {
                Log.Information($"--> Calling gRPC Service [{_serviceUrl}] to get Project with id: {id}...");
                var byId = new GrpcProjectId { Id = id };
                var project = _client.GetProjectById(byId);
                Log.Information($"--> project with id: {id} has been retrieved...");
                return project.Adapt<ProjectResponseDto>();
            }
            catch (Exception ex)
            {
                Log.Information($"--> Could not call gRPC server {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}
