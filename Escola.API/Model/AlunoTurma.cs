using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Model
{
    public class AlunoTurma
    {
        public virtual Aluno Aluno { get; set; }
        public virtual Turma Turma{ get; set; }
        public int AlunoID{ get; set; }
        public int TurmaId{ get; set; }
    }
}
