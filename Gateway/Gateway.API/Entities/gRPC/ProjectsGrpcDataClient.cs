namespace Gateway.API.Entities.gRPC
{
    public interface IProjectsGrpcDataClient
    {
        IList<ProjectResponseDto> GetAllProjects();
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
            _serviceUrl = _config["GrpcProjectsServiceUrl"];
            _channel = GrpcChannel.ForAddress(_serviceUrl);
            _client = new GrpcProjectServiceClient(_channel);
        }
        #endregion

        public IList<ProjectResponseDto> GetAllProjects()
        {
            try
            {
                var projects = _client.GetAllProjects(new Empty());
                var response = new List<ProjectResponseDto>();
                foreach (var item in projects.Project)
                {
                    response.Add(item.Adapt<ProjectResponseDto>());
                }
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"Something went wrong.. {ex.Message}");
                return Enumerable.Empty<ProjectResponseDto>().ToList();
            }
        }
    }
}
