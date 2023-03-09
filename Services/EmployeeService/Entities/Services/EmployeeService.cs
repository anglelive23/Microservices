namespace EmployeeService.Entities.Services
{
    public class EmployeeService : GrpcEmployeeService.GrpcEmployeeServiceBase
    {
        #region Services
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region GET
        public override async Task<GrpcEmployeeResponse> GetAllEmployees(Empty request, ServerCallContext context)
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            var response = new GrpcEmployeeResponse();
            foreach (var emp in employees)
            {
                response.Employee.Add(emp.Adapt<GrpcEmployeeModel>());
            }
            return response;
        }
        #endregion
    }
}
