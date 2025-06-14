﻿using Microsoft.EntityFrameworkCore;
using TDD_Architecture.Domain.Entities.Products;
using TDD_Architecture.Domain.Interfaces.Products;
using TDD_Architecture.Infra.Data.Context;

namespace TDD_Architecture.Infra.Repositories.Products
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private ApplicationDbContext _context;

        public ProductTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductType>> GetAll()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<ProductType> GetById(int id)
        {
            return await _context.ProductTypes.AsNoTracking().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProductType> Put(ProductType productType)
        {
            productType.ChangeDate = DateTime.UtcNow;

            _context.ProductTypes.Update(productType);
            await _context.SaveChangesAsync();

            return productType;
        }

        public async Task<ProductType> Post(ProductType productType)
        {
            productType.CreationDate = DateTime.UtcNow;

            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();

            return productType;
        }

        public async Task<ProductType> Delete(ProductType productType)
        {
            _context.ProductTypes.Remove(productType);
            await _context.SaveChangesAsync();

            return productType;
        }
    }
}
