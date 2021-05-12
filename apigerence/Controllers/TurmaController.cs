using System;
using System.Collections.Generic;
using System.Linq;
using apigerence.Models;
using apigerence.Models.Context;
using apigerence.Services;
using Microsoft.AspNetCore.Mvc;

namespace apigerence.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TurmaController : ResponseService
    {
        public TurmaController(MySqlContext context) : base(context) { }

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos as turmas com sucesso.";
                msg.fail = "Não encontramos as turmas.";

                List<Turma> query = (from turma in _context.Turmas select turma).ToList();

                if (query.Count > 0) Dados = query;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpPost]
        public object Post([FromBody] Turma request)
        {
            try
            {
                msg.success = "Cadastramos essa turma com sucesso.";
                msg.fail = "Não conseguimos cadastrar essa turma.";

                _context.Turmas.Add(request);
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
                msg.success = "Removemos essa turma com sucesso.";
                msg.fail = "Não encontramos essa turma.";

                Turma request = _context.Turmas.Find(id);
                if (request == null) return RespFail();

                int vinculo = _context.SerieVinculos.Where(vserie => vserie.cod_turma == id).Count();
                if (vinculo > 0)
                {
                    msg.fail = "Não podemos remover uma turma que esta sendo utilizada.";
                    return RespFail();
                }

                _context.Turmas.Remove(request);
                _context.SaveChanges();

                Dados = request;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }
    }
}
