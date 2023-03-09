using OfferService.Entities.Data;

namespace OfferService.Entities.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Context
        private readonly OfferContext _context;
        #endregion

        #region Repos
        public IGenericRepo<Service> Services { get; private set; }
        #endregion

        #region Constructors
        public UnitOfWork(OfferContext context)
        {
            _context = context;
            Services = new GenericRepo<Service>(_context);
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
