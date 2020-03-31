using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasWebMVC.Data;
using VendasWebMVC.Models;

namespace VendasWebMVC.Services
{
    public class RegistroVendaService
    {
        private readonly VendasWebMVCContext _context;

        public RegistroVendaService(VendasWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVenda>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resul = from obj in _context.RegistroVendas select obj;
            
            if(minDate.HasValue)
            {
                resul = resul.Where(x => x.Date >= minDate.Value);
            }     
            if (maxDate.HasValue)
            {
                resul = resul.Where(x => x.Date <= maxDate.Value);
            }

            return await resul
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
