using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.DTO
{
    public class NotasMateriasDTO
    {
        public int Id { get; set; }
        public int BoletimId { get; set; }
        public int MateriaId { get; set; }
        public int Nota { get; set; }

        public NotasMateriasDTO()
        {

        }

        public NotasMateriasDTO(NotasMateria notasMateria)
        {
            Id = notasMateria.Id;
            BoletimId = notasMateria.BoletimId;
            MateriaId = notasMateria.MateriaId;
            Nota = notasMateria.Nota;
        }
    }
}
