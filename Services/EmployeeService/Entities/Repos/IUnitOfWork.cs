namespace EmployeeService.Entities.Repos
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repos
        IGenericRepo<Employee> Employees { get; }
        #endregion

        #region Save
        bool Save();
        #endregion
    }
}
