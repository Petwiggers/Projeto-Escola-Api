using Escola.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Interfaces.Services
{
    public interface ILoginService
    {
        public bool Autenticar(LoginDTO login);
        public string GerarToken (LoginDTO login);
    }
}
