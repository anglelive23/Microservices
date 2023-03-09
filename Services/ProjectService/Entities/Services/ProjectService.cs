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
            foreach (var project in projects)
            {
                response.Project.Add(project.Adapt<GrpcProjectModel>());
            }
            return response;
        }
        #endregion
    }
}
