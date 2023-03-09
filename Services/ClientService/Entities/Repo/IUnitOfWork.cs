using ClientService.Entities.Models;

namespace ClientService.Entities.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repos
        IGenericRepo<Client> Clients { get; }
        #endregion

        #region Save
        int Save();
        #endregion
    }
}
