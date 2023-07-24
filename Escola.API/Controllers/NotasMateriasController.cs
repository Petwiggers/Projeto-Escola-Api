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
    public class NotasMateriasController : ControllerBase
    {
        public INotasMateriasService _services;
        public NotasMateriasController(INotasMateriasService service)
        {
            _services = service;
        }
        
        [HttpPost]
        public ActionResult<NotasMateriasDTO> Cadastrar([FromBody] NotasMateriasDTO notasMateriasDTO)
        {
            try
            {
                NotasMateria notaMateria = new (notasMateriasDTO);
                var resultado = _services.Criar(notaMateria);
                return Ok(new NotasMateriasDTO(resultado));
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
        [HttpGet("aluno/{idAluno}/boletim/{idBoletim}")]
        public ActionResult<List<NotasMateriasDTO>> ObterPorBoletim([FromRoute] int idAluno, int idBoletim)
        {
            try
            {
                IQueryable<NotasMateria> notaMateria = _services.ObterPorBoletim(idAluno , idBoletim);
                return Ok(notaMateria.Select(x=> new NotasMateriasDTO (x)));
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

        [HttpGet("{id}")]
        public ActionResult<NotasMateriasDTO> ObterNotasMateriasId([FromRoute] int id)
        {
            try
            {
                NotasMateria notasMateria= _services.ObterPorId(id);
                return Ok(new NotasMateriasDTO (notasMateria));
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
        public ActionResult<List<NotasMateriasDTO>> ObterNotasMaterias()
        {
            try
            {
                List<NotasMateria> notasMaterias = _services.ObterTodos();
                List<NotasMateriasDTO> notasMateriasDTOs = notasMaterias.Select(x => new NotasMateriasDTO(x)).ToList();
                return Ok(notasMateriasDTOs);
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

        [HttpPut("{id}")]
        public ActionResult<NotasMateriasDTO> AtualizarNotaMateria([FromBody] NotasMateriasDTO notasMateriasDTO, [FromRoute] int id)
        {
            try
            {
                NotasMateria notasMateria = new(notasMateriasDTO);
                notasMateria.Id = id;
                return Ok(new NotasMateriasDTO(_services.Atualizar(notasMateria)));
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
