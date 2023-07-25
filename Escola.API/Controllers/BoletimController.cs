using Escola.API.DTO;
using Escola.API.Exceptions;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
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
    public class BoletimController : ControllerBase
    {
        public IBoletimService _services;
        public BoletimController(IBoletimService service)
        {
            _services = service;
        }

        [HttpPost]
        public ActionResult<BoletimDTO> Cadastrar([FromBody] BoletimDTO boletimDTO)
        {
            try
            {
                Boletim boletim = new Boletim(boletimDTO);
                var resultado = _services.Criar(boletim);
                return Ok(new BoletimDTO(resultado));
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
        [HttpGet("{id}")]
        public ActionResult<List<BoletimDTO>> ObterBoletimIdAluno([FromRoute] int id)
        {
            try
            {
                Boletim boletin = _services.ObterPorId(id);
                return Ok(new BoletimDTO(boletin));
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

        [HttpGet("aluno/{id}")]
        public ActionResult<List<Boletim>> ObterBoletimId([FromRoute] int id)
        {
            try
            {
                List<Boletim> boletin = _services.ObterBoletimIdAluno(id);
                return Ok(boletin.Select(x => new BoletimDTO(x)).ToList());
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
        public ActionResult<List<MateriaDTO>> ObterBoletins()
        {
            try
            {
                List<Boletim> boletins = _services.ObterTodos();
                List<BoletimDTO> materiaDTOs = boletins.Select(x => new BoletimDTO(x)).ToList();
                return Ok(materiaDTOs);
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

        [HttpPut ("{id}")]
        public ActionResult<Boletim> AtualizarBoletim([FromBody] BoletimDTO boletimDTO, [FromRoute]int id)
        {
            try
            {
                Boletim boletim = new Boletim(boletimDTO);
                boletim.Id = id;
                return Ok(new BoletimDTO(_services.Atualizar(boletim)));
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

        [HttpDelete("{id}")]
        public ActionResult Deletar([FromRoute] int id)
        {
            try
            {
                _services.DeletarBoletim(id);
                return Ok("O registro foi deletado !");
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
    }
}
