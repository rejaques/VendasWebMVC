using System.Linq;
using System.Collections.Generic;
using VendasWebMVC.Data;
using VendasWebMVC.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMVC.Services
{
    public class DepartamentoService
    {
        private readonly VendasWebMVCContext _context;

        public DepartamentoService(VendasWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
