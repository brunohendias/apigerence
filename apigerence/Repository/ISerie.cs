using apigerence.Models;
using System.Collections.Generic;

namespace apigerence.Repository
{
    public interface ISerie
    {
        List<Serie> Get();

        Serie Find(long id);

        Serie Post(Serie request);

        Serie Put(Serie request);

        Serie Delete(long id);
    }
}
