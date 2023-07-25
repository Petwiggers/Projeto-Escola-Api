using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, string>
    {
        public bool ValidarSeLoginExiste(Usuario usuario);

        
    }
}
