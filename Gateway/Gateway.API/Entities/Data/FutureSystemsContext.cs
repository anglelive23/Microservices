using Microservices.API.Entities.Models;

namespace Microservices.API.Entities.Data
{
    public class FutureSystemsContext : DbContext
    {
        public FutureSystemsContext(DbContextOptions<FutureSystemsContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
