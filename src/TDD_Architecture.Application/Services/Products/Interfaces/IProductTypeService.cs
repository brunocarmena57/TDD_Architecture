﻿using TDD_Architecture.Application.Models.Http;
using TDD_Architecture.Application.ViewModels.Products;

namespace TDD_Architecture.Application.Services.Products.Interfaces
{
    public interface IProductTypeService
    {
        Task<Result<ProductTypeViewModel>> Put(ProductTypeViewModel product);
        Task<Result<ProductTypeViewModel>> Post(ProductTypeViewModel product);
        Task<Result<IEnumerable<ProductTypeViewModel>>> GetAll();
        Task<Result<ProductTypeViewModel>> GetById(int id);
    }
}
