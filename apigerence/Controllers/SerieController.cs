using apigerence.Models;
using apigerence.Models.Context;
using apigerence.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace apigerence.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SerieController : ResponseService
    {
        public SerieController(MySqlContext context) : base(context) { }

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos as séries com successo.";
                msg.fail = "Não encontramos as séries.";

                var query = ( from serie in _context.Series select serie ).ToList();

                Dados = query.Count == 0 ? null : query;

                return MontaRetorno();
            }
            catch(Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpPost]
        public object Post([FromBody] Serie request)
        {
            try
            {
                msg.success = "Cadastramos essa série com successo.";
                msg.fail = "Não conseguimos cadastrar essa série.";

                _context.Series.Add(request);
                _context.SaveChanges();

                Dados = request;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpGet("{id}")]
        public object FindById(long id)
        {
            try
            {
                msg.success = "Buscamos essa série com successo.";
                msg.fail = "Não conseguimos encontrar essa série.";

                Serie dado = _context.Series.Find(id);
                Dados = dado;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpPut]
        public object Put([FromBody] Serie request)
        {
            try
            {
                msg.success = "Editamos essa série com successo.";
                msg.fail = "Não conseguimos encontrar essa série.";

                Serie dado = _context.Series.Find(request.cod_serie);
                if (dado == null) return RespFail();

                _context.Entry(dado).CurrentValues.SetValues(request);
                _context.SaveChanges();

                Dados = request;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpDelete("{id}")]
        public object Delete(long id)
        {
            try
            {
                msg.success = "Removemos essa série com successo.";
                msg.fail = "Não encontramos essa série.";

                Serie dado = _context.Series.Find(id);
                if (dado == null) return RespFail();

                int vinculo = _context.SerieVinculos.Where(serie => serie.cod_serie == id).Count();
                if (vinculo > 0)
                {
                    msg.fail = "Não podemos remover uma série que esta sendo utilizada.";
                    return RespFail();
                }

                _context.Series.Remove(dado);
                _context.SaveChanges();

                Dados = dado;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }
    }
}
