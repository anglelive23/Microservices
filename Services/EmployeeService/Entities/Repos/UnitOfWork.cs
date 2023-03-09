namespace EmployeeService.Entities.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Context
        private readonly EmployeeContext _context;
        #endregion

        #region Repos
        public IGenericRepo<Employee> Employees { get; private set; }
        #endregion

        #region Constructors
        public UnitOfWork(EmployeeContext context)
        {
            _context = context;
            Employees = new GenericRepo<Employee>(_context);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion

        #region Save
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}
