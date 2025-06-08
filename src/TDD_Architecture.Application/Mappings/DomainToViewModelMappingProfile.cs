using AutoMapper;
using TDD_Architecture.Application.ViewModels.Products;
using TDD_Architecture.Application.ViewModels.Sales;
using TDD_Architecture.Application.ViewModels.Users;
using TDD_Architecture.Domain.Entities.Products;
using TDD_Architecture.Domain.Entities.Sales;
using TDD_Architecture.Domain.Entities.Users;

namespace TDD_Architecture.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            #region Users Profile

            CreateMap<User, UserViewModel>();
            CreateMap<UserAddress, UserAddressViewModel>();
            CreateMap<UserContact, UserContactViewModel>();

            #endregion

            #region Products Profile

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductType, ProductTypeViewModel>();

            #endregion

            #region Sales Profile

            CreateMap<Sale, SaleViewModel>();

            #endregion
        }
    }
}
