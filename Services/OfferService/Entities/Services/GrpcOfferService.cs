namespace OfferService.Entities.Services
{
    public class GrpcOfferService : GrpcOffersService.GrpcOffersServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GrpcOfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<GrpcOffersResponse> GetAllOffers(Empty request, ServerCallContext context)
        {
            var services = await _unitOfWork.Services.GetAllAsync();
            var response = new GrpcOffersResponse();

            foreach (var service in services)
            {
                response.Offer.Add(service.Adapt<GrpcOfferModel>());
            }

            return response;
        }
    }
}
