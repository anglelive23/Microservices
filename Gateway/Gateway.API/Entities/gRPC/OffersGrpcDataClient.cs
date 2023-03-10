using OfferService;

namespace Gateway.API.Entities.gRPC
{
    public interface IOffersGrpcDataClient
    {
        IList<ServicesResponseDto> GetAllServices();
        ServicesResponseDto? GetServiceById(int id);
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
                Log.Information($"--> Calling gRPC Service [{_serviceUrl}] to get All Services...");
                var services = _client.GetAllOffers(new Empty());
                Log.Information($"--> {services.Offer.Count} services has been retrieved...");
                return services.Offer.Adapt<IList<ServicesResponseDto>>();
            }
            catch (Exception ex)
            {
                Log.Information($"--> Could not call gRPC server {ex.Message}");
                return Enumerable.Empty<ServicesResponseDto>().ToList();
            }
        }

        public ServicesResponseDto? GetServiceById(int id)
        {
            try
            {
                Log.Information($"--> Calling gRPC Service [{_serviceUrl}] to get All service by id: {id}...");
                var byId = new GrpcOfferId { Id = id };
                var service = _client.GetOfferById(byId);
                Log.Information($"--> service with id: {id} has been retrieved...");
                return service.Adapt<ServicesResponseDto>();
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
