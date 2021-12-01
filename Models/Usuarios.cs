using System;
using System.Collections.Generic;

namespace ApiFormularioNovidades.Models
{
    public partial class Usuarios
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
    }
}
