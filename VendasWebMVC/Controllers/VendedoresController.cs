using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Services;
using VendasWebMVC.Models;

namespace VendasWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorServico;

        public VendedoresController(VendedorService vendedorServico)
        {
            _vendedorServico = vendedorServico;
        }

        public IActionResult Index()
        {
            var list = _vendedorServico.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Evitar ataques de autenticação
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorServico.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}