namespace ProjectService.Entities.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repos
        IGenericRepo<Project> Projects { get; }
        #endregion

        #region Save
        bool Save();
        #endregion
    }
}
