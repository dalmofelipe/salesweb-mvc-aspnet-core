using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SaleWebMvc.Models
{
    public class SaleWebMvcContext : DbContext
    {
        public SaleWebMvcContext (DbContextOptions<SaleWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
        public DbSet<Seller> Sellers { get; set; }
    }
}
