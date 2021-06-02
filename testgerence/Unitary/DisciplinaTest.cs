using apigerence.Models;
using apigerence.Repository;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace testgerence.Unitary
{
    public class DisciplinaTest
    {
        private readonly IDisciplina _mock;

        private const long id = 1;

        private readonly static Disciplina _register = new()
        {
            cod_disciplina = 1,
            disciplina = "Disciplina teste"
        };

        public DisciplinaTest() => _mock = Substitute.For<IDisciplina>();

        [Fact]
        public void Check_if_success_get_disciplinas() => _mock.Get()
            .Returns(new List<Disciplina>());

        [Fact]
        public void Check_if_success_find_disciplina() => _mock.Find(id)
            .Returns(new Disciplina());

        [Fact]
        public void Check_if_success_register_disciplina() => _mock.Post(_register)
            .Returns(new Disciplina());

        [Fact]
        public void Check_if_success_edit_disciplina() => _mock.Put(_register)
            .Returns(new Disciplina());

        [Fact]
        public void Check_if_success_delete_disciplina() => _mock.Delete(id)
            .Returns(new Disciplina());
    }
}
