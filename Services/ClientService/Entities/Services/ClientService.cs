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
            foreach (var client in clients)
            {
                response.Client.Add(client.Adapt<GrpcClientModel>());
            }

            return response;
        }
        #endregion
    }
}
