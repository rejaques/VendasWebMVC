using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace VendasWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="{0} is required")]
        [StringLength(100, MinimumLength = 5)]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]

        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress(ErrorMessage ="Enter a valid email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Data de aniversário")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Salário base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<RegistroVendas> Vendas { get; set; } = new List<RegistroVendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string name, string email, DateTime birthDate, double baseSalary, Departamento departamento)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departamento = departamento;
        }

        public void AddVendas(RegistroVendas sr)
        {
            Vendas.Add(sr);
        }

        public void RemoveVendas(RegistroVendas sr)
        {
            Vendas.Remove(sr);
        }

        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendas
                .Where(d => d.Date >= inicial && d.Date <= final)
                .Sum(d => d.Amount);
        }
    }
}
