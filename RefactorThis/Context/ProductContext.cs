using refactor_me.ConfigurationProvider;
using System.Data.Entity;

namespace refactor_this.Context
{
    public partial class ProductContext : DbContext
    {
        private IAppConfigProvider config;
        public ProductContext(IAppConfigProvider _config)
            : base(_config.GetConnectionString())
        {
            config = _config;
        }

        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<TblProductOption> TblProductOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}