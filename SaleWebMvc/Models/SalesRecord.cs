using System;
using System.ComponentModel.DataAnnotations;
using SaleWebMvc.Models.Enums;

namespace SaleWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe uma Data!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Informe o Valor")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Informe o status da compra")]
        public SaleStatus Status { get; set; }

        public Seller Seller { get; set; }

        [Required(ErrorMessage = "Selecione um Vendedor")]
        public int SellerId { get; set; }


        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
