using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Data;
using VendasMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasMVC.Services
{
    public class DepartamentoServico
    {
        private readonly BancoContext _bancoContext;

        public DepartamentoServico(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<List<Departamento>> BuscarTodosAsync()
        {
            return await _bancoContext.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task InsertAsync(Departamento departamento)
        {
            _bancoContext.Add(departamento);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task<Departamento> BuscarPorIdAsync(int id)
        {
            return await _bancoContext.Departamento.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Departamento departamento)
        {
            _bancoContext.Update(departamento);
            await _bancoContext.SaveChangesAsync();

        }
        public async Task RemoveAsync(int id)
        {
            var obj = await _bancoContext.Departamento.FindAsync(id);
            _bancoContext.Departamento.Remove(obj);
            await _bancoContext.SaveChangesAsync();
        }
    }
}
