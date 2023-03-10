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
            response.Employee.AddRange(employees.Adapt<IList<GrpcEmployeeModel>>());
            return response;
        }

        public override async Task<GrpcEmployeeModel> GetEmployeeById(GrpcEmployeeId request, ServerCallContext context)
        {
            var employee = await _unitOfWork.Employees.FindAsync(e => e.Id == request.Id);
            return employee.Adapt<GrpcEmployeeModel>();
        }
        #endregion
    }
}
