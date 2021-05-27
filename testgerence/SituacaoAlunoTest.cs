using apigerence.Models;
using apigerence.Repository;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace testgerence
{
    public class SituacaoAlunoTest
    {
        private readonly ISituacaoAluno _mock;

        private const long id = 1;

        private readonly static SituacaoAluno _register = new()
        {
            cod_situacao = 1,
            situacao = "Situação aluno teste"
        };

        public SituacaoAlunoTest() => _mock = Substitute.For<ISituacaoAluno>();

        [Fact]
        public void Check_if_success_get_series() => _mock.Get()
            .Returns(new List<SituacaoAluno>());

        [Fact]
        public void Check_if_success_find_serie() => _mock.Find(id)
            .Returns(new SituacaoAluno());

        [Fact]
        public void Check_if_success_register_serie() => _mock.Post(_register)
            .Returns(new SituacaoAluno());

        [Fact]
        public void Check_if_success_edit_serie() => _mock.Put(_register)
            .Returns(new SituacaoAluno());

        [Fact]
        public void Check_if_success_delete_serie() => _mock.Delete(id)
            .Returns(new SituacaoAluno());
    }
}
