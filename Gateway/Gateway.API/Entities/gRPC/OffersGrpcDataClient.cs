namespace Gateway.API.Entities.gRPC
{
    public interface IOffersGrpcDataClient
    {
        IList<ServicesResponseDto> GetAllServices();
    }

    public class OffersGrpcDataClient : IOffersGrpcDataClient
    {
        #region Services
        private readonly IConfiguration _config;
        private readonly GrpcChannel _channel;
        private readonly GrpcOffersServiceClient _client;
        private readonly string _serviceUrl;
        #endregion

        #region Constructors
        public OffersGrpcDataClient(IConfiguration config)
        {
            _config = config;
            _serviceUrl = _config["GrpcOffersServiceUrl"] ?? "https://localhost:7596";
            _channel = GrpcChannel.ForAddress(_serviceUrl);
            _client = new GrpcOffersServiceClient(_channel);
        }
        #endregion

        #region GET
        public IList<ServicesResponseDto> GetAllServices()
        {
            try
            {
                var services = _client.GetAllOffers(new Empty());
                var response = new List<ServicesResponseDto>();
                foreach (var service in services.Offer)
                {
                    response.Add(service.Adapt<ServicesResponseDto>());
                }
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"Something went wrong.. {ex.Message}");
                return Enumerable.Empty<ServicesResponseDto>().ToList();
            }
        }
        #endregion
    }

}
