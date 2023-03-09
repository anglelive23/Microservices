namespace ClientService.Entities.Data
{
    public class ClientContext : DbContext
    {
        #region Constructors
        public ClientContext(DbContextOptions<ClientContext> options) : base(options) { }
        #endregion

        #region DataSets
        public DbSet<Client> Clients { get; set; }
        #endregion
    }
}
