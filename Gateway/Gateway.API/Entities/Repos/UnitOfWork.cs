using Utils.REPO;

namespace Microservices.API.Entities.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Services
        private FutureSystemsContext _context;
        #endregion

        #region Repos
        public IGenericRepo<Service> Services { get; private set; }
        public IGenericRepo<Project> Projects { get; private set; }
        public IGenericRepo<Client> Clients { get; private set; }
        public IGenericRepo<Employee> Employees { get; private set; }
        #endregion

        #region Constructors
        public UnitOfWork(FutureSystemsContext context)
        {
            _context = context;
            Services = new GenericRepo<Service>(_context);
            Projects = new GenericRepo<Project>(_context);
            Clients = new GenericRepo<Client>(_context);
            Employees = new GenericRepo<Employee>(_context);
        }
        #endregion

        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
