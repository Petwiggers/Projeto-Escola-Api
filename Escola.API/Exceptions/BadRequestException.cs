using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string mensagem): base(mensagem)
        {

        }
    }
}
