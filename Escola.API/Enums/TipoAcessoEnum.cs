using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Escola.API.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TipoAcessoEnum
    {
        alunos,
        professor
    }
}
