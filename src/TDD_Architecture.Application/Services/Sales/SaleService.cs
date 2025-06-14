﻿using AutoMapper;
using TDD_Architecture.Application.Models.Http;
using TDD_Architecture.Application.Services.Sales.Interfaces;
using TDD_Architecture.Application.ViewModels.Sales;
using TDD_Architecture.Domain.Entities.Sales;
using TDD_Architecture.Domain.Enums;
using TDD_Architecture.Domain.Interfaces.Products;
using TDD_Architecture.Domain.Interfaces.Sales;
using TDD_Architecture.Domain.Interfaces.Users;
using TDD_Architecture.Infra.Singletons.Logger.Interfaces;

namespace TDD_Architecture.Application.Services.Sales
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;

        public SaleService(
            ISaleRepository saleRepository,
            IProductRepository productRepository,
            IUserRepository userRepository, 
            ILoggerService loggerService,
            IMapper mapper)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<SaleViewModel>>> GetAll()
        {
            try
            {
                var sales = await _saleRepository.GetAll();

                if (sales is null)
                {
                    _loggerService.LogInfo("Unable to identify sales in the database.");
                    return Result<IEnumerable<SaleViewModel>>.Fail("Unable to identify sales in the database.", (int)HttpStatus.BadRequest);
                }

                var mapSales = _mapper.Map<IEnumerable<SaleViewModel>>(sales);

                return Result<IEnumerable<SaleViewModel>>.Ok(mapSales);

            }
            catch (Exception ex)
            {
                _loggerService.LogError("There was an error listing sales: " + ex.Message);
                return Result<IEnumerable<SaleViewModel>>.Fail("There was an error listing sales: " + ex.Message);
            }

        }

        public async Task<Result<SaleViewModel>> GetById(int id)
        {
            try
            {
                var sale = await _saleRepository.GetById(id);

                if (sale is null)
                {
                    _loggerService.LogInfo("sale not found.");
                    return Result<SaleViewModel>.Fail("sale not found.", (int)HttpStatus.BadRequest);
                }

                var mapSale = _mapper.Map<SaleViewModel>(sale);

                return Result<SaleViewModel>.Ok(mapSale);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("There was an error when searching for the sale: " + ex.Message);
                return Result<SaleViewModel>.Fail("There was an error when searching for the sale: " + ex.Message);
            }
        }

        public async Task<Result<SaleViewModel>> Put(SaleViewModel sale)
        {
            try
            {
                var product = await _productRepository.GetById(sale.ProductId);

                var user = await _userRepository.GetById(sale.UserId);

                if (product is null)
                {
                    _loggerService.LogInfo("Product not found.");
                    return Result<SaleViewModel>.Fail("Product not found.", (int)HttpStatus.BadRequest);
                }

                if (user is null)
                {
                    _loggerService.LogInfo("User not found.");
                    return Result<SaleViewModel>.Fail("User not found.", (int)HttpStatus.BadRequest);
                }

                var mapSale = _mapper.Map<Sale>(sale);

                var result = await _saleRepository.Put(mapSale);

                var mapSaleModel = _mapper.Map<SaleViewModel>(result);

                return Result<SaleViewModel>.Ok(mapSaleModel);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("There was an error editing the sale: " + ex.Message);
                return Result<SaleViewModel>.Fail("There was an error editing the sale: " + ex.Message);
            }
        }

        public async Task<Result<SaleViewModel>> Post(SaleViewModel sale)
        {
            try
            {
                var product = await _productRepository.GetById(sale.ProductId);

                var user = await _userRepository.GetById(sale.UserId);

                if (product is null)
                {
                    _loggerService.LogInfo("Product not found.");
                    return Result<SaleViewModel>.Fail("Product not found.", (int)HttpStatus.BadRequest);
                }

                if (user is null)
                {
                    _loggerService.LogInfo("User not found.");
                    return Result<SaleViewModel>.Fail("User not found.", (int)HttpStatus.BadRequest);
                }

                var mapSale = _mapper.Map<Sale>(sale);

                var result = await _saleRepository.Post(mapSale);

                var mapSaleModel = _mapper.Map<SaleViewModel>(result);

                return Result<SaleViewModel>.Ok(mapSaleModel);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("There was an error registering the sale: " + ex.Message);
                return Result<SaleViewModel>.Fail("There was an error registering the sale: " + ex.Message);
            }
        }

        public async Task<Result<SaleViewModel>> Delete(int saleId)
        {
            try
            {
                var sale = await _saleRepository.GetById(saleId);

                if (sale is null)
                {
                    _loggerService.LogInfo("Sale not found.");
                    return Result<SaleViewModel>.Fail("Sale not found.", (int)HttpStatus.BadRequest);
                }

                var product = await _productRepository.GetById(sale.ProductId);

                var user = await _userRepository.GetById(sale.UserId);

                if (product is null)
                {
                    _loggerService.LogInfo("Product not found.");
                    return Result<SaleViewModel>.Fail("Product not found.", (int)HttpStatus.BadRequest);
                }

                if (user is null)
                {
                    _loggerService.LogInfo("User not found.");
                    return Result<SaleViewModel>.Fail("User not found.", (int)HttpStatus.BadRequest);
                }

                var mapSale = _mapper.Map<Sale>(sale);

                var result = await _saleRepository.Delete(mapSale);

                var mapSaleModel = _mapper.Map<SaleViewModel>(result);

                return Result<SaleViewModel>.Ok(null);
            }
            catch (Exception ex)
            {
                _loggerService.LogError("There was an error deleting the sale: " + ex.Message);
                return Result<SaleViewModel>.Fail("There was an error deleting the sale: " + ex.Message);
            }

        }
    }
}
