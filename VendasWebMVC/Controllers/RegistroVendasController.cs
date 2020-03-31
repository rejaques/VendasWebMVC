using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Services;

namespace VendasWebMVC.Controllers
{
    public class RegistroVendasController : Controller
    {
        private readonly RegistroVendaService _registroVendedorService;

        public RegistroVendasController(RegistroVendaService vendedorService)
        {
            _registroVendedorService = vendedorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(2018, 1, 1);
            }
                
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            } 

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var resul = await _registroVendedorService.FindByDateAsync(minDate, maxDate);

            return View(resul);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}