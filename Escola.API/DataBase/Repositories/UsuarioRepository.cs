using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.DataBase.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario,string>, IUsuarioRepository
    {
        public EscolaDbContexto _contexto{ get; set; }
        public UsuarioRepository(EscolaDbContexto contexto) : base(contexto)
        {

        }

        public override Usuario ObterPorId(string login)
        {
            return _context.Usuarios.Find(login);
        }

        public bool ValidarSeLoginExiste(Usuario usuario)
        {
            return _context.Usuarios.Any(x => x.Login == usuario.Login);
        }
    }
}
