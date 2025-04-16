using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models;
using VendasMVC.Data;

namespace VendasMVC.Controllers
{
    public class DepartamentosController : Controller

    {

        private readonly BancoContext _bancoContext;

        public DepartamentosController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public IActionResult Index()
        {
            List<Departamento> list = _bancoContext.Departamento.ToList();
            
            return View(list);
        }
    }
}
