using apigerence.Models;
using apigerence.Models.Context;
using System.Collections.Generic;
using System.Linq;

namespace apigerence.Repository
{
    public class ProfessorRepository : IProfessor
    {
        private readonly MySqlContext _context;
        public ProfessorRepository(MySqlContext context) => _context = context;

        public List<Professor> Get() => _context.Professores.ToList();

        public Professor Find(long id) => _context.Professores.Find(id);

        public Professor Post(Professor request)
        {
            _context.Professores.Add(request);
            _context.SaveChanges();

            return request;
        }

        public Professor Put(Professor request)
        {
            Professor dado = _context.Professores.Find(request.cod_prof);
            if (dado == null) return null;

            _context.Entry(dado).CurrentValues.SetValues(request);
            _context.SaveChanges();

            return request;
        }

        public Professor Delete(long id)
        {
            Professor request = Find(id);
            if (request == null) return null;

            int vinculo = _context.SerieVinculos.Where(serie => serie.cod_prof == id).Count();
            if (vinculo > 0) return null;

            _context.Professores.Remove(request);
            _context.SaveChanges();

            return request;
        }
    }
}
