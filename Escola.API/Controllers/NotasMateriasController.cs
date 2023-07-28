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
    public class NotasMateriasController : ControllerBase
    {
        public INotasMateriasService _services;
        public NotasMateriasController(INotasMateriasService service)
        {
            _services = service;
        }

        [Authorize(Roles = "professor")]
        [HttpPost]
        public ActionResult<NotasMateriasDTO> Cadastrar([FromBody] NotasMateriasDTO notasMateriasDTO)
        {
            NotasMateria notaMateria = new (notasMateriasDTO);
            var resultado = _services.Criar(notaMateria);
            return Ok(new NotasMateriasDTO(resultado));
        }

        [Authorize(Roles = "professor, alunos")]
        [HttpGet("aluno/{idAluno}/boletim/{idBoletim}")]
        public ActionResult<List<NotasMateriasDTO>> ObterPorBoletim([FromRoute] int idAluno, int idBoletim)
        {
            IQueryable<NotasMateria> notaMateria = _services.ObterPorBoletim(idAluno , idBoletim);
            return Ok(notaMateria.Select(x=> new NotasMateriasDTO (x)));
        }

        [Authorize(Roles = "professor, alunos")]
        [HttpGet("{id}")]
        public ActionResult<NotasMateriasDTO> ObterNotasMateriasId([FromRoute] int id)
        {
            NotasMateria notasMateria= _services.ObterPorId(id);
            return Ok(new NotasMateriasDTO (notasMateria));
        }

        [Authorize(Roles = "professor, alunos")]
        [HttpGet]
        public ActionResult<List<NotasMateriasDTO>> ObterNotasMaterias()
        {
            List<NotasMateria> notasMaterias = _services.ObterTodos();
            List<NotasMateriasDTO> notasMateriasDTOs = notasMaterias.Select(x => new NotasMateriasDTO(x)).ToList();
            return Ok(notasMateriasDTOs);
        }

        [Authorize(Roles = "professor")]
        [HttpPut("{id}")]
        public ActionResult<NotasMateriasDTO> AtualizarNotaMateria([FromBody] NotasMateriasDTO notasMateriasDTO, [FromRoute] int id)
        {
            NotasMateria notasMateria = new(notasMateriasDTO);
            notasMateria.Id = id;
            return Ok(new NotasMateriasDTO(_services.Atualizar(notasMateria)));
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
