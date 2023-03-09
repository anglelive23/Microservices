using Utils.REPO;

namespace Microservices.API.Entities.Repos
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepo<Service> Services { get; }
        IGenericRepo<Project> Projects { get; }
        IGenericRepo<Client> Clients { get; }
        IGenericRepo<Employee> Employees { get; }
        int Save();
    }
}
