namespace EmployeeService.Entities.Data
{
    public class EmployeeContext : DbContext
    {
        #region Constructors
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
        #endregion

        #region DbSets
        public DbSet<Employee> Employees { get; set; }
        #endregion
    }
}
