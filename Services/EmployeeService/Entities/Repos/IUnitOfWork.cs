namespace EmployeeService.Entities.Repos
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepo<Employee> Employees { get; }
        bool Save();
    }
}
