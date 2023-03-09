namespace OfferService.Entities.Repos
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepo<Service> Services { get; }
        bool Save();
    }
}
