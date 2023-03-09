namespace ProjectService.Entities.Data
{
    public class ProjectContext : DbContext
    {
        #region Constructors
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }
        #endregion

        #region DbSets
        public DbSet<Project> Projects { get; set; }
        #endregion
    }
}
