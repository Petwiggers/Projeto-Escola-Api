using Escola.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Model
{
    public class Boletim
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }
        public DateTime Data_Pedido { get; set; }
        public List<NotasMateria> NotasMaterias { get; set; }

        public Boletim()
        {

        }

        public Boletim(BoletimDTO boletimDTO)
        {
            Id = boletimDTO.Id;
            AlunoId = boletimDTO.AlunoId;
            if (DateTime.TryParse(boletimDTO.Data_Pedido, out var date))
            {
                Data_Pedido = date;
            }
            else
            {
                throw new ArgumentException("Erro ao converter a data !");
            }
        }
    }
}
