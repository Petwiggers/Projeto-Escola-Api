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
    public class BoletimController : ControllerBase
    {
        public IBoletimService _services;
        public BoletimController(IBoletimService service)
        {
            _services = service;
        }

        [Authorize(Roles = "professor")]
        [HttpPost]
        public ActionResult<BoletimDTO> Cadastrar([FromBody] BoletimDTO boletimDTO)
        {
            Boletim boletim = new Boletim(boletimDTO);
            var resultado = _services.Criar(boletim);
            return Ok(new BoletimDTO(resultado));  
        }

        [Authorize(Roles = "professor, alunos")]
        [HttpGet("{id}")]
        public ActionResult<List<BoletimDTO>> ObterBoletimIdAluno([FromRoute] int id)
        {
                Boletim boletin = _services.ObterPorId(id);
                return Ok(new BoletimDTO(boletin));
        }
        [Authorize(Roles = "professor, alunos")]
        [HttpGet("aluno/{id}")]
        public ActionResult<List<Boletim>> ObterBoletimId([FromRoute] int id)
        {
            List<Boletim> boletin = _services.ObterBoletimIdAluno(id);
            return Ok(boletin.Select(x => new BoletimDTO(x)).ToList());
        }

        [Authorize(Roles = "professor, alunos")]
        [HttpGet]
        public ActionResult<List<MateriaDTO>> ObterBoletins()
        {
            List<Boletim> boletins = _services.ObterTodos();
            List<BoletimDTO> materiaDTOs = boletins.Select(x => new BoletimDTO(x)).ToList();
            return Ok(materiaDTOs);
        }

        [Authorize(Roles = "professor")]
        [HttpPut ("{id}")]
        public ActionResult<Boletim> AtualizarBoletim([FromBody] BoletimDTO boletimDTO, [FromRoute]int id)
        {
            Boletim boletim = new Boletim(boletimDTO);
            boletim.Id = id;
            return Ok(new BoletimDTO(_services.Atualizar(boletim)));
        }

        [Authorize(Roles = "professor")]
        [HttpDelete("{id}")]
        public ActionResult Deletar([FromRoute] int id)
        {
            _services.DeletarBoletim(id);
            return Ok("O registro foi deletado !");
        }
    }
}
