using Escola.API.Enums;
using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.DTO
{
    public class UsuarioGetDTO
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public TipoAcessoEnum Permissao { get; set; }

        public UsuarioGetDTO()
        {

        }

        public UsuarioGetDTO(Usuario usuario)
        {
            Nome = usuario.NomeCompleto;
            Login = usuario.Login;
            Permissao = usuario.TipoAcesso;
        }
    }
}
