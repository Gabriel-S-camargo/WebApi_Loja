using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loja.Models;
using Loja.Data;
namespace Loja.Services
{
    public class VendaService
    {
        public readonly LojaDbContext _dbContext;

        public VendaService(LojaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Venda>> GetAllVendasAsync()
        {
            return await _dbContext.Vendas.ToListAsync();
        }

        public async Task<Venda> GetVendaByIdAsync(int id)
        {
            return await _dbContext.Vendas.FindAsync(id);
        }

        public async Task AddVendaAsync(Venda venda)
        {
            _dbContext.Vendas.Add(venda);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateVendaAsync(Venda venda)
        {
            _dbContext.Entry(venda).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteVendaAsync(int id)
        {
            var venda = await _dbContext.Vendas.FindAsync(id);
            if (venda != null)
            {

                _dbContext.Vendas.Remove(venda);
                await _dbContext.SaveChangesAsync();
            }

        }

        // Consultar vendas por produto (detalhada)
    public async Task<IEnumerable<dynamic>> ConsultarVendasPorProdutoDetalhada(int idProduto)
    {
        return await _dbContext.Vendas
            .Where(v => v.IdProduto == idProduto)
            .Select(v => new 
            {
                v.Id,
                v.dataVenda,
                ProdutoNome = v.Produto.Nome,
                ClienteNome = v.Cliente.Nome,
                v.Produto.Preco,
                v.valorVenda
            })
            .ToListAsync();
    }

    // Consultar vendas por produto (sumarizada)
    // Aqui é onde definimos Buscas específicas para a classe
    public async Task<dynamic> ConsultarVendasPorProdutoSumarizada(int idProduto)
    {
        return await _dbContext.Vendas
            .Where(v => v.IdProduto == idProduto)
            .GroupBy(v => v.Produto.Nome)
            .Select(g => new 
            {
                ProdutoNome = g.Key,
                QuantidadeTotal = g.Sum(v => v.valorVenda),
                PrecoTotal = g.Sum(v => v.Produto.Preco)
            })
            .FirstOrDefaultAsync();
    }

    // Consultar vendas por cliente (detalhada)
    public async Task<IEnumerable<dynamic>> ConsultarVendasPorClienteDetalhada(int idCliente)
    {
        return await _dbContext.Vendas
            .Where(v => v.IdCliente == idCliente)
            .Select(v => new 
            {
                v.Id,
                v.dataVenda,
                ProdutoNome = v.Produto.Nome,
                v.Produto.Preco,
                v.valorVenda
            })
            .ToListAsync();
    }

    // Consultar vendas por cliente (sumarizada)
    public async Task<dynamic> ConsultarVendasPorClienteSumarizada(int idCliente)
    {
        return await _dbContext.Vendas
            .Where(v => v.IdCliente == idCliente)
            .GroupBy(v => v.Cliente.Nome)
            .Select(g => new 
            {
                ClienteNome = g.Key,
                QuantidadeTotal = g.Sum(v => v.valorVenda),
                PrecoTotal = g.Sum(v => v.Produto.Preco)
            })
            .FirstOrDefaultAsync();
    }

    // Consultar produtos no depósito / estoque (sumarizada)
    public async Task<IEnumerable<dynamic>> ConsultarProdutosNoDepositoSumarizada(int idDeposito)
    {
        return await _dbContext.Depositos
            .Where(d => d.Id == idDeposito)
            .Select(d => new 
            {
                d.Produto.Nome,
                d.Produto.QuantidadeEstoque
            })
            .ToListAsync();
    }

    // Consultar a quantidade de um produto no depósito / estoque
    public async Task<dynamic> ConsultarQuantidadeProdutoDeposito(int idProduto)
    {
        return await _dbContext.Produtos
            .Where(p => p.Id == idProduto)
            .Select(p => new 
            {
                p.Nome,
                p.QuantidadeEstoque
            })
            .FirstOrDefaultAsync();
    }
    }
}