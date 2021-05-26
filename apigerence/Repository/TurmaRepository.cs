using apigerence.Models;
using apigerence.Models.Context;
using System.Collections.Generic;
using System.Linq;

namespace apigerence.Repository
{
    public class TurmaRepository : ITurma
    {
        private readonly MySqlContext _context;
        public TurmaRepository(MySqlContext context) => _context = context;

        public List<Turma> Get() => _context.Turmas.ToList();

        public Turma Find(long id) => _context.Turmas.Find(id);

        public Turma Post(Turma request)
        {
            _context.Turmas.Add(request);
            _context.SaveChanges();

            return request;
        }

        public Turma Put(Turma request)
        {
            Turma dado = _context.Turmas.Find(request.cod_turma);
            if (dado == null) return null;

            _context.Entry(dado).CurrentValues.SetValues(request);
            _context.SaveChanges();

            return request;
        }

        public Turma Delete(long id)
        {
            Turma request = Find(id);
            if (request == null) return null;

            int vinculo = _context.SerieVinculos.Where(serie => serie.cod_turma == id).Count();
            if (vinculo > 0) return null;

            _context.Turmas.Remove(request);
            _context.SaveChanges();

            return request;
        }
    }
}
