namespace Gateway.API.Controllers
{
    [Route("gateway/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        #region Services
        private readonly IClientsGrpcDataClient _grpc;
        #endregion

        #region Construcotors
        public ClientsController(IClientsGrpcDataClient grpc)
        {
            _grpc = grpc;
        }
        #endregion

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ClientResponseDto>))]
        [OutputCache(PolicyName = "Clients")]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                Log.Information("--> Trying to get all clients using gRPC...");
                var clients = _grpc.GetAllClients();

                if (!clients.Any())
                {
                    return NotFound("Clients is null or empty.");
                }

                Log.Information($"--> {clients.Count} clients has been retrieved...");
                return await Task.FromResult(Ok(clients));
            }
            catch (Exception ex)
            {
                Log.Information($"--> Couldn't retrieve clients using gRPC: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ClientResponseDto))]
        [OutputCache(PolicyName = "Client")]
        public async Task<IActionResult> GetClientById(int id)
        {
            try
            {
                Log.Information($"--> Trying to get client by id: {id} using gRPC...");
                var client = _grpc.GetClientById(id);

                if (client is null)
                    return NotFound();

                Log.Information($"--> client with Id: {client.Id} has been retrieved...");
                return await Task.FromResult(Ok(client));
            }
            catch (Exception ex)
            {
                Log.Information($"--> Couldn't retrieve client with id: {id} using gRPC: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
