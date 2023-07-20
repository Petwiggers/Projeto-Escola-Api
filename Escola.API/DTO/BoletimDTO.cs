using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.DTO
{
    public class BoletimDTO
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public string Data_Pedido { get; set; }

        public BoletimDTO()
        {
             
        }
        public BoletimDTO(Boletim boletim)
        {
            Id = boletim.Id;
            AlunoId = boletim.AlunoId;
            Data_Pedido = boletim.Data_Pedido.ToString("dd/MM/yyyy");
        }
    }
}
