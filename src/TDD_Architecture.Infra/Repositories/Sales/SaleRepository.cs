﻿using Microsoft.EntityFrameworkCore;
using TDD_Architecture.Domain.Entities.Sales;
using TDD_Architecture.Domain.Interfaces.Sales;
using TDD_Architecture.Infra.Data.Context;

namespace TDD_Architecture.Infra.Repositories.Sales
{
    public class SaleRepository : ISaleRepository
    {
        private ApplicationDbContext _context;

        public SaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> GetAll()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale> GetById(int id)
        {
            return await _context.Sales.AsNoTracking().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Sale> Put(Sale sale)
        {
            sale.ChangeDate = DateTime.UtcNow;

            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();

            return sale;
        }

        public async Task<Sale> Post(Sale sale)
        {
            sale.CreationDate = DateTime.UtcNow;

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return sale;
        }

        public async Task<Sale> Delete(Sale sale)
        {
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return sale;
        }
    }
}
