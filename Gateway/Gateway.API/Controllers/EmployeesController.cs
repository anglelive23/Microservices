namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        #region Services
        private readonly IEmployeeGrpcDataClient _grpc;
        #endregion

        #region Constructors
        public EmployeesController(IEmployeeGrpcDataClient grpc)
        {
            _grpc = grpc;
        }
        #endregion

        [HttpGet("Employees")]
        [ProducesResponseType(200, Type = typeof(List<EmployeeResponseDto>))]
        [OutputCache(PolicyName = "Employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                Log.Information("Starting controller Company action GetAllEmployees.");
                var employees = _grpc.GetAllEmployees();

                if (!employees.Any())
                    return NotFound("Employees is null or empty.");

                Log.Information("Returning all Employees to the caller.");
                return await Task.FromResult(Ok(employees));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
