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
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        public readonly IUsuarioService _services;

        public UsuarioController(IUsuarioService service)
        {
            _services = service;
        }

        [HttpPost]
        public ActionResult<UsuarioDTO> Cadastrar([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                Usuario usuario = new Usuario(usuarioDTO);
                var resultado = _services.Criar(usuario);
                return Created(Request.PathBase, new UsuarioGetDTO(resultado));
            }
            catch (RegistroDuplicadoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{login}")]
        public ActionResult<UsuarioGetDTO> ObterBoletimIdAluno([FromRoute] string login)
        {
            try
            {
                Usuario usuario = _services.ObterPorId(login);
                return Ok(new UsuarioGetDTO(usuario));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        public ActionResult<List<UsuarioGetDTO>> ObterBoletins()
        {
            try
            {
                List<Usuario> usuario = _services.ObterTodos();
                List<UsuarioGetDTO> usuariosDTOs = usuario.Select(x => new UsuarioGetDTO(x)).ToList();
                return Ok(usuariosDTOs);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{login}")]
        public ActionResult<Boletim> AtualizarBoletim([FromBody] UsuarioDTO usuarioDTO, [FromRoute] string login)
        {
            try
            {
                Usuario usuario = new Usuario(usuarioDTO);
                usuario.Login = login;
                return Ok(new UsuarioGetDTO(_services.Atualizar(usuario)));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{login}")]
        public ActionResult Deletar([FromRoute] string login)
        {
            try
            {
                _services.Deletar(login);
                return Ok("O registro foi deletado !");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
