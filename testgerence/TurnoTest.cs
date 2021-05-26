using apigerence.Models;
using apigerence.Repository;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace testgerence
{
    public class TurnoTest
    {
        private readonly ITurno _mock;

        private const long id = 1;

        private readonly static Turno _register = new()
        {
            cod_turno = 1,
            turno = "Turno teste"
        };

        public TurnoTest() => _mock = Substitute.For<ITurno>();

        [Fact]
        public void Check_if_success_get_turnos() => _mock.Get()
            .Returns(new List<Turno>());

        [Fact]
        public void Check_if_success_find_turno() => _mock.Find(id)
            .Returns(new Turno());

        [Fact]
        public void Check_if_success_register_turno() => _mock.Post(_register)
            .Returns(new Turno());

        [Fact]
        public void Check_if_success_edit_turno() => _mock.Put(_register)
            .Returns(new Turno());

        [Fact]
        public void Check_if_success_delete_turno() => _mock.Delete(id)
            .Returns(new Turno());
    }
}
