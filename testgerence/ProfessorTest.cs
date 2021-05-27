using apigerence.Models;
using apigerence.Repository;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace testgerence
{
    public class ProfessorTest
    {
        private readonly IProfessor _mock;

        private const long id = 1;

        private readonly static Professor _register = new()
        {
            nom_prof = "Disciplina teste"
        };

        public ProfessorTest() => _mock = Substitute.For<IProfessor>();

        [Fact]
        public void Check_if_success_get_atencoes() => _mock.Get()
            .Returns(new List<Professor>());

        [Fact]
        public void Check_if_success_find_atencao() => _mock.Find(id)
            .Returns(new Professor());

        [Fact]
        public void Check_if_success_register_atencao() => _mock.Post(_register)
            .Returns(new Professor());

        [Fact]
        public void Check_if_success_edit_serie() => _mock.Put(_register)
            .Returns(new Professor());

        [Fact]
        public void Check_if_success_delete_atencao() => _mock.Delete(id)
            .Returns(new Professor());
    }
}
