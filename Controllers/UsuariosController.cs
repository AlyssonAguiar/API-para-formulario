using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFormularioNovidades.Interfaces;
using ApiFormularioNovidades.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFormularioNovidades.Controller
{
    [Route("FormularioApi/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository repository;

        public UsuariosController(IUsuarioRepository context)
        {
            repository = context;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            var usuarios = await repository.GetAll();

            if (usuarios == null)
                return BadRequest();
            return Ok(usuarios.ToList());
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuario(int id)
        {
            var usuario = await repository.GetById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<IActionResult> AddUsuario([FromBody] Usuarios usuario)
        {
            if (usuario == null)
                return BadRequest("Usuario não pode ser cadastrado com sucesso!");
            await repository.Add(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.UsuarioId }, usuario);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(int id, Usuarios usuario)
        {
            if (id != usuario.UsuarioId)
                return BadRequest("O Id informado não corresponde a um id salvo!");
            try
            {
                await repository.Update(id, usuario);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
            return Ok("Atualização do usuario realizada com sucesso!");
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuarios>> DeleteUsuario(int id)
        {
            var usuario = await repository.GetById(id);
            if (usuario == null)
            {
                return NotFound($"Usuário com cpf: {id} foi não encontrado");
            }
            await repository.Delete(id);
            return Ok(usuario);
        }

    }
}