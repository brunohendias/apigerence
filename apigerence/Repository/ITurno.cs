using apigerence.Models;
using System.Collections.Generic;

namespace apigerence.Repository
{
    public interface ITurno
    {
        List<Turno> Get();

        Turno Find(long id);

        Turno Post(Turno request);

        Turno Put(Turno request);

        Turno Delete(long id);
    }
}
