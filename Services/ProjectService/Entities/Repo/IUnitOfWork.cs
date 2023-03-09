namespace ProjectService.Entities.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepo<Project> Projects { get; }
        bool Save();
    }
}
