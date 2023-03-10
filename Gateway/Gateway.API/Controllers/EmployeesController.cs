namespace Gateway.API.Controllers
{
    [Route("gateway/[controller]")]
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

        #region GET
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<EmployeeResponseDto>))]
        [OutputCache(PolicyName = "Employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                Log.Information("--> Trying to get all employees using gRPC...");
                var employees = _grpc.GetAllEmployees();

                if (!employees.Any())
                    return NotFound("Employees is null or empty.");

                Log.Information($"--> {employees.Count} employees has been retrieved...");
                return await Task.FromResult(Ok(employees));
            }
            catch (Exception ex)
            {
                Log.Information($"--> Couldn't retrieve employees using gRPC: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(EmployeeResponseDto))]
        [OutputCache(PolicyName = "Employee")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                Log.Information($"--> Trying to get all employee with id: {id} using gRPC...");
                var employee = _grpc.GetEmployeeById(id);

                if (employee is null)
                    return NotFound();

                Log.Information($"--> employee with id: {id} has been retrieved...");
                return await Task.FromResult(Ok(employee));
            }
            catch (Exception ex)
            {
                Log.Information($"--> Couldn't retrieve employee with id: {id} using gRPC: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
