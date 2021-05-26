using apigerence.Models;
using apigerence.Repository;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace testgerence
{
    public class SerieTest
    {
        private readonly ISerie _mock;

        private const long id = 1;

        private readonly static Serie _register = new()
        {
            cod_serie = 1,
            serie = "Atenção teste"
        };

        public SerieTest() => _mock = Substitute.For<ISerie>();

        [Fact]
        public void Check_if_success_get_series() => _mock.Get()
            .Returns(new List<Serie>());

        [Fact]
        public void Check_if_success_find_serie() => _mock.Find(id)
            .Returns(new Serie());

        [Fact]
        public void Check_if_success_register_serie() => _mock.Post(_register)
            .Returns(new Serie());

        [Fact]
        public void Check_if_success_edit_serie() => _mock.Put(_register)
            .Returns(new Serie());

        [Fact]
        public void Check_if_success_delete_serie() => _mock.Delete(id)
            .Returns(new Serie());
    }
}
