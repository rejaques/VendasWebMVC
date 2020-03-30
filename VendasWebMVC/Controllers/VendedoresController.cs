using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VendasWebMVC.Services;
using VendasWebMVC.Models;
using VendasWebMVC.Models.ViewModels;
using VendasWebMVC.Services.Exceptions;
using System.Diagnostics;

namespace VendasWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorServico;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorServico, DepartamentoService departamentoService)
        {
            _vendedorServico = vendedorServico;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var list = _vendedorServico.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var departments = _departamentoService.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Evitar ataques de autenticação
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorServico.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            
            var obj = _vendedorServico.FindById(id.Value);
            
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedorServico.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _vendedorServico.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not found"});
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided" });
            }

            var obj = _vendedorServico.FindById(id.Value);
            
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not found"});
            }

            List<Departamento> departamentos = _departamentoService.FindAll();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Vendedor vendedor)
        {
            if(id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            try
            {
                _vendedorServico.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new {message = e.Message});
            }
            catch(DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new {message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}