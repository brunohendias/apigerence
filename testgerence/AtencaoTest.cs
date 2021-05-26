using apigerence.Repository;
using NSubstitute;
using apigerence.Models;
using System.Collections.Generic;
using Xunit;

namespace testgerence
{
    public class AtencaoTest
    {
        private readonly IAtencao _mock;

        private const long id = 10;

        private readonly static Atencao _register = new()
        {
            atencao = "Aten��o teste"
        };

        public AtencaoTest() => _mock = Substitute.For<IAtencao>();

        [Fact]
        public void Check_if_success_get_atencoes() => _mock.Get()
            .Returns(new List<Atencao>());

        [Fact]
        public void Check_if_success_find_atencao() => _mock.Find(id)
            .Returns(new Atencao());

        [Fact]
        public void Check_if_success_register_atencao() =>_mock.Post(_register)
            .Returns(new Atencao());

        [Fact]
        public void Check_if_success_delete_atencao() => _mock.Delete(id)
            .Returns((Atencao)null);
    }
}