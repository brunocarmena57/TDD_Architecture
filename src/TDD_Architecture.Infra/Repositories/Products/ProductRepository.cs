﻿using Microsoft.EntityFrameworkCore;
using TDD_Architecture.Domain.Entities.Products;
using TDD_Architecture.Domain.Interfaces.Products;
using TDD_Architecture.Infra.Data.Context;

namespace TDD_Architecture.Infra.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.AsNoTracking().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> Put(Product product)
        {
            product.ChangeDate = DateTime.UtcNow;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Post(Product product)
        {
            product.CreationDate = DateTime.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
