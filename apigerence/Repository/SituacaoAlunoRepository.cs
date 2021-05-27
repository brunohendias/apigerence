using apigerence.Models;
using apigerence.Models.Context;
using System.Collections.Generic;
using System.Linq;

namespace apigerence.Repository
{
    public class SituacaoAlunoRepository : ISituacaoAluno
    {
        private readonly MySqlContext _context;
        public SituacaoAlunoRepository(MySqlContext context) => _context = context;

        public List<SituacaoAluno> Get() => _context.SituacaoAlunos.ToList();

        public SituacaoAluno Find(long id) => _context.SituacaoAlunos.Find(id);

        public SituacaoAluno Post(SituacaoAluno request)
        {
            _context.SituacaoAlunos.Add(request);
            _context.SaveChanges();

            return request;
        }

        public SituacaoAluno Put(SituacaoAluno request)
        {
            SituacaoAluno dado = _context.SituacaoAlunos.Find(request.cod_situacao);
            if (dado == null) return null;

            _context.Entry(dado).CurrentValues.SetValues(request);
            _context.SaveChanges();

            return request;
        }

        public SituacaoAluno Delete(long id)
        {
            SituacaoAluno request = Find(id);
            if (request == null) return null;

            int vinculo = _context.Alunos.Where(aln => aln.cod_situacao == id).Count();
            if (vinculo > 0) return null;

            _context.SituacaoAlunos.Remove(request);
            _context.SaveChanges();

            return request;
        }
    }
}
