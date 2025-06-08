using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDD_Architecture.Domain.Interfaces.Products;
using TDD_Architecture.Domain.Interfaces.Sales;
using TDD_Architecture.Domain.Interfaces.Users;
using TDD_Architecture.Infra.Data.Context;
using TDD_Architecture.Infra.Repositories.Products;
using TDD_Architecture.Infra.Repositories.Sales;
using TDD_Architecture.Infra.Repositories.Users;
using TDD_Architecture.Infra.Singletons.Cache;
using TDD_Architecture.Infra.Singletons.Cache.Interfaces;
using TDD_Architecture.Infra.Singletons.Logger;
using TDD_Architecture.Infra.Singletons.Logger.Interfaces;

namespace TDD_Architecture.Infra
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                      .EnableSensitiveDataLogging());

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            #region Users Repositories

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserAddressRepository, UserAddresRepository>();
            services.AddTransient<IUserContactRepository, UserContactRepository>();

            #endregion

            #region Products Repositories

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();

            #endregion

            #region Sale Repository

            services.AddTransient<ISaleRepository, SaleRepository>();

            #endregion

            #region Singletons

            services.AddSingleton<ICacheService, CacheService>();
            services.AddSingleton<ILoggerService, LoggerService>();

            #endregion

            return services;
        }
    }
}
