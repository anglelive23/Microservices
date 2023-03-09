namespace OfferService.Entities.Repos
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repos
        IGenericRepo<Service> Services { get; }
        #endregion

        #region Save
        bool Save();
        #endregion
    }
}
