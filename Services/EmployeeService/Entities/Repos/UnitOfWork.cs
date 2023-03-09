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

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
