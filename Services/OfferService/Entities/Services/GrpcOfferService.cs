namespace OfferService.Entities.Services
{
    public class GrpcOfferService : GrpcOffersService.GrpcOffersServiceBase
    {
        #region Services
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public GrpcOfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region GET
        public override async Task<GrpcOffersResponse> GetAllOffers(Empty request, ServerCallContext context)
        {
            var services = await _unitOfWork.Services.GetAllAsync();
            var response = new GrpcOffersResponse();
            response.Offer.AddRange(services.Adapt<IList<GrpcOfferModel>>());
            return response;
        }

        public override async Task<GrpcOfferModel> GetOfferById(GrpcOfferId request, ServerCallContext context)
        {
            var offer = await _unitOfWork.Services.FindAsync(o => o.Id == request.Id);
            return offer.Adapt<GrpcOfferModel>();
        }
        #endregion
    }
}
