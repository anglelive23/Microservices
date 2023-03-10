using ClientService;

namespace Gateway.API.Entities.gRPC
{
    public interface IClientsGrpcDataClient
    {
        IList<ClientResponseDto> GetAllClients();
        ClientResponseDto? GetClientById(int id);
    }

    class ClientsGrpcDataClient : IClientsGrpcDataClient
    {
        #region Services
        private readonly IConfiguration _config;
        private readonly GrpcChannel _channel;
        private readonly GrpcClientServicesClient _client;
        private readonly string _serviceUrl;
        #endregion

        #region Constructors
        public ClientsGrpcDataClient(IConfiguration config)
        {
            _config = config;
            _serviceUrl = _config["GrpcClientsServiceUrl"] ?? "https://localhost:7321";
            _channel = GrpcChannel.ForAddress(_serviceUrl);
            _client = new GrpcClientServicesClient(_channel);
        }
        #endregion

        #region GET
        public IList<ClientResponseDto> GetAllClients()
        {
            try
            {
                Log.Information($"--> Calling gRPC Service [{_serviceUrl}] to get All Clients...");
                var clients = _client.GetAllClients(new Empty());
                Log.Information($"--> {clients.Client.Count} clients has been retrieved...");
                return clients.Client.Adapt<IList<ClientResponseDto>>();
            }
            catch (Exception ex)
            {
                Log.Information($"--> Could not call gRPC server {ex.Message}");
                return Enumerable.Empty<ClientResponseDto>().ToList();
            }
        }

        public ClientResponseDto? GetClientById(int id)
        {
            try
            {
                Log.Information($"--> Calling gRPC Service [{_serviceUrl}] to get client by Id: {id}...");
                GrpcClientId byId = new GrpcClientId { Id = id };
                var client = _client.GetClientById(byId);
                Log.Information($"--> client with Id: {client.Id} has been retrieved...");
                return client.Adapt<ClientResponseDto>();
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
