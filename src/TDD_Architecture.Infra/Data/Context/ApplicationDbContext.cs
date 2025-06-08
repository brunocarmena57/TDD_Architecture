using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TDD_Architecture.Domain.Entities.Products;
using TDD_Architecture.Domain.Entities.Sales;
using TDD_Architecture.Domain.Entities.Users;
using TDD_Architecture.Infra.Data.EntitiesConfiguration.Products;
using TDD_Architecture.Infra.Data.EntitiesConfiguration.Sales;
using TDD_Architecture.Infra.Data.EntitiesConfiguration.Users;

namespace TDD_Architecture.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region Users Tables

        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        #region Products Tables

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }

        #endregion

        #region Sales Table

        public DbSet<Sale> Sales { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Users Configuration

            builder.ApplyConfiguration(new UserAddressConfiguration());

            builder.ApplyConfiguration(new UserContactConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());

            #endregion

            #region Products Configuration

            builder.ApplyConfiguration(new ProductTypeConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());

            #endregion

            #region Sales Configuration

            builder.ApplyConfiguration(new SaleConfiguration());

            #endregion
        }
    }
}
