using apigerence.Models;
using apigerence.Repository;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace testgerence
{
    public class DisciplinaTest
    {
        private readonly IDisciplina _mock;

        private const long id = 1;

        private readonly static Disciplina _register = new()
        {
            disciplina = "Disciplina teste"
        };

        public DisciplinaTest() => _mock = Substitute.For<IDisciplina>();

        [Fact]
        public void Check_if_success_get_atencoes() => _mock.Get()
            .Returns(new List<Disciplina>());

        [Fact]
        public void Check_if_success_find_atencao() => _mock.Find(id)
            .Returns(new Disciplina());

        [Fact]
        public void Check_if_success_register_atencao() => _mock.Post(_register)
            .Returns(new Disciplina());

        [Fact]
        public void Check_if_success_edit_serie() => _mock.Put(_register)
            .Returns(new Disciplina());

        [Fact]
        public void Check_if_success_delete_atencao() => _mock.Delete(id)
            .Returns(new Disciplina());
    }
}
