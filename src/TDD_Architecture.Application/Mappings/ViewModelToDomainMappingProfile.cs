using AutoMapper;
using TDD_Architecture.Application.ViewModels.Products;
using TDD_Architecture.Application.ViewModels.Sales;
using TDD_Architecture.Application.ViewModels.Users;
using TDD_Architecture.Domain.Entities.Products;
using TDD_Architecture.Domain.Entities.Sales;
using TDD_Architecture.Domain.Entities.Users;

namespace TDD_Architecture.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region Users Profile

            CreateMap<UserViewModel, User>();
            CreateMap<UserAddressViewModel, UserAddress>();
            CreateMap<UserContactViewModel, UserContact>();

            #endregion

            #region Products Profile

            CreateMap<ProductViewModel, Product>();
            CreateMap<ProductTypeViewModel, ProductType>();

            #endregion

            #region Sales Profile

            CreateMap<SaleViewModel, Sale>();

            #endregion
        }
    }
}
