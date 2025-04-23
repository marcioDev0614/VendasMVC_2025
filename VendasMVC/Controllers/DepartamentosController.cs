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
    public class DepartamentosController : Controller
    {

        private readonly DepartamentoServico _departamentoServico;

        public DepartamentosController(DepartamentoServico departamentoServico)
        {
            _departamentoServico = departamentoServico;
        }

        public IActionResult Index()
        {
            List<Departamento> list = _departamentoServico.BuscarTodos();

            return View(list);
        }
    }
}
