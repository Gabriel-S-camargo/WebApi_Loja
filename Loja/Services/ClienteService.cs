using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loja.Models;
using Loja.Data;
namespace Loja.Services
{
    public class ClienteService
    {

        // Atribuir o _dbContext  que sera usado na service para referenciar o seu BD

        private readonly LojaDbContext _dbContext;

        public ClienteService(LojaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Criar os métodos que sera utilizado

        // Metodo para listar todos os Clientes cadastrados

        public async Task<List<Cliente>> GetAllClienteAsync()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        // Metodo para Buscar Cliente por ID

        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }

        // Método de adição de Cliente

        // Metodo de SaveChangesAsync so é usado quando o estado de um registro ja feito no banco de dados é alterado ou deletado ou Criado
        public async Task AddClienteAsync(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);

            await _dbContext.SaveChangesAsync();

        }


        // Metodo de editar um Cliente

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            _dbContext.Entry(cliente).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int Id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(Id);

            if (cliente != null)
            {
                _dbContext.Clientes.Remove(cliente);

                await _dbContext.SaveChangesAsync();
            }
        }
        
    }
}