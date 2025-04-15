using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models.Enums;

namespace VendasMVC.Models
{
    public class RegistroVenda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Quantia { get; set; }
        public SituacaoVenda Situacao { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroVenda() { }

        public RegistroVenda(int id, DateTime data, double quantia, SituacaoVenda situacao, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quantia = quantia;
            Situacao = situacao;
            Vendedor = vendedor;
        }
    }
}
