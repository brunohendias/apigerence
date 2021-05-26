using apigerence.Models;
using apigerence.Models.Context;
using System.Collections.Generic;
using System.Linq;

namespace apigerence.Repository
{
    public class TurnoRepository : ITurno
    {
        private readonly MySqlContext _context;
        public TurnoRepository(MySqlContext context) => _context = context;

        public List<Turno> Get() => _context.Turnos.ToList();

        public Turno Find(long id) => _context.Turnos.Find(id);

        public Turno Post(Turno request)
        {
            _context.Turnos.Add(request);
            _context.SaveChanges();

            return request;
        }

        public Turno Put(Turno request)
        {
            Turno dado = _context.Turnos.Find(request.cod_turno);
            if (dado == null) return null;

            _context.Entry(dado).CurrentValues.SetValues(request);
            _context.SaveChanges();

            return request;
        }

        public Turno Delete(long id)
        {
            Turno request = Find(id);
            if (request == null) return null;

            int vinculo = _context.SerieVinculos.Where(serie => serie.cod_turno == id).Count();
            if (vinculo > 0) return null;

            _context.Turnos.Remove(request);
            _context.SaveChanges();

            return request;
        }
    }
}
