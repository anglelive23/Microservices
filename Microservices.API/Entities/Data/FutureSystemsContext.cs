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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Service>()
            //    .HasData(new Service()
            //    {
            //        Id = 1,
            //        Name = "Web Development",
            //        Description = "We Design and develop websites with the latest technologies for web development using.",
            //        Brief = ""
            //    },
            //    new Service()
            //    {
            //        Id = 2,
            //        Name = "Mobile App Development",
            //        Description = "We Design and develop Mobile applications with the latest technologies for mobile using.",
            //    },
            //    new Service()
            //    {
            //        Id = 3,
            //        Name = "UI/UX Desing Services",
            //        Description = "We Design Mobile applications and Websites with the latest technologies to meet your needs and goals.",
            //    },
            //    new Service()
            //    {
            //        Id = 4,
            //        Name = "ERP Systems",
            //        Description = "We Design and develop ERP Systmes that can help your business to be managed successfully.",
            //    }
            //);
        }
    }
}
