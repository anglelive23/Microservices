using ClientService.Entities.Data;

namespace ClientService.Entities.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Services
        private ClientContext _context;
        #endregion

        #region Repos
        public IGenericRepo<Client> Clients { get; private set; }
        #endregion

        #region Constructors
        public UnitOfWork(ClientContext context)
        {
            _context = context;
            Clients = new GenericRepo<Client>(_context);
        }
        #endregion

        #region Save
        public int Save()
        {
            return _context.SaveChanges();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}
