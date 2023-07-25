using Escola.API.Exceptions;
using Escola.API.Interfaces.Repositories;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using Escola.API.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        public IUsuarioRepository _repositorio;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repositorio = repository;
        }
        public Usuario Atualizar(Usuario usuario)
        {
            Usuario usuarioDb = _repositorio.ObterPorId(usuario.Login);
            if(usuarioDb == null)
            {
                throw new NotFoundException("Usuario não encontrado !");
            }
            usuarioDb.Update(usuario);

            if (!string.IsNullOrEmpty(usuario.Senha))
                usuarioDb.Senha = Cripitografia.CriptografarSenha(usuario.Senha);

            return _repositorio.Atualizar(usuarioDb);
        }

        public Usuario Criar(Usuario usuario)
        {
            if (_repositorio.ValidarSeLoginExiste(usuario))
            {
                throw new BadRequestException("Login Já Existente !");
            }
            usuario.Senha = Cripitografia.CriptografarSenha(usuario.Senha);
            return _repositorio.Inserir(usuario);
        }

        public void Deletar(string login)
        {
            Usuario usuario = _repositorio.ObterPorId(login);
            if (usuario == null)
            {
                throw new NotFoundException("Usuario não existe !");
            }
            _repositorio.Excluir(usuario);
        }

        public Usuario ObterPorId(string login)
        {
            Usuario usuario = _repositorio.ObterPorId(login);
            if (usuario == null)
            {
                throw new NotFoundException("Usuário não encontrado !");
            }
            return usuario;
        }

        public List<Usuario> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }
    }
}
