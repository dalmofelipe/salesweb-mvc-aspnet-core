using System;
using System.Collections.Generic;
using SaleWebMvc.Models.Enums;

namespace SaleWebMvc.Models.ViewModels
{
    public class SaleFormViewModel
    {
        public SaleStatus Status { get; set; }
        public SalesRecord SalesRecord { get; set; }
        public ICollection<Seller> Sellers { get; set; }
    }
}
