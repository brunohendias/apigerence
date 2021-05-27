using apigerence.Models;
using System.Collections.Generic;

namespace apigerence.Repository
{
    public interface IProfessor
    {
        List<Professor> Get();

        Professor Find(long id);

        Professor Post(Professor request);

        Professor Put(Professor request);

        Professor Delete(long id);
    }
}
