using apigerence.Models;
using apigerence.Repository;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace testgerence.Unitary
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
        public void Check_if_success_get_situacoes_aluno() => _mock.Get()
            .Returns(new List<SituacaoAluno>());

        [Fact]
        public void Check_if_success_find_situacao_aluno() => _mock.Find(id)
            .Returns(new SituacaoAluno());

        [Fact]
        public void Check_if_success_register_situacao_aluno() => _mock.Post(_register)
            .Returns(new SituacaoAluno());

        [Fact]
        public void Check_if_success_edit_situacao_aluno() => _mock.Put(_register)
            .Returns(new SituacaoAluno());

        [Fact]
        public void Check_if_success_delete_situacao_aluno() => _mock.Delete(id)
            .Returns(new SituacaoAluno());
    }
}
