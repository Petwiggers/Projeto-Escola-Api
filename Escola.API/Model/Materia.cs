using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Model
{
    public class Materia
    {
        public int Id { get; set; }
        public string NomeMateria { get; set; }
        public virtual List<NotasMateria> NotasMaterias { get; set; }
    }
}
