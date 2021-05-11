using apigerence.Models.Context;
using apigerence.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
                        from disciplinaS in _context.SerieDisciplinas
                        join serie in _context.Series
                            on disciplinaS.cod_serie equals serie.id
                        join disciplina in _context.Disciplinas
                            on disciplinaS.cod_disciplina equals disciplina.id
                        orderby disciplinaS.cod_serie
                        select new {
                            disciplinaS,
                            serie.id,
                            disciplina
                        }
                    ).ToList();

                if (query.Count > 0) Dados = query;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpGet("disciplinas/{id}")]
        public object Disciplinas(long id)
        {
            try
            {
                msg.success = "Buscamos as disciplinas dessa série com sucesso.";
                msg.fail = "Não conseguimos encontrar as disciplinas dessa série.";

                var query = (
                        from disciplinaS in _context.SerieDisciplinas
                        join disciplina in _context.Disciplinas
                            on disciplinaS.cod_disciplina equals disciplina.id
                        where disciplinaS.cod_serie == id
                        select disciplina
                    ).ToList();

                if (query.Count > 0) Dados = query;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpGet("series/{id}")]
        public object Series(long id)
        {
            try
            {
                msg.success = "Buscamos as séries que possuem essa disciplina com sucesso.";
                msg.fail = "Não conseguimos encontrar as séries que possuem essa disciplina.";

                var query = (
                        from disciplinaS in _context.SerieDisciplinas
                        join serie in _context.Series
                            on disciplinaS.cod_serie equals serie.id
                        where disciplinaS.cod_disciplina == id
                        select serie
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
