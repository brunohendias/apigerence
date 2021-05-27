using apigerence.Models;
using System.Collections.Generic;

namespace apigerence.Repository
{
    public interface IDisciplina
    {
        List<Disciplina> Get();

        Disciplina Find(long id);

        Disciplina Post(Disciplina request);

        Disciplina Put(Disciplina request);

        Disciplina Delete(long id);
    }
}
