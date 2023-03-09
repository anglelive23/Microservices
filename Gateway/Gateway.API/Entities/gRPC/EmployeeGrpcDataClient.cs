namespace Gateway.API.Entities.gRPC
{
    public interface IEmployeeGrpcDataClient
    {
        IList<EmployeeResponseDto> GetAllEmployees();
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
                var employees = _client.GetAllEmployees(new Empty());
                var response = new List<EmployeeResponseDto>();
                foreach (var emp in employees.Employee)
                {
                    response.Add(emp.Adapt<EmployeeResponseDto>());
                }
                return response;
            }
            catch (Exception ex)
            {
                Log.Error($"Something went wrong.. {ex.Message}");
                return Enumerable.Empty<EmployeeResponseDto>().ToList();
            }
        }
        #endregion
    }
}
