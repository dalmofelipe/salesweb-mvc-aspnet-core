using System;

namespace SaleWebMvc.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string mesagem) : base(mesagem)
        {
        }
    }
}
