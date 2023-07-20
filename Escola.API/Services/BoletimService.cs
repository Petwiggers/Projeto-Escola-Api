﻿using Escola.API.Exceptions;
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
        public Boletim Atualizar(Boletim boletim)
        {
            throw new NotImplementedException();
        }

        public Boletim Criar(Boletim boletim)
        {
            Aluno alunoexist = _alunoRepository.ObterPorId(boletim.AlunoId);
            if(alunoexist == null)
            {
                throw new NotFoundException("Não existe um Aluno com este Id !");
            }
            _repository.Inserir(boletim);
            return boletim;
        }

        public void DeletarBoletim(int id)
        {
            throw new NotImplementedException();
        }

        public List<Boletim> ObterBoletimIdAluno(int id)
        {
            List<Boletim> boletims= _repository.ObterBoletinsIdAluno(id);
            if (boletims == null)
            {
                throw new NotFoundException("Não há boletins cadastradas para este Aluno !");
            }
            return boletims;
        }
        public Boletim ObterPorId(int id)
        {
            Boletim boletim = _repository.ObterPorId(id);
            if (boletim == null)
            {
                throw new NotFoundException("Não foi possivel encontrar um Boletim com o id :" + id);
            }
            return boletim;
        }
      

    }
}
