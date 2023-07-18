using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.DataBase.Repositories
{
    public class MateriaRepository : BaseRepository<Materia, int>, IMateriaRepository
    {
        public EscolaDbContexto _contexto;
        public MateriaRepository(EscolaDbContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public Materia ObterPorNome(string nome)
        {
            return _contexto.Materia.FirstOrDefault(x => x.NomeMateria == nome);
        }

    }
}
