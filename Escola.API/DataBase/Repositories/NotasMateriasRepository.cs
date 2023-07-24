using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.DataBase.Repositories
{
    public class NotasMateriasRepository : BaseRepository<NotasMateria, int>, INotasMateriasRepository
    {
        public EscolaDbContexto _contexto;
        public NotasMateriasRepository(EscolaDbContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public IQueryable<NotasMateria> ObterPorBoletim(int idAluno, int idBoletim)
        {
            var query = (from NotasMateria in _contexto.Set<NotasMateria>()
                        join Boletim in _contexto.Set<Boletim>()
                        on NotasMateria.BoletimId equals Boletim.Id
                        where NotasMateria.BoletimId == idBoletim 
                         where Boletim.Id == idAluno
                        select NotasMateria);

            return query;
        }

        public bool ValidarMateria(int materiaId)
        {
            return _contexto.Materia.Any(x => x.Id == materiaId);
        }

        public bool ValidarBoletim(int boletimId)
        {
            return _contexto.Boletims.Any(x => x.Id == boletimId);
        }
    }
}
