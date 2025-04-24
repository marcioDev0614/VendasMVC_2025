using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Data;
using VendasMVC.Models;
using Microsoft.EntityFrameworkCore;
using VendasMVC.Services.Exeptions;

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
            return _bancoContext.Vendedor.Include(x => x.Departamento).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _bancoContext.Vendedor.Find(id);
            _bancoContext.Vendedor.Remove(obj);
            _bancoContext.SaveChanges();
        }

        public void Update(Vendedor vendedor)
        {
            if (!_bancoContext.Vendedor.Any(x => x.Id == vendedor.Id))
            {
                throw new NotFoudException("Id não encontrado");
            }

            try
            {

                _bancoContext.Update(vendedor);
                _bancoContext.SaveChanges();

            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
