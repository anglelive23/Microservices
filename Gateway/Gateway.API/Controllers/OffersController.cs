namespace Gateway.API.Controllers
{
    //[Route("gateway/[controller]")]
    [Route("gateway/odata")]
    [ApiController]
    public class OffersController : ODataController
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

        #region GET
        [HttpGet("offers")]
        [ProducesResponseType(200, Type = typeof(List<ServicesResponseDto>))]
        [OutputCache(PolicyName = "Services")]
        [EnableQuery]
        public IActionResult GetAllServices()
        {
            try
            {
                Log.Information("--> Trying to get all services using gRPC...");
                var services = _grpc.GetAllServices();

                if (!services.Any())
                    return NotFound("Services is null or empty.");

                Log.Information($"--> {services.Count} services has been retrieved...");
                return Ok(services);
            }
            catch (Exception ex)
            {
                Log.Information($"--> Couldn't retrieve services using gRPC: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("offers({id})")]
        [ProducesResponseType(200, Type = typeof(ServicesResponseDto))]
        [OutputCache(PolicyName = "Service")]
        [EnableQuery]
        public IActionResult GetServiceById(int id)
        {
            try
            {
                Log.Information($"--> Trying to get service with id: {id} using gRPC...");
                var service = _grpc.GetServiceById(id);

                if (service is null)
                    return NotFound();

                Log.Information($"--> service with id: {id} has been retrieved...");
                return Ok(service);
            }
            catch (Exception ex)
            {
                Log.Information($"--> Couldn't retrieve service with id: {id} using gRPC: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
