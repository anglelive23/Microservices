using Gateway.API.Entities.gRPC;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        #region Services
        private readonly IOffersGrpcDataClient _grpc;
        #endregion

        #region Constructors
        public OffersController(IOffersGrpcDataClient grpc)
        {
            _grpc = grpc;
        }
        #endregion

        [HttpGet("Services")]
        [ProducesResponseType(200, Type = typeof(List<ServicesResponseDto>))]
        [OutputCache(PolicyName = "Services")]
        public IActionResult GetAllServices()
        {
            try
            {
                var services = _grpc.GetAllServices();

                if (!services.Any())
                    return NotFound("Services is null or empty.");

                return Ok(services);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
