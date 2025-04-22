using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models;
using VendasMVC.Data;
using VendasMVC.Services;

namespace VendasMVC.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly VendedorServico _vendedorServico;

        public VendedoresController(VendedorServico vendedorServico)
        {
            _vendedorServico = vendedorServico;
        }

        public IActionResult Index()
        {

            var list = _vendedorServico.BuscarTodos();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
           _vendedorServico.Insert(vendedor);

            return RedirectToAction(nameof(Index));
        }
    }
}
