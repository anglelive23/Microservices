namespace ClientService.Entities.Services
{
    public class ClientService : GrpcClientServices.GrpcClientServicesBase
    {
        #region Services
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region GET
        public override async Task<GrpcClientResponse> GetAllClients(Empty request, ServerCallContext context)
        {
            var clients = await _unitOfWork.Clients.GetAllAsync();
            var response = new GrpcClientResponse();

            response.Client.AddRange(clients.Adapt<IList<GrpcClientModel>>());
            return response;
        }

        public override async Task<GrpcClientModel> GetClientById(GrpcClientId request, ServerCallContext context)
        {
            var client = await _unitOfWork.Clients.FindAsync(c => c.Id == request.Id);
            return client.Adapt<GrpcClientModel>();
        }
        #endregion
    }
}
