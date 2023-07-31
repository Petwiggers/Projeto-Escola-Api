using Escola.API.Exceptions;
using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using Escola.API.Services;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.API.Test.Services
{
    public class MateriaService
    {
        [Test]
        public void Materia_InserirNova_Sucesso()
        {
            // ARRANGE
            var materiaRepositoryMock = new Mock<IMateriaRepository>();
            materiaRepositoryMock.Setup(x => x.Inserir(It.IsAny<Materia>()))
                .Returns<Materia>(x => x);
            var materiaService = new MateriaServices(materiaRepositoryMock.Object);
            var materia = new Materia(){NomeMateria = "POO"};
            var expectedMateria = new Materia() { NomeMateria = "POO" };

            // ACT
            var result = materiaService.Criar(materia);

            //ASSERT
            Assert.AreEqual(JsonConvert.SerializeObject(expectedMateria), JsonConvert.SerializeObject(materia));
        }

        [Test]
        public void Materia_InserirNomeDuplicado_Falha()
        {
            // ARRANGE
            var materiaRepositoryMock = new Mock<IMateriaRepository>();
            materiaRepositoryMock.Setup(x => x.ObterPorNome(It.IsAny<string>()))
                .Returns<string>(x =>
                {
                    return new Materia() { NomeMateria = x };
                });
            var materiaService = new MateriaServices(materiaRepositoryMock.Object);
            var materia = new Materia() { NomeMateria = "POO" };
            var expectedMessage = "Nome já existente !";

            // ACT
            var ex = Assert.Throws<RegistroDuplicadoException>(() =>
            {
                materiaService.Criar(materia);
            });

            //ASSERT
            Assert.AreEqual(expectedMessage, ex.Message);
        }
    }
}
