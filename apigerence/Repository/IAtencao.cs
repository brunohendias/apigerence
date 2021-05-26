using apigerence.Models;
using System.Collections.Generic;

namespace apigerence.Repository
{
    public interface IAtencao
    {
        List<Atencao> Get();

        Atencao Find(long id);

        Atencao Post(Atencao request);

        Atencao Delete(long id);
    }
}
