using Escola.API.DTO;
using Escola.API.Exceptions;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Controllers 
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        public readonly IUsuarioService _services;

        public UsuarioController(IUsuarioService service)
        {
            _services = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<UsuarioDTO> Cadastrar([FromBody] UsuarioDTO usuarioDTO)
        {
            Usuario usuario = new Usuario(usuarioDTO);
            var resultado = _services.Criar(usuario);
            return Created(Request.PathBase, new UsuarioGetDTO(resultado));
        }

        [Authorize(Roles = "professor, alunos")]
        [HttpGet("{login}")]
        public ActionResult<UsuarioGetDTO> ObterBoletimIdAluno([FromRoute] string login)
        {
            Usuario usuario = _services.ObterPorId(login);
            return Ok(new UsuarioGetDTO(usuario));
        }

        [Authorize(Roles = "professor, alunos")]
        [HttpGet]
        public ActionResult<List<UsuarioGetDTO>> ObterBoletins()
        {
            List<Usuario> usuario = _services.ObterTodos();
            List<UsuarioGetDTO> usuariosDTOs = usuario.Select(x => new UsuarioGetDTO(x)).ToList();
            return Ok(usuariosDTOs);
        }

        [Authorize(Roles = "professor")]
        [HttpPut("{login}")]
        public ActionResult<Boletim> AtualizarBoletim([FromBody] UsuarioDTO usuarioDTO, [FromRoute] string login)
        {
            Usuario usuario = new Usuario(usuarioDTO);
            usuario.Login = login;
            return Ok(new UsuarioGetDTO(_services.Atualizar(usuario)));
        }

        [Authorize(Roles = "professor")]
        [HttpDelete("{login}")]
        public ActionResult Deletar([FromRoute] string login)
        {
                _services.Deletar(login);
                return Ok("O registro foi deletado !");
        }
    }
}
