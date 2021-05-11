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
    public class SerieDisciplinaController : ResponseService
    {
        private readonly MySqlContext _context;
        public SerieDisciplinaController(MySqlContext context) => _context = context;

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos as disciplinas das séries com sucesso.";
                msg.fail = "Não conseguimos encontrar as disciplinas das séries.";

                var query = (
                        from v in _context.SerieDisciplinas
                        select new { v.id, v.Serie, v.Disciplina }
                    ).ToList();

                if (query.Count > 0) Dados = query;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpGet("find")]
        public object Find([FromQuery] SerieDisciplina request)
        {
            try
            {
                msg.success = "Buscamos as disciplinas dessa série com sucesso.";
                msg.fail = "Não conseguimos encontrar as disciplinas dessa série.";

                var query = (
                        from v in _context.SerieDisciplinas
                        where v.cod_serie == request.cod_serie 
                            || v.cod_disciplina == request.cod_disciplina
                        select new { v.id, v.Serie, v.Disciplina }
                    ).ToList();

                if (query.Count > 0) Dados = query;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }
    }
}
