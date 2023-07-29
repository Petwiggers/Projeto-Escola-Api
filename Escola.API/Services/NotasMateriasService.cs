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
    public class NotasMateriasService : INotasMateriasService
    {
        public INotasMateriasRepository _repository;
      
        public NotasMateriasService(INotasMateriasRepository repository)
        {
            _repository = repository;
        }
        public NotasMateria Atualizar(NotasMateria notasMateria)
        {
            NotasMateria notaMateriaDB = _repository.ObterPorId(notasMateria.Id);
            if (notaMateriaDB == null)
            {
                throw new NotFoundException("NotasMaterias não existe !");
            }

            if (!(_repository.ValidarMateria(notasMateria.MateriaId) || _repository.ValidarBoletim(notasMateria.BoletimId)))
            {
                throw new NotFoundException("Dados inválidos !");
            }
            notaMateriaDB.Update(notasMateria);
            return _repository.Atualizar(notaMateriaDB);
        }

        public NotasMateria Criar(NotasMateria notasMateria)
        {
            if (notasMateria.Nota < 0)
                throw new ArgumentOutOfRangeException("Nota",notasMateria.Nota ,"Nota deve ser maior que 0");

            if (!(_repository.ValidarBoletim(notasMateria.BoletimId) || _repository.ValidarMateria(notasMateria.MateriaId)))
            {
                throw new NotFoundException("Dados inválidos !");
            }

            return _repository.Inserir(notasMateria);
        }

        public void DeletarBoletim(int id)
        {
            NotasMateria notasMateria = _repository.ObterPorId(id);
            if(notasMateria == null)
            {
                throw new NotFoundException("NotaMAtéria inexistente !");
            }
            _repository.Excluir(notasMateria);
        }

        public IQueryable<NotasMateria> ObterPorBoletim(int idAluno, int idBoletim)
        {
            var notasMateria = (_repository.ObterPorBoletim(idAluno, idBoletim));
            if (notasMateria == null)
            {
                throw new NotFoundException("NotaMAtéria inexistente !");
            }
            return notasMateria;
        }

        public NotasMateria ObterPorId(int id)
        {
            NotasMateria notasMateria = _repository.ObterPorId(id);
            if (notasMateria == null)
            {
                throw new NotFoundException("NotaMAtéria inexistente !");
            }
            return notasMateria;
        }

        public List<NotasMateria> ObterTodos()
        {
            List<NotasMateria> notasMateria = _repository.ObterTodos();
            if (notasMateria == null)
            {
                throw new NotFoundException("Não possui nenhum registro cadastrado!");
            }
            return notasMateria;
        }

       
    }
}
