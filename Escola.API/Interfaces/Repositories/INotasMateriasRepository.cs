using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Interfaces.Repositories
{
    public interface INotasMateriasRepository : IBaseRepository<NotasMateria, int>
    {
        bool ValidarMateria(int alunoId);
        bool ValidarBoletim(int boletimId);
        IQueryable<NotasMateria> ObterPorBoletim(int idAluno, int idBoletim);
    }
}
