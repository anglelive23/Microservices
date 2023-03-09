namespace Gateway.API.Entities.gRPC
{
    public interface IClientsGrpcDataClient
    {
        IList<ClientResponseDto> GetAllClients();
    }

    class ClientsGrpcDataClient : IClientsGrpcDataClient
    {
        private readonly IConfiguration _config;
        private readonly GrpcChannel _channel;
        private readonly GrpcClientServicesClient _client;
        private readonly string _serviceUrl;
        public ClientsGrpcDataClient(IConfiguration config)
        {
            _config = config;
            _serviceUrl = _config["GrpcClientsServiceUrl"];
            _channel = GrpcChannel.ForAddress(_serviceUrl);
            _client = new GrpcClientServicesClient(_channel);
        }
        public IList<ClientResponseDto> GetAllClients()
        {
            try
            {
                var clients = _client.GetAllClients(new Empty());
                var response = new List<ClientResponseDto>();
                foreach (var client in clients.Client)
                {
                    response.Add(client.Adapt<ClientResponseDto>());
                }
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"Something went wrong.. {ex.Message}");
                return Enumerable.Empty<ClientResponseDto>().ToList();
            }
        }
    }
}
