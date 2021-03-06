﻿using System.Collections.Generic;
using System.Linq;
using SaleWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SaleWebMvc.Services.Exceptions;
using System.Threading.Tasks;

namespace SaleWebMvc.Services
{
    public class SellerService
    {
        private readonly SaleWebMvcContext _context;

        public SellerService(SaleWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Sellers.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Sellers.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Sellers.Include(obj => obj.Department).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Sellers.FindAsync(id);
                _context.Sellers.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                throw new IntegrityException("Não é possível remover este vendedor, pois ele possui vendas!");
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            var hasObj = await _context.Sellers.AnyAsync(x => x.Id == obj.Id);

            if (!hasObj)
            {
                throw new NotFoundException("Id não encontrado!");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task AddSale(SalesRecord obj)
        {
            var hasObj = await _context.Sellers.AnyAsync(x => x.Id == obj.SellerId);

            if (!hasObj)
            {
                throw new NotFoundException("Id do vendedor não encontrado!");
            }

            try
            {
                var seller = await _context.Sellers.Where(x => x.Id == obj.SellerId).FirstOrDefaultAsync();
                obj.Seller = seller;
                seller.Sales.Add(obj);
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
