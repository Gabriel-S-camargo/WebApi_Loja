using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loja.Models;
using Loja.Data;
namespace Loja.Services{
    public class ServicoService{
        private readonly LojaDbContext _dbContext;

        public ServicoService(LojaDbContext dbContext){
            _dbContext = dbContext;
        }

        public async Task AddServicoAsync(Servico servico){
            _dbContext.Servicos.Add(servico);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Servico> GetServicoByIdAsync(int id){
            var servico = await _dbContext.Servicos.FindAsync(id);

            if(servico !=null){
                return servico;
            }

            return null;
        }

        public async Task UpdateServicoAsync(Servico servico){
            _dbContext.Entry(servico).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
    }
}