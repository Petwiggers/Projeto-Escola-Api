using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Interfaces.Services
{
    public interface IMateriaService
    {
        public Materia Criar(Materia materia);
        public Materia ObterPorNome(string id);
        public Materia Atualizar(Materia materia);
        public List<Materia> ObterMaterias();
        public Materia ObterPorId(int id);
        public void DeletarMateria(int id);
    }
}
