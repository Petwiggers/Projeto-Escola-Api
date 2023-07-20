using Escola.API.DTO;
using Escola.API.Exceptions;
using Escola.API.Interfaces.Repositories;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Services
{
    public class MateriaServices : IMateriaService
    {
        private readonly IMateriaRepository _repository;

        public MateriaServices(IMateriaRepository repository)
        {
            _repository = repository;
        }

        public Materia Atualizar(Materia materia)
        {
            Materia materiaDb = _repository.ObterPorId(materia.Id);
            if(materiaDb == null)
            {
                throw new NotFoundException("Matéria não existe !");
            }
            materiaDb.Update(materia);
            return _repository.Atualizar(materiaDb);
            
        }

        public Materia Criar(Materia materia)
        {
            Materia materiaExiste = _repository.ObterPorNome(materia.NomeMateria);
            if(materiaExiste != null)
            {
                throw new RegistroDuplicadoException("Nome já existente !"); 
            }
            _repository.Inserir(materia);
            return materia;
        }

        public void DeletarMateria(int id  )
        {
            Materia materia = _repository.ObterPorId(id);
            if(materia == null)
            {
                throw new NotFoundException("Não possui um registro com este Id !");
            }
            _repository.Excluir(materia);
        }

        public List<Materia> ObterMaterias()
        {
            List<Materia> materias = _repository.ObterTodos();
            if(materias == null)
            {
                throw new NotFoundException("Não há matérias cadastradas no banco de Dados");
            }
            return materias; 
        }

        public Materia ObterPorNome(String nome)
        {
            Materia materia = _repository.ObterPorNome(nome);
            if(materia == null)
            {
                throw new NotFoundException("Não foi possivel encontrar uma matéria com o nome :" + nome);
            }
            return materia;
        }

        public Materia ObterPorId(int id)
        {
            Materia materia = _repository.ObterPorId(id);
            if (materia == null)
            {
                throw new NotFoundException("Não foi possivel encontrar uma matéria com o id :" + id);
            }
            return materia;
        }

    }
}
