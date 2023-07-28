using Escola.API.Exceptions;
using Microsoft.AspNetCore.Http;
using System;

using System.Threading.Tasks;

namespace Escola.API.Middleware
{
    public class ErrorsMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex )
            {
                await TratamentoExcecao(context, ex);
            }
        }

        public async Task TratamentoExcecao (HttpContext context, Exception ex)
        {
            int status;
            string mensagem = ex.Message;

            switch (ex)
            {
                case (NotFoundException):
                    {
                            status = StatusCodes.Status404NotFound;
                        break;
                    }
                case (BadRequestException):
                    {
                        status = StatusCodes.Status400BadRequest;
                        break;
                    }
                case (RegistroDuplicadoException):
                    {
                        status = StatusCodes.Status400BadRequest;
                        break;
                    }
                case (ArgumentException):
                    {
                        status = StatusCodes.Status406NotAcceptable;
                        break;
                    }

                default:
                    {
                        status = StatusCodes.Status500InternalServerError;
                        mensagem = "Ocorreu um erro tente novamente mais tarde !";
                        break;
                    }

                    
            }
            context.Response.StatusCode = status;
            await context.Response.WriteAsync(mensagem);
        }
    }
}

