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
    public class BoletimService : IBoletimService
    {
        public IBoletimRepository _repository;
        public IAlunoRepository _alunoRepository;
        public BoletimService(IBoletimRepository repository, IAlunoRepository alunoRepository)
        {
            _repository = repository;
            _alunoRepository = alunoRepository;
        }
        Boletim IBoletimService.Atualizar(Boletim boletim)
        {
            throw new NotImplementedException();
        }

        Boletim IBoletimService.Criar(Boletim boletim)
        {
            Aluno alunoexist = _alunoRepository.ObterPorId(boletim.AlunoId);
            if(alunoexist == null)
            {
                throw new NotFoundException("Não existe um Aluno com este Id !");
            }
            _repository.Inserir(boletim);
            return boletim;
        }

        void IBoletimService.DeletarBoletim(int id)
        {
            throw new NotImplementedException();
        }

        List<Boletim> IBoletimService.ObterBoletim()
        {
            throw new NotImplementedException();
        }

        Boletim IBoletimService.ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
