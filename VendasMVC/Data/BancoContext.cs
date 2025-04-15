using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models;

namespace VendasMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        DbSet<Departamento> Departamento { get; set; }
        DbSet<Vendedor> Vendedor { get; set; }
        DbSet<RegistroVenda> Venda { get; set; }
    }
}
