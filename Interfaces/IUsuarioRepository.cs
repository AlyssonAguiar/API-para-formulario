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

        Task<Usuarios> GetById(string cpf);

        Task Add(Usuarios usuario);

        Task Update(string cpf, Usuarios usuario);

        Task Delete(string cpf);
    }
}
