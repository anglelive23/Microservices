namespace OfferService.Entities.Data
{
    public class OfferContext : DbContext
    {
        #region Constructors
        public OfferContext(DbContextOptions<OfferContext> options) : base(options) { }
        #endregion

        #region DbSets
        public DbSet<Service> Services { get; set; }
        #endregion
    }
}
