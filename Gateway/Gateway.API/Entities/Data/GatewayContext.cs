using Gateway.API.Entities.Models;

namespace Gateway.API.Entities.Data
{
    public class GatewayContext : DbContext
    {
        public GatewayContext(DbContextOptions<GatewayContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
