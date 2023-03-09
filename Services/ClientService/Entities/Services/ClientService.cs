namespace ClientService.Entities.Services
{
    public class ClientService : GrpcClientServices.GrpcClientServicesBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<GrpClientResponse> GetAllClients(Empty request, ServerCallContext context)
        {
            // FROM DATABASE
            var clients = await _unitOfWork.Clients.GetAllAsync();

            // RETURN DATA
            var response = new GrpClientResponse();
            foreach (var client in clients)
            {
                response.Client.Add(client.Adapt<GrpcClientModel>());
            }

            return response;
        }
    }
}
