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
        public BoletimRepository(EscolaDbContexto contexto) : base(contexto)
        {
        }
    }
}
