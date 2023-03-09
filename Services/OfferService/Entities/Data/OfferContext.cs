using OfferService.Entities.Models;

namespace OfferService.Entities.Data
{
    public class OfferContext : DbContext
    {
        public OfferContext(DbContextOptions<OfferContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }
    }
}
