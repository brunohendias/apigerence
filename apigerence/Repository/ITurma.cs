using apigerence.Models;
using System.Collections.Generic;

namespace apigerence.Repository
{
    public interface ITurma
    {
        List<Turma> Get();

        Turma Find(long id);

        Turma Post(Turma request);

        Turma Put(Turma request);

        Turma Delete(long id);
    }
}
