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
    public class AlunoController : ResponseService
    {
        private readonly MySqlContext _context;
        private readonly int SituacaoInicialAluno = 3;
        public AlunoController(MySqlContext context) => _context = context;

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos os alunos com sucesso.";
                msg.fail = "Não conseguimos encontrar os alunos.";

                var query = (
                    from aluno in _context.Alunos
                    select new
                    {
                        aluno,
                        aluno.Atencao.atencao,
                        aluno.Situacao.situacao,
                        aluno.InfosSerie.Serie.serie,
                        aluno.InfosSerie.Turno.turno,
                        aluno.InfosSerie.Turma.turma,
                        aluno.InfosSerie.Professor.nom_prof
                    }
                ).ToList();

                if (query.Count > 0) Dados = query;

                return MontaRetorno();
            }
            catch(Exception e)
            {
                return RespErrorLog(e);
            }
        }

        private Candidato BuscaCandidato(long cod_can) => _context.Candidatos.Find(cod_can);

        private SerieVinculo BuscaDadosSerie(long cod_serie_v) => _context.SerieVinculos.Find(cod_serie_v);

        private static string GeraRA(Aluno request) => 
            "" + request.cod_can + request.cod_atencao + request.cod_situacao + request.cod_serie_v + request.cod_atencao;

        [HttpPost]
        public object Post([FromBody] Aluno request)
        {
            try
            {
                msg.success = "Cadastramos esse aluno com sucesso.";
                msg.fail = "Não conseguimos cadastrar esse aluno.";

                long cod_can = request.cod_can;
                long cod_serie_v = request.cod_serie_v;
                long cod_atencao = request.cod_atencao;

                Candidato candidato = BuscaCandidato(cod_can);
                if (candidato == null)
                {
                    msg.fail = "Não conseguimos encontrar esse candidato.";
                    return RespFail();
                }

                SerieVinculo vserie = BuscaDadosSerie(cod_serie_v);
                if (candidato == null)
                {
                    msg.fail = "Não conseguimos encontrar os dados dessa série.";
                    return RespFail();
                }

                Aluno dados = new()
                {
                    nome = request.nome,
                    num_matricula = GeraRA(request),
                    cod_can = cod_can,
                    cod_serie_v = cod_serie_v,
                    cod_atencao = cod_atencao,
                    cod_situacao = SituacaoInicialAluno
                };

                _context.Alunos.Add(dados);
                _context.SaveChanges();

                Dados = dados;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }
    }
}
