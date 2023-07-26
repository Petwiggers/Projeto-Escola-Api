using Escola.API.DTO;
using Escola.API.Exceptions;
using Escola.API.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public ILoginService _services;

        public LoginController(ILoginService service)
        {
            _services = service;
        }

        [HttpPost]
        public ActionResult Logar(LoginDTO login)
        {
            try
            {
                if (!_services.Autenticar(login))
                    return Unauthorized("Login ou Senha inválidos !");

                return Ok(_services.GerarToken(login));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        
        }
    }
}
