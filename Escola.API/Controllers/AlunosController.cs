﻿using Escola.API.DTO;
using Escola.API.Exceptions;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        private readonly IMemoryCache _memoryCache;

        public AlunosController( IAlunoService alunoService, IMemoryCache memoryCache)
        {
            _alunoService = alunoService;
            _memoryCache = memoryCache;
        }

        [Authorize(Roles = "professor")]
        [HttpPost]
        public IActionResult Post([FromBody] AlunoDTO alunoDTO)
        {   
            var aluno = new Aluno(alunoDTO);
            //Chamada da service
            aluno = _alunoService.Criar(aluno);

            return Ok(new AlunoDTO(aluno));
        }
        [Authorize(Roles = "professor, alunos")]
        [HttpGet]
        public ActionResult<AlunoDTO> Get() 
        {
            var alunos = _alunoService.ObterAlunos();
            IEnumerable<AlunoDTO> alunosDtos = alunos.Select(x => new AlunoDTO(x));       
            return Ok(alunosDtos);
        }

        [Authorize(Roles = "professor, alunos")]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetComId([FromRoute] int id)
        {
            AlunoDTO aluno;
            if(!_memoryCache.TryGetValue<AlunoDTO>($"aluno:{id}", out  aluno)){
                    aluno = new AlunoDTO(_alunoService.ObterPorId(id));
                _memoryCache.Set<AlunoDTO>($"aluno:{id}", aluno, new TimeSpan(0,0,20));
            }
            return Ok(aluno);   
        }

        [Authorize(Roles = "professor")]
        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizaAluno([FromBody] AlunoDTO alunoDTO, [FromRoute] int id)
        {
            var aluno = new Aluno(alunoDTO);
            aluno.Id = id;
            if (!ModelState.IsValid) return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");

            aluno = _alunoService.Atualizar(aluno);

            //var alunodto = new AlunoDTO(aluno);
            //_memoryCache.Set<AlunoDTO>($"aluno:{id}", alunodto, new TimeSpan(0, 0, 20));

            _memoryCache.Remove($"aluno:{id}");

            return Ok(new AlunoDTO(aluno));
        }

        [Authorize(Roles = "professor")]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _alunoService.DeletarAluno(id);
            _memoryCache.Remove($"aluno:{id}");
            return StatusCode(204);
        }
    }
}
