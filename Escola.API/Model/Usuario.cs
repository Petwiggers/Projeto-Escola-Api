using Escola.API.DTO;
using Escola.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Model
{
    public class Usuario
    {
        public string NomeCompleto { get; set; }
        public TipoAcessoEnum TipoAcesso { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {

        }

        public Usuario(UsuarioGetDTO usuario)
        {
            NomeCompleto = usuario.Nome;
            TipoAcesso = usuario.Permissao;
            Login = usuario.Login;
        }

        public Usuario(UsuarioDTO usuario): this((UsuarioGetDTO)usuario)
        {
            Senha = usuario.Senha;
        }

        public void Update(Usuario usuario)
        {
            NomeCompleto = usuario.NomeCompleto;
            TipoAcesso = usuario.TipoAcesso;
        }
    }
}
