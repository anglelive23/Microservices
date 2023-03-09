﻿namespace Gateway.API.gRPC
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
            _serviceUrl = _config["GrpcEmployeesServiceUrl"];
            _channel = GrpcChannel.ForAddress(_serviceUrl);
            _client = new GrpcEmployeeServiceClient(_channel);
        }
        #endregion
        public IList<EmployeeResponseDto> GetAllEmployees()
        {
            var employees = _client.GetAllEmployees(new Empty());
            var response = new List<EmployeeResponseDto>();
            foreach (var emp in employees.Employee)
            {
                response.Add(emp.Adapt<EmployeeResponseDto>());
            }
            return response;
        }
    }
}