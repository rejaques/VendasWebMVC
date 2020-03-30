using System;
using System.Collections.Generic;
using System.Linq;

namespace VendasWebMVC.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
