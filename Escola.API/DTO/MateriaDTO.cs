using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.DTO
{
    public class MateriaDTO
    {
        public int Id { get; set; }
        public string NomeMateria { get; set; }

        public MateriaDTO()
        {

        }

        public MateriaDTO(Materia materia)
        {
            Id = materia.Id;
            NomeMateria = materia.NomeMateria;
        }
    }
}
