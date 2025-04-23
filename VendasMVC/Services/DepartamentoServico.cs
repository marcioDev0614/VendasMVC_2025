using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Data;
using VendasMVC.Models;

namespace VendasMVC.Services
{
    public class DepartamentoServico
    {
        private readonly BancoContext _bancoContext;

        public DepartamentoServico(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Departamento> BuscarTodos()
        {
            return _bancoContext.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
