namespace Gateway.API.gRPC
{
    public interface IOffersGrpcDataClient
    {
        IList<ServicesResponseDto> GetAllServices();
    }

    public class OffersGrpcDataClient : IOffersGrpcDataClient
    {
        #region Fields
        private readonly IConfiguration _config;
        private readonly GrpcChannel _channel;
        private readonly GrpcOffersServiceClient _client;
        private readonly string _serviceUrl;
        #endregion

        #region Constructors
        public OffersGrpcDataClient(IConfiguration config)
        {
            _config = config;
            _serviceUrl = _config["GrpcOffersServiceUrl"];
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
                Log.Information($"Failed {ex.Message}");
                return null;
            }
        }
        #endregion
    }

}
