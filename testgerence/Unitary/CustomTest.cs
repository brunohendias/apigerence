using apigerence.Models;
using apigerence.Repository;
using Moq;
using Xunit;

namespace testgerence.Unitary
{
    public class CustomTest
    {
        //private readonly ICustom _mock;
        private readonly Mock<ICustom> _mockRepo;
        private readonly CustomRepository repo;

        public CustomTest()
        {
            // Arrange
            _mockRepo = new Mock<ICustom>();
            repo = new CustomRepository();
            //_mockRepo.Setup(repo => repo.Custom()).Returns(200);
        }

        private readonly static Aluno _register = new()
        {
            cod_can = 4,
            cod_situacao = 2,
            cod_serie_v = 1,
            cod_atencao = 1
        };

        [Fact]
        public void Check_if_success_gera_ra()
        {
            // Act
            var result = repo.GeraRA(_register);

            // Assert
            Assert.IsType<string>(result);

            Assert.IsAssignableFrom<string>(result);

            Assert.Equal("41211", result);
        }

        [Fact]
        public void Check_if_success_soma()
        {
            // Act
            var result = repo.Custom(2, 2);

            // Assert
            Assert.IsType<long>(result);

            Assert.IsAssignableFrom<long>(result);

            Assert.Equal(4, result);
        }
    }
}
