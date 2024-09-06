using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Models
{
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime dataVenda { get; set; }
        public int NumNotaFiscal { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public int IdProduto { get; set; } // Propiedade que vai Receber a FK
        public Produto Produto { get; set; } // Propiedade de navegação do Entity
        public int quantidadeVendida { get; set; }
        public double valorVenda { get; set; }
    }
}
