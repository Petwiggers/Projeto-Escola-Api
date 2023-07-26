using Escola.API.DTO;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using Escola.API.Utilidades;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Escola.API.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly string _chaveJwt;

        public LoginService(IUsuarioService usuarioService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _chaveJwt = configuration.GetSection("jwtTokenChave").Get<string>();
        }

        public string Criptografia { get; private set; }

        public bool Autenticar (LoginDTO login)
        {
            Usuario usuario = _usuarioService.ObterPorId(login.Usuario);
            if(usuario != null)
            {
                return usuario.Senha == Cripitografia.CriptografarSenha(login.Senha);
            }
            return false;
        }

        public string GerarToken (LoginDTO login)
        {
            Usuario usuario = _usuarioService.ObterPorId(login.Usuario);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_chaveJwt);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                  {
                      new Claim(ClaimTypes.Name, usuario.Login),
                      new Claim("Nome", usuario.NomeCompleto),
                      new Claim(ClaimTypes.Role, usuario.TipoAcesso.ToString()),
                  }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
