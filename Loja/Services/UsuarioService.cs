using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loja.Models;
using Loja.Data;
namespace Loja.Services
{

    public class UsuarioService
    {
        public readonly LojaDbContext _dbContext;

        public UsuarioService(LojaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Usuario>> GetAllUsuariosAsync()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _dbContext.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> GetUsuarioByLoginAsync(string userLogin)
        {
            var usuario = await _dbContext.Usuarios.SingleOrDefaultAsync(x => x.Login == userLogin);
            return usuario;
        }

        public async Task AddUsuarioAsync(Usuario usuario){
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUsuarioAsync(int id, Usuario usuario){
            _dbContext.Entry(usuario).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUsuarioAsync(int id){
            var usuario = await _dbContext.Usuarios.FindAsync(id);

            if(usuario != null){
                _dbContext.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}