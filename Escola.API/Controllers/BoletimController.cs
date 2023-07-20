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
    [Route("api/[controller]")]
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
        public ActionResult<List<Boletim>> ObterBoletimIdAluno([FromRoute] int id)
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
    }
}
