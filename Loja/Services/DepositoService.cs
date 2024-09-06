using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loja.Models;
using Loja.Data;
namespace Loja.Services
{
    public class DepositoService
    {
        public readonly LojaDbContext _dbContext;

        public DepositoService(LojaDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<List<Deposito>> GetAllDepositoAsync()
        {
            return await _dbContext.Depositos.ToListAsync();
        }

        public async Task<Deposito> GetDepositoById(int id)
        {

            return await _dbContext.Depositos.FindAsync(id);
            
        }

        public async Task AddDepositoAsync(Deposito deposito){
            _dbContext.Depositos.Add(deposito);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDeposito(Deposito deposito){
            _dbContext.Entry(deposito).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDeposito(int id){
            var deposito = await _dbContext.Depositos.FindAsync(id);

            if(deposito != null){
                _dbContext.Remove(deposito);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}