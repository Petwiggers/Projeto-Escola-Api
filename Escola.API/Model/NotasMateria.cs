using Escola.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Model
{
    public class NotasMateria
    {
        public int Id { get; set; }
        public int BoletimId { get; set; }
        public Boletim Boletim { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
        public int Nota { get; set; }

        public NotasMateria()
        {

        }

        public NotasMateria(NotasMateriasDTO notasMateriasDTO)
        {
            BoletimId = notasMateriasDTO.BoletimId;
            MateriaId = notasMateriasDTO.MateriaId;
            Nota = notasMateriasDTO.Nota;
        }

        public void Update(NotasMateria notasMateria)
        {
            BoletimId = notasMateria.BoletimId;
            MateriaId = notasMateria.MateriaId;
            Nota = notasMateria.Nota;
        }
    }
}
