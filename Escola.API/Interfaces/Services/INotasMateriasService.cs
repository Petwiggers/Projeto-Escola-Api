using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Interfaces.Services
{
    public interface INotasMateriasService
    {
        public NotasMateria Criar(NotasMateria notasMateria);
        public NotasMateria ObterPorId(int id);
        public NotasMateria Atualizar(NotasMateria notasMateria);
        public void DeletarBoletim(int id);
        public IQueryable<NotasMateria> ObterPorBoletim(int idAluno, int idBoletim);
        public List<NotasMateria> ObterTodos();
    }
}
