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
    public class NotasMateriasServiceTests
    {
        [Test]
        public void Cadastrar_NotaMenorQueZero_retunrError()
        {
            // ARRANGE
            var notasMateriasRepositoryMock = new Mock<INotasMateriasRepository>();
            notasMateriasRepositoryMock.Setup(x => x.Inserir(It.IsAny<NotasMateria>()))
                .Returns<NotasMateria>(x =>
                {
                    x.Id = 10;
                    return x;
                });
            var notasMateriasService = new NotasMateriasService(notasMateriasRepositoryMock.Object);
            var notasMaeterias = new NotasMateria() { Nota = -1 };
            var mensagemEsperada = "Nota deve ser menor ou igual a 10 e maior ou igual a 0";
            var parametroEsperado = "Nota";
            var valorAtualEsperado = -1;

            // ACT

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                notasMateriasService.Criar(notasMaeterias);
            });
            // ASSERT 

            Assert.AreEqual(parametroEsperado, ex.ParamName);
            Assert.IsTrue(ex.Message.Contains(mensagemEsperada));
            Assert.AreEqual(valorAtualEsperado, ex.ActualValue);
        }

        [Test]
        public void Cadastrar_NotaMaiorQueDez_retunrError()
        {
            // ARRANGE
            var notasMateriasRepositoryMock = new Mock<INotasMateriasRepository>();
            notasMateriasRepositoryMock.Setup(x => x.Inserir(It.IsAny<NotasMateria>()))
                .Returns<NotasMateria>(x =>
                {
                    x.Id = 10;
                    return x;
                });
            var notasMateriasService = new NotasMateriasService(notasMateriasRepositoryMock.Object);
            var notasMaeterias = new NotasMateria() { Nota = 12 };
            var mensagemEsperada = "Nota deve ser menor ou igual a 10 e maior ou igual a 0";
            var parametroEsperado = "Nota";
            var valorAtualEsperado = 12;

            // ACT

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                notasMateriasService.Criar(notasMaeterias);
            });
            // ASSERT 

            Assert.AreEqual(parametroEsperado, ex.ParamName);
            Assert.IsTrue(ex.Message.Contains(mensagemEsperada));
            Assert.AreEqual(valorAtualEsperado, ex.ActualValue);
        }
        [Test]
        public void Cadastrar_NotasEntreZero_Dez_retunrOk()
        {
            // ARRANGE
            var notasMateriasRepositoryMock = new Mock<INotasMateriasRepository>();
            notasMateriasRepositoryMock.Setup(x => x.Inserir(It.IsAny<NotasMateria>()))
                .Returns<NotasMateria>(x =>
                {
                    x.Id = 10;
                    return x;
                });
            notasMateriasRepositoryMock.Setup(x => x.ValidarBoletim(It.IsAny<int>())).Returns(true);
            notasMateriasRepositoryMock.Setup(x => x.ValidarMateria(It.IsAny<int>())).Returns(true);

            var notasMateriasService = new NotasMateriasService(notasMateriasRepositoryMock.Object);

            var notasMaterias = new NotasMateria() { Nota = 10 };
            var notasMateriaEsperado = new NotasMateria() { 
                Nota = 10 ,
                Id = 10,
                BoletimId = 0,
                MateriaId = 0
        };
            
            // ACT

            var result = notasMateriasService.Criar(notasMaterias);

            // ASSERT 

            Assert.AreEqual(JsonConvert.SerializeObject(notasMateriaEsperado),
                            JsonConvert.SerializeObject(result));
        }
    }
}
