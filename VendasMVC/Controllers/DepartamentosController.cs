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
    public class DepartamentosController : Controller
    {

        private readonly DepartamentoServico _departamentoServico;
        private readonly VendedorServico _vendedorServico;

        public DepartamentosController(DepartamentoServico departamentoServico, VendedorServico vendedorServico)
        {
            _departamentoServico = departamentoServico;
            _vendedorServico = vendedorServico;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> list = await _departamentoServico.BuscarTodosAsync();

            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departamento departamento)
        {

           await _departamentoServico.InsertAsync(departamento);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int? id)
        {
            var departamento = await _departamentoServico.BuscarPorIdAsync(id.Value);
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Departamento departamento)
        {
            await _departamentoServico.UpdateAsync(departamento);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var obj = await _departamentoServico.BuscarPorIdAsync(id);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(int? id)
        {
             await _departamentoServico.RemoveAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }

    }
    
}
