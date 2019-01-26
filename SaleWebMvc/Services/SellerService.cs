using System.Collections.Generic;
using System.Linq;
using SaleWebMvc.Models;

namespace SaleWebMvc.Services
{
    public class SellerService
    {
        private readonly SaleWebMvcContext _context;

        public SellerService(SaleWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Sellers.ToList();
        }
    }
}
