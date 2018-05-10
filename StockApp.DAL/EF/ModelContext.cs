namespace StockApp.DAL.EF
{
    using StockApp.DAL.Entities;
    using System.Data.Entity;

    public class ModelContext : DbContext
    {
        static ModelContext()
        {
            Database.SetInitializer(new InitializeDb());
        }

        public ModelContext()
            : base("name=ModelContext")
        {
        }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
    }
}