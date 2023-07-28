using Escola.API.DTO;
using Escola.API.Exceptions;
using Escola.API.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public ILoginService _services;

        public LoginController(ILoginService service)
        {
            _services = service;
        }

        [HttpPost]
        public ActionResult Logar([FromBody]LoginDTO login)
        {
            if (!_services.Autenticar(login))
                return Unauthorized("Login ou Senha inválidos !");

            return Ok(_services.GerarToken(login));
        }
    }
}
