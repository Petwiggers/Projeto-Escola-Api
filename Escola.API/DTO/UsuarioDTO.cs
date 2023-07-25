using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.DTO
{
    public class UsuarioDTO : UsuarioGetDTO
    {
        public string Senha { get; set; }

        public UsuarioDTO()
        {

        }

        public UsuarioDTO(Usuario usuario) : base(usuario)
        {
            Senha = usuario.Senha;
        }
    }
}
