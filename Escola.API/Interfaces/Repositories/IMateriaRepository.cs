using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Interfaces.Repositories
{
    public interface IMateriaRepository : IBaseRepository<Materia, int>
    {
        public Materia ObterPorNome(string nome);
    }
}
