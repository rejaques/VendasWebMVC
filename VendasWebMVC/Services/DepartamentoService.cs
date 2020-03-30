using System.Linq;
using System.Collections.Generic;
using VendasWebMVC.Data;
using VendasWebMVC.Models;

namespace VendasWebMVC.Services
{
    public class DepartamentoService
    {
        private readonly VendasWebMVCContext _context;

        public DepartamentoService(VendasWebMVCContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Name).ToList();
        }
    }
}
