using ApiFormularioNovidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFormularioNovidades.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuarios>> GetAll();

        Task<Usuarios> GetById(int id);

        Task Add(Usuarios usuario);

        Task Update(int id, Usuarios usuario);

        Task Delete(int id);
    }
}
