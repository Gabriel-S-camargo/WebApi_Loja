using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Models{
    public class Contrato{
        public int Id{ get; set; }
        public int IdCliente { get; set; }
        public Cliente cliente{ get; set; }
        public int IdServico { get; set; }
        public Servico servico{ get; set; }
        public decimal precoContratado { get; set; }
        public DateTime dataContratacao { get; set; }
    }
}