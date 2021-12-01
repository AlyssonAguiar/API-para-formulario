using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFormularioNovidades.Interfaces;
using ApiFormularioNovidades.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFormularioNovidades.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet("{cpf}")]
        public async Task<ActionResult<Usuarios>> GetUsuario(string cpf)
        {
            var usuarios = await repository.GetById(cpf);

            if (usuarios == null)
                return NotFound("Usuario não encontrado pelo CPF informado");
            return Ok(usuarios);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<IActionResult> AddUsuario([FromBody] Usuarios usuario)
        {
            if (usuario == null)
                return BadRequest("Usuario não pode ser cadastrado com sucesso!");
            await repository.Add(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { cpf = usuario.Cpf }, usuario);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{cpf}")]
        public async Task<IActionResult> PutUsuarios(string cpf, Usuarios usuario)
        {
            if (cpf != usuario.Cpf)
                return BadRequest("O CPF informado não corresponde a um CPF salvo!");
            try
            {
                await repository.Update(cpf, usuario);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
            return Ok("Atualização do usuario realizada com sucesso!");
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{cpf}")]
        public async Task<ActionResult<Usuarios>> DeleteUsuario(string cpf)
        {
            var usuario = await repository.GetById(cpf);
            if (usuario == null)
            {
                return NotFound($"Produto de {cpf} foi não encontrado");
            }
            await repository.Delete(cpf);
            return Ok(usuario);
        }
    }
}
