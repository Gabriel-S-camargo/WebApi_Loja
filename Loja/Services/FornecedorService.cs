using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loja.Models;
using Loja.Data;
namespace Loja.Services
{
    public class FornecedorService
    {

        private readonly LojaDbContext _dbContext;

        // Builder da classe
        public FornecedorService(LojaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Métodos para a web API

        // Método para Buscar todos os fornecedores

        // Usar List quando o método vai retornar varios resultados 
        public async Task<List<Fornecedor>> GetAllFornecedorAsync()
        {
            return await _dbContext.Fornecedores.ToListAsync();
        }

        // Método para Buscar Fornecedor por Id

        // Task + <Classe> quando for retornar um Objeto
        public async Task<Fornecedor> GetFornecedorAsync(int id)
        {
            return await _dbContext.Fornecedores.FindAsync(id);
        }

        // Método para adicionar um fornecedor
        // Metodo não vai retornar valor pois não faz busca
        public async Task AddFornecedorAsync(Fornecedor fornecedor)
        {
            _dbContext.Fornecedores.Add(fornecedor);

            await _dbContext.SaveChangesAsync();
        }

        // Método para editar um fornecedor

        public async Task UpdateFornecedorAsync(Fornecedor fornecedor)
        {
            _dbContext.Entry(fornecedor).State = EntityState.Modified;
            // ENTRY faz com que o entity acesse o objeto marcado no parentesses e o .state serve para falar que o estado dele ira receber outro valor
            // que sera o MODIFIED
            // o estado dessa entitdade é marcado como MODIFIED para o entity framework saber que a entidade foi atualizada e que precisa atualizar ela no BD
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFornecedorAsync(int Id)
        {
            var fornecedor = await _dbContext.Fornecedores.FindAsync(Id);

            if (fornecedor != null)
            {
                _dbContext.Fornecedores.Remove(fornecedor);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}