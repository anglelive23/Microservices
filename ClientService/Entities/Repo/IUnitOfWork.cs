using ClientService.Entities.Models;

namespace ClientService.Entities.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepo<Client> Clients { get; }
        int Save();
    }
}
