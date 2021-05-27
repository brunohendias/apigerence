using apigerence.Models;
using apigerence.Models.Context;
using System.Collections.Generic;
using System.Linq;

namespace apigerence.Repository
{
    public class AtencaoRepository : IAtencao
    {
        private readonly MySqlContext _context;
        public AtencaoRepository(MySqlContext context) => _context = context;

        public List<Atencao> Get() => _context.Atencoes.ToList();

        public Atencao Find(long id) => _context.Atencoes.Find(id);

        public Atencao Post(Atencao request)
        {
            _context.Atencoes.Add(request);
            _context.SaveChanges();

            return request;
        }

        public Atencao Put(Atencao request)
        {
            Atencao dado = _context.Atencoes.Find(request.cod_atencao);
            if (dado == null) return null;

            _context.Entry(dado).CurrentValues.SetValues(request);
            _context.SaveChanges();

            return request;
        }

        public Atencao Delete(long id)
        {
            Atencao request = Find(id);
            if (request == null) return null;

            _context.Atencoes.Remove(request);
            _context.SaveChanges();

            return request;
        }
    }
}
