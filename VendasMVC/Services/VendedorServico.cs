using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Data;
using VendasMVC.Models;

namespace VendasMVC.Services
{
    public class VendedorServico
    {
        private readonly BancoContext _bancoContext;

        public VendedorServico(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Vendedor> BuscarTodos()
        {
            return _bancoContext.Vendedor.ToList();
        }

        public void Insert(Vendedor vendedor)
        {
            //vendedor.Departamento = _bancoContext.Departamento.First();
            _bancoContext.Add(vendedor);
            _bancoContext.SaveChanges();
        }

        public Vendedor BuscarPorId(int id)
        {
            return _bancoContext.Vendedor.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _bancoContext.Vendedor.Find(id);
            _bancoContext.Vendedor.Remove(obj);
            _bancoContext.SaveChanges();
        }
    }
}
