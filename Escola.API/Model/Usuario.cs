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
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }
}
