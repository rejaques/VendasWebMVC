using System;
using VendasWebMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace VendasWebMVC.Models
{
    public class RegistroVenda
    {
        public int Id { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Amount { get; set; }
        public StatusVendas Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroVenda()
        {
        }

        public RegistroVenda(int id, DateTime date, double amount, StatusVendas status, Vendedor vendedor)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
