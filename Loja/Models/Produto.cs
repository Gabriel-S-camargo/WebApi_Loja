using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int FornecedorId { get; set; } 
        public Fornecedor Fornecedor { get; set; }
        public int QuantidadeEstoque { get; set; }
        public ICollection<Venda> Vendas { get; set; } // Define que é uma classe pai , e que vai ter uma FK que vai carregar as infos dessa classe
        public ICollection<Deposito> Depositos { get; set; }
    }
}
