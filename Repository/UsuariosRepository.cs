using ApiFormularioNovidades.Interfaces;
using ApiFormularioNovidades.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFormularioNovidades.Repository
{
    public class UsuariosRepository : IUsuarioRepository
    {
        private FormularioDbContext _dbContext = null;

        public UsuariosRepository(FormularioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Usuarios>> GetAll()
        {
            return await _dbContext.Set<Usuarios>().AsNoTracking().ToListAsync();
        }

        public async Task<Usuarios> GetById(string cpf)
        {
            return await _dbContext.Set<Usuarios>().FindAsync(cpf);
        }

        public async Task Add(Usuarios usuario)
        {
            await _dbContext.Set<Usuarios>().AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(string cpf, Usuarios usuario)
        {
            _dbContext.Set<Usuarios>().Update(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(string cpf)
        {
            var usuario = await GetById(cpf);
            _dbContext.Set<Usuarios>().Remove(usuario);
            await _dbContext.SaveChangesAsync();
        }

    }
}
