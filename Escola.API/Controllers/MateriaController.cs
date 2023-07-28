using Escola.API.DataBase.Repositories;
using Escola.API.DTO;
using Escola.API.Exceptions;
using Escola.API.Interfaces.Repositories;
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
    public class MateriaController : ControllerBase
    {
        public virtual IMateriaService _services { get; set; }

        public MateriaController(IMateriaService service)
        {
            _services = service;
        }

        [Authorize(Roles = "professor, alunos")]
        [HttpGet]
        public ActionResult<List<MateriaDTO>> ObterMateria([FromQuery] string nome)
        {
            if (nome != null)
            {
                Materia materia = _services.ObterPorNome(nome);
                return Ok(new MateriaDTO(materia));
            }
            List<Materia> materias = _services.ObterMaterias();
            List<MateriaDTO> materiasDTO = materias.Select(x => new MateriaDTO(x)).ToList();
            return Ok(materiasDTO); 
        }

        [Authorize(Roles = "professor, alunos")]
        [HttpGet("{id}")]
        public ActionResult<Materia> ObterPorId([FromRoute] int id)
        {
            Materia materia = _services.ObterPorId(id);
            return Ok(new MateriaDTO(materia));
        }

        [Authorize(Roles = "professor")]
        [HttpDelete("{id}")]
        public ActionResult<Materia>Deletar([FromRoute] int id)
        {
            _services.DeletarMateria(id);
            return Ok("O registro foi deletado !");
        }

        [Authorize(Roles = "professor")]
        [HttpPost]
        public ActionResult<MateriaDTO> Cadastrar ([FromBody]MateriaDTO materiaDTO)
        {
            Materia materia = new Materia(materiaDTO);
            var resultado = _services.Criar(materia);
            return Ok(new MateriaDTO(resultado));
        }

        [Authorize(Roles = "professor")]
        [HttpPut("{id}")]
        public ActionResult<Materia> AtualizarMateria([FromBody] MateriaDTO materiaDTO, [FromRoute] int id)
        {
            Materia materia = new Materia(materiaDTO);
            materia.Id = id;
            var resultado = _services.Atualizar(materia);
            return Ok(new MateriaDTO(resultado));
        }
      
    }
}
