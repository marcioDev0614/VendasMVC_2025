using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models;
using VendasMVC.Data;
using VendasMVC.Services;
using VendasMVC.Models.ViewModels;

namespace VendasMVC.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly VendedorServico _vendedorServico;
        private readonly DepartamentoServico _departamentoServico;

        public VendedoresController(VendedorServico vendedorServico, DepartamentoServico departamentoServico)
        {
            _vendedorServico = vendedorServico;
            _departamentoServico = departamentoServico;
        }

        public IActionResult Index()
        {

            var list = _vendedorServico.BuscarTodos();

            return View(list);
        }

        public IActionResult Create()
        {
            var departamentos = _departamentoServico.BuscarTodos();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {               
            _vendedorServico.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _vendedorServico.BuscarPorId(id.Value);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            _vendedorServico.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
