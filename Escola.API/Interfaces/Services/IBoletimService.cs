using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Interfaces.Services
{
    public interface IBoletimService 
    {
        public Boletim ObterPorId(int id);
        public List<Boletim> ObterAluno();
    }
}
