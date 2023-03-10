using EmployeeService;

namespace Gateway.API.Entities.gRPC
{
    public interface IEmployeeGrpcDataClient
    {
        IList<EmployeeResponseDto> GetAllEmployees();
        EmployeeResponseDto? GetEmployeeById(int id);
    }

    public class EmployeeGrpcDataClient : IEmployeeGrpcDataClient
    {
        #region Services
        private readonly IConfiguration _config;
        private readonly string _serviceUrl;
        private readonly GrpcChannel _channel;
        private readonly GrpcEmployeeServiceClient _client;
        #endregion

        #region Constructors
        public EmployeeGrpcDataClient(IConfiguration config)
        {
            _config = config;
            _serviceUrl = _config["GrpcEmployeesServiceUrl"] ?? "https://localhost:7030";
            _channel = GrpcChannel.ForAddress(_serviceUrl);
            _client = new GrpcEmployeeServiceClient(_channel);
        }
        #endregion

        #region GET
        public IList<EmployeeResponseDto> GetAllEmployees()
        {
            try
            {
                Log.Information($"--> Calling gRPC Service [{_serviceUrl}] to get All Employees...");
                var employees = _client.GetAllEmployees(new Empty());
                Log.Information($"--> {employees.Employee.Count} employees has been retrieved...");
                return employees.Employee.Adapt<IList<EmployeeResponseDto>>();
            }
            catch (Exception ex)
            {
                Log.Information($"--> Could not call gRPC server {ex.Message}");
                return Enumerable.Empty<EmployeeResponseDto>().ToList();
            }
        }

        public EmployeeResponseDto? GetEmployeeById(int id)
        {
            try
            {
                Log.Information($"--> Calling gRPC Service [{_serviceUrl}] to get Employee by Id: {id}...");
                var byId = new GrpcEmployeeId { Id = id };
                var employee = _client.GetEmployeeById(byId);
                Log.Information($"--> employee with Id: {id} has been retrieved...");
                return employee.Adapt<EmployeeResponseDto>();

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
