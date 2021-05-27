using apigerence.Models;
using apigerence.Models.Context;
using System.Collections.Generic;
using System.Linq;

namespace apigerence.Repository
{
    public class DisciplinaRepository : IDisciplina
    {
        private readonly MySqlContext _context;
        public DisciplinaRepository(MySqlContext context) => _context = context;

        public List<Disciplina> Get() => _context.Disciplinas.ToList();

        public Disciplina Find(long id) => _context.Disciplinas.Find(id);

        public Disciplina Post(Disciplina request)
        {
            _context.Disciplinas.Add(request);
            _context.SaveChanges();

            return request;
        }

        public Disciplina Put(Disciplina request)
        {
            Disciplina dado = _context.Disciplinas.Find(request.cod_disciplina);
            if (dado == null) return null;

            _context.Entry(dado).CurrentValues.SetValues(request);
            _context.SaveChanges();

            return request;
        }

        public Disciplina Delete(long id)
        {
            Disciplina request = Find(id);
            if (request == null) return null;

            int vinculo = _context.SerieDisciplinas.Where(serie => serie.cod_disciplina == id).Count();
            if (vinculo > 0) return null;

            _context.Disciplinas.Remove(request);
            _context.SaveChanges();

            return request;
        }
    }
}
