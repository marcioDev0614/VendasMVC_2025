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

        public async Task<List<Vendedor>> BuscarTodosAsync()
        {
            return await _bancoContext.Vendedor.ToListAsync();
        }

        public async Task InsertAsync(Vendedor vendedor)
        {
            //vendedor.Departamento = _bancoContext.Departamento.First();
            _bancoContext.Add(vendedor);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task<Vendedor> BuscarPorIdAsync(int id)
        {
            return await _bancoContext.Vendedor.Include(x => x.Departamento).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _bancoContext.Vendedor.FindAsync(id);
            _bancoContext.Vendedor.Remove(obj);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vendedor vendedor)
        {
            bool temVendedor = await _bancoContext.Vendedor.AnyAsync(x => x.Id == vendedor.Id);

            if (!temVendedor)
            {
                throw new NotFoudException("Id não encontrado");
            }

            try
            {

                _bancoContext.Update(vendedor);
                await _bancoContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
