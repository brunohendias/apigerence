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
                    select new {
                        candidato,
                        candidato.Atencao.atencao,
                        candidato.InfosSerie.Serie.serie,
                        candidato.InfosSerie.Turno.turno,
                        candidato.InfosSerie.Turma.turma,
                        candidato.InfosSerie.Professor.nom_prof
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
        public object Post([FromBody] Candidato request)
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
                else if (vserie.qtd_alunos == vserie.limite_alunos)
                {
                    msg.success = "Cadastramos esse candidato com successo. " +
                        "Porém passou do limite de alunos nessa série, " +
                        "lembresse que é permitido ter apenas " + vserie.limite_alunos + " Alunos";
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
