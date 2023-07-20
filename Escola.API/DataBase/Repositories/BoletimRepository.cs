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
    public class BoletimRepository : BaseRepository<Boletim,int>,IBoletimRepository
    {
        public EscolaDbContexto _contexto;
        public BoletimRepository(EscolaDbContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
        public List<Boletim> ObterBoletinsIdAluno(int id)
        {
            return _context.Set<Boletim>().Where(x => x.AlunoId == id).ToList();
        }
    }
}
