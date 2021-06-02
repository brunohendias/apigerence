using apigerence.Models;
using apigerence.Repository;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace testgerence.Unitary
{
    public class ProfessorTest
    {
        private readonly IProfessor _mock;

        private const long id = 1;

        private readonly static Professor _register = new()
        {
            cod_prof = 1,
            nom_prof = "Professor teste"
        };

        public ProfessorTest() => _mock = Substitute.For<IProfessor>();

        [Fact]
        public void Check_if_success_get_professores() => _mock.Get()
            .Returns(new List<Professor>());

        [Fact]
        public void Check_if_success_find_professor() => _mock.Find(id)
            .Returns(new Professor());

        [Fact]
        public void Check_if_success_register_professor() => _mock.Post(_register)
            .Returns(new Professor());

        [Fact]
        public void Check_if_success_edit_professor() => _mock.Put(_register)
            .Returns(new Professor());

        [Fact]
        public void Check_if_success_delete_professor() => _mock.Delete(id)
            .Returns(new Professor());
    }
}
