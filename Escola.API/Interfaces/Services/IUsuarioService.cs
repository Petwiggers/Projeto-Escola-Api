using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Interfaces.Services
{
    public interface IUsuarioService
    {
        public Usuario Criar(Usuario notasMateria);
        public Usuario ObterPorId(string  login);
        public Usuario Atualizar(Usuario notasMateria);
        public void Deletar(string login);
        public List<Usuario> ObterTodos();
    }
}
