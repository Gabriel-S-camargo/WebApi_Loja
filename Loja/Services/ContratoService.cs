using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loja.Models;
using Loja.Data;
namespace Loja.Services{
    public class ContratoService{
        private readonly LojaDbContext _dbContext;

        public ContratoService(LojaDbContext dbContext){
            _dbContext = dbContext;
        }

        public async Task AddContratoAsync(Contrato contrato){
            _dbContext.Contratos.Add(contrato);

            await _dbContext.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<dynamic>>  GetAllContratosClienteAsync(int id){
            return await _dbContext.Contratos
            .Where(contrato => contrato.IdCliente == id)
            .Select(contrato=> new{
                contrato.Id,
                contrato.IdCliente,
                ClienteNome = contrato.cliente.Nome,
                contrato.IdServico,
                NomeServico = contrato.servico.Nome,
                contrato.precoContratado,
                contrato.dataContratacao
            })
            .ToListAsync();
        }
    }
}