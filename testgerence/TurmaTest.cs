using apigerence.Models;
using apigerence.Repository;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace testgerence
{
    public class TurmaTest
    {
        private readonly ITurma _mock;

        private const long id = 1;

        private readonly static Turma _register = new()
        {
            cod_turma = 1,
            turma = "Turma teste"
        };

        public TurmaTest() => _mock = Substitute.For<ITurma>();

        [Fact]
        public void Check_if_success_get_turmas() => _mock.Get()
            .Returns(new List<Turma>());

        [Fact]
        public void Check_if_success_find_turma() => _mock.Find(id)
            .Returns(new Turma());

        [Fact]
        public void Check_if_success_register_turma() => _mock.Post(_register)
            .Returns(new Turma());

        [Fact]
        public void Check_if_success_edit_turma() => _mock.Put(_register)
            .Returns(new Turma());

        [Fact]
        public void Check_if_success_delete_turma() => _mock.Delete(id)
            .Returns(new Turma());
    }
}
