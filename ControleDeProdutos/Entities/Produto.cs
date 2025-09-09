using ControleDeProdutos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeProdutos.Entities
{
    public class Produto
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public double ValorUnitario { get; set; }
        public int Estoque { get; set; }
        public string Fabricante { get; set; }

    }
}
