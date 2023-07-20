using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Interfaces.Services
{
    public interface IBoletimService 
    {
        public Boletim Criar(Boletim boletim);
        public Boletim ObterPorId(int id);
        public Boletim Atualizar(Boletim boletim);
        public void DeletarBoletim(int id);
        public List<Boletim> ObterBoletimIdAluno(int id);
    }
}
