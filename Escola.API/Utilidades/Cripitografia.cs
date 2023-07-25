using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Escola.API.Utilidades
{
    public static class Cripitografia
    {
        public static HashAlgorithm _algoritmo = SHA256.Create();

        public static string CriptografarSenha(string senha)
        {
            var encodedValue = System.Text.Encoding.UTF8.GetBytes(senha);
            var encryptePassword = _algoritmo.ComputeHash(encodedValue);
            return Convert.ToBase64String(encryptePassword);
        }
    }
}