using Microsoft.EntityFrameworkCore;
//using System.Data.Entity.Core.Metadata;
//using Microsoft.AspNetCore.Http.Metadata;

using Loja.Models;

namespace Loja.Data
{

    public class LojaDbContext : DbContext
    {
        public LojaDbContext(DbContextOptions<LojaDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Contrato> Contratos  { get; set; }

        // Aqui no OnModelCreating que voce vai definir algumas a relação entre as chaves  e como será a exclusão
        // padrão -> base,OnModelCreating 
        //           modelBuilder.Entity<Nome da Classe>()
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar a relação entre Produto e Fornecedor
            modelBuilder.Entity<Produto>()
                // relação de 1 para varios - 1 produto tem 1 fornecedor, mas um fornecedor pode ter vários produtos
                .HasOne(produto => produto.Fornecedor)
                .WithMany(fornecedor => fornecedor.Produtos)
                .HasForeignKey(produto => produto.FornecedorId) // Define qual a tabela que vai ter a FK
                .OnDelete(DeleteBehavior.Cascade);// Define o comportamento de exclusão

            modelBuilder.Entity<Venda>()
                .HasOne(venda => venda.Produto)
                .WithMany(produto => produto.Vendas)
                .HasForeignKey(venda => venda.IdProduto)
                .OnDelete(DeleteBehavior.Cascade);
                
            modelBuilder.Entity<Venda>()
            .HasOne(venda => venda.Cliente)
            .WithMany(cliente => cliente.Vendas)
            .HasForeignKey(venda => venda.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Deposito>()
            .HasOne(deposito => deposito.Produto)
            .WithMany(produto => produto.Depositos)
            .HasForeignKey(deposito => deposito.IdProduto)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contrato>()
            .HasOne(contrato => contrato.cliente)
            .WithMany(cliente => cliente.Contratos)
            .HasForeignKey(contrato => contrato.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contrato>()
            .HasOne(contrato => contrato.servico)
            .WithMany(servico => servico.Contratos)
            .HasForeignKey(Contrato => Contrato.IdServico)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }

}