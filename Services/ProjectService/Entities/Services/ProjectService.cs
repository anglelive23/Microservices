namespace ProjectService.Entities.Services
{
    public class ProjectService : GrpcProjectService.GrpcProjectServiceBase
    {
        #region Services
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region GET
        public override async Task<GrpcProjectResponse> GetAllProjects(Empty request, ServerCallContext context)
        {
            var projects = await _unitOfWork.Projects.GetAllAsync();
            var response = new GrpcProjectResponse();
            response.Project.AddRange(projects.Adapt<IList<GrpcProjectModel>>());
            return response;
        }

        public override async Task<GrpcProjectModel> GetProjectById(GrpcProjectId request, ServerCallContext context)
        {
            var project = await _unitOfWork.Projects.FindAsync(p => p.Id == request.Id);
            return project.Adapt<GrpcProjectModel>();
        }
        #endregion
    }
}
