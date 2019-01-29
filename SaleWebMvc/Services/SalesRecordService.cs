using SaleWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SaleWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SaleWebMvcContext _context;

        public SalesRecordService(SaleWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var query = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                query = query.Where(x => x.Date >= minDate);
            }

            if (maxDate.HasValue)
            {
                query = query.Where(x => x.Date <= maxDate);
            }

            return await query
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var query = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                query = query.Where(x => x.Date >= minDate);
            }

            if (maxDate.HasValue)
            {
                query = query.Where(x => x.Date <= maxDate);
            }

            return await query
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }
    }
}
