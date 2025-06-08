using Microsoft.Extensions.DependencyInjection;
using TDD_Architecture.Application.Services.Login.Interfaces;
using TDD_Architecture.Application.Services.Login;
using TDD_Architecture.Application.Services.Products.Interfaces;
using TDD_Architecture.Application.Services.Products;
using TDD_Architecture.Application.Services.Sales.Interfaces;
using TDD_Architecture.Application.Services.Sales;
using TDD_Architecture.Application.Services.Users.Interfaces;
using TDD_Architecture.Application.Services.Users;
using TDD_Architecture.Infra.Authentication;

namespace TDD_Architecture.Application
{
    public static class Startup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            #region Authentication Services
            services.AddScoped<TokenGenerator>();
            #endregion

            #region Users Services

            services.AddScoped<IUserService, UserService>();

            #endregion

            #region Products Services

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();

            #endregion

            #region Sales Services

            services.AddScoped<ISaleService, SaleService>();

            #endregion

            #region Login Services

            services.AddScoped<ILoginService, LoginService>();

            #endregion

            return services;
        }
    }
}
