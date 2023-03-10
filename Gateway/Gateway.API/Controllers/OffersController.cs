namespace Gateway.API.Controllers
{
    [Route("gateway/[controller]")]
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

        [HttpGet("GetAll")]
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
