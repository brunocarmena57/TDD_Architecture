﻿using AutoMapper;
using TDD_Architecture.Application.Models.Http;
using TDD_Architecture.Application.Services.Products.Interfaces;
using TDD_Architecture.Application.ViewModels.Products;
using TDD_Architecture.Domain.Entities.Products;
using TDD_Architecture.Domain.Enums;
using TDD_Architecture.Domain.Interfaces.Products;
using TDD_Architecture.Infra.Singletons.Cache.Interfaces;
using TDD_Architecture.Infra.Singletons.Logger.Interfaces;

namespace TDD_Architecture.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly ILoggerService _loggerService;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository productRepository,
            IProductTypeRepository productTypeRepository,
            ILoggerService loggerService,
            ICacheService cacheService,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _loggerService = loggerService;
            _cacheService = cacheService;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ProductViewModel>>> GetAll()
        {
            try
            {
                var products = await _productRepository.GetAll();

                if (products is null)
                {
                    _loggerService.LogInfo("Unable to identify products in the database.");
                    return Result<IEnumerable<ProductViewModel>>.Fail("Unable to identify products in the database.", (int)HttpStatus.BadRequest);
                }

                var mapProducts = _mapper.Map<IEnumerable<ProductViewModel>>(products);

                return Result<IEnumerable<ProductViewModel>>.Ok(mapProducts);

            }
            catch (Exception ex)
            {
                _loggerService.LogError("There was an error listing products: " + ex.Message);
                return Result<IEnumerable<ProductViewModel>>.Fail("There was an error listing products: " + ex.Message);
            }

        }

        public async Task<Result<ProductViewModel>> GetById(int id)
        {
            try
            {
                string cacheKey = $"Product-{id}";

                var cachedProduct = _cacheService.Get<Result<ProductViewModel>>(cacheKey);
                if (cachedProduct != null)
                {
                    return cachedProduct;
                }

                var product = await _productRepository.GetById(id);

                if (product is null)
                {
                    _loggerService.LogInfo("Unable to identify product in the database.");
                    return Result<ProductViewModel>.Fail("Unable to identify product in the database.", (int)HttpStatus.BadRequest);
                }

                var mapProduct = _mapper.Map<ProductViewModel>(product);

                return Result<ProductViewModel>.Ok(mapProduct);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("There was an error when searching for the product: " + ex.Message);
                return Result<ProductViewModel>.Fail("There was an error when searching for the product: " + ex.Message);
            }

        }

        public async Task<Result<ProductViewModel>> Put(ProductViewModel product)
        {
            try
            {
                var productType = await _productTypeRepository.GetById(product.ProductTypeId);

                if (productType is null)
                {
                    _loggerService.LogInfo("product type not found.");
                    return Result<ProductViewModel>.Fail("product type not found.", (int)HttpStatus.BadRequest);
                }

                var mapProduct = _mapper.Map<Product>(product);

                var result = await _productRepository.Put(mapProduct);

                var mapProductModel = _mapper.Map<ProductViewModel>(result);

                return Result<ProductViewModel>.Ok(mapProductModel);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("There was an error editing the product: " + ex.Message);
                return Result<ProductViewModel>.Fail("There was an error editing the product: " + ex.Message);
            }
        }

        public async Task<Result<ProductViewModel>> Post(ProductViewModel product)
        {
            try
            {
                var productType = await _productTypeRepository.GetById(product.ProductTypeId);

                if (productType is null)
                {
                    _loggerService.LogInfo("product type not found.");
                    return Result<ProductViewModel>.Fail("product type not found.", (int)HttpStatus.BadRequest);
                }

                var mapProduct = _mapper.Map<Product>(product);

                var result = await _productRepository.Post(mapProduct);

                var mapProductModel = _mapper.Map<ProductViewModel>(result);

                return Result<ProductViewModel>.Ok(mapProductModel);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("There was an error registering the product: " + ex.Message);
                return Result<ProductViewModel>.Fail("There was an error registering the product: " + ex.Message);
            }
        }

        public async Task<Result<ProductViewModel>> Delete(int productId)
        {
            try
            {
                var product = await _productRepository.GetById(productId);

                if (product is null)
                {
                    _loggerService.LogInfo("product not found.");
                    return Result<ProductViewModel>.Fail("product not found.", (int)HttpStatus.BadRequest);
                }

                var productType = await _productTypeRepository.GetById(product.ProductTypeId);

                if (productType is null)
                {
                    _loggerService.LogInfo("product type not found.");
                    return Result<ProductViewModel>.Fail("product type not found.", (int)HttpStatus.BadRequest);
                }

                var mapProduct = _mapper.Map<Product>(product);

                var result = await _productRepository.Delete(mapProduct);

                var mapProductModel = _mapper.Map<ProductViewModel>(result);

                return Result<ProductViewModel>.Ok(mapProductModel);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("There was an error deleting the product: " + ex.Message);
                return Result<ProductViewModel>.Fail("There was an error deleting the product: " + ex.Message);
            }

        }
    }
}
