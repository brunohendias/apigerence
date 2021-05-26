using apigerence.Models;
using apigerence.Models.Context;
using System.Collections.Generic;
using System.Linq;

namespace apigerence.Repository
{
    public class SerieRepository : ISerie
    {

        private readonly MySqlContext _context;
        public SerieRepository(MySqlContext context) => _context = context;

        public List<Serie> Get() => _context.Series.ToList();

        public Serie Find(long id) => _context.Series.Find(id);

        public Serie Post(Serie request)
        {
            _context.Series.Add(request);
            _context.SaveChanges();

            return request;
        }

        public Serie Put(Serie request)
        {
            Serie dado = _context.Series.Find(request.cod_serie);
            if (dado == null) return null;

            _context.Entry(dado).CurrentValues.SetValues(request);
            _context.SaveChanges();

            return request;
        }

        public Serie Delete(long id)
        {
            Serie request = Find(id);
            if (request == null) return null;

            int vinculo = _context.SerieVinculos.Where(serie => serie.cod_serie == id).Count();
            if (vinculo > 0) return null;

            _context.Series.Remove(request);
            _context.SaveChanges();

            return request;
        }
    }
}
