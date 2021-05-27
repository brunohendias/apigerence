using apigerence.Models;
using System.Collections.Generic;

namespace apigerence.Repository
{
    public interface ISituacaoAluno
    {
        List<SituacaoAluno> Get();

        SituacaoAluno Find(long id);

        SituacaoAluno Post(SituacaoAluno request);

        SituacaoAluno Put(SituacaoAluno request);

        SituacaoAluno Delete(long id);
    }
}
