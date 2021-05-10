using apigerence.Models;
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
    public class CandidatoController : ResponseService
    {
        private readonly MySqlContext _context;

        public CandidatoController(MySqlContext context) => _context = context;

        [HttpGet]
        public object Get()
        {   
            try
            {
                msg.success = "Buscamos os candidatos com successo.";
                msg.fail = "Não encontramos os candidatos.";

                var query = (
                    from candidato in _context.Candidatos
                    join atencao in _context.Atencoes
                        on candidato.cod_atencao equals atencao.id
                    join vserie in _context.SerieVinculos
                        on candidato.cod_serie_v equals vserie.id
                    join serie in _context.Series
                        on vserie.cod_serie equals serie.id
                    join turno in _context.Turnos
                        on vserie.cod_turno equals turno.id
                    join turma in _context.Turmas
                        on vserie.cod_turma equals turma.id
                    join professor in _context.Professores
                        on vserie.cod_prof equals professor.id
                  select new {
                        candidato,
                        atencao,
                        serie,
                        turno,
                        turma,
                        professor
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

        private Inscricao BuscaInscricao(long cod_insc) => _context.Inscricoes.Find(cod_insc);

        private SerieVinculo BuscaDadosSerie(long cod_serie_v) => _context.SerieVinculos.Find(cod_serie_v);

        [HttpPost]
        public object Post(Candidato request)
        {
            try
            {
                msg.success = "Cadastramos esse candidato com successo.";
                msg.fail = "Não conseguimos cadastrar esse candidato.";

                SerieVinculo vserie = BuscaDadosSerie(request.cod_serie_v);
                if (vserie == null)
                {
                    msg.fail = "Não conseguimos encontrar essa série.";
                    return RespFail();
                }
                
                Inscricao insc = BuscaInscricao(request.cod_insc);
                if (insc == null)
                {
                    msg.fail = "Não conseguimos encontrar a inscrição desse candidato.";
                    return RespFail();
                }

                _context.Candidatos.Add(request);
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
