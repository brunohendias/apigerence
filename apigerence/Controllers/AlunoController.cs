﻿using apigerence.Models;
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
                    join atencao in _context.Atencoes
                        on aluno.cod_atencao equals atencao.id
                    join situacao in _context.SituacaoAlunos
                        on aluno.cod_situacao equals situacao.id
                    join dados in _context.SerieVinculos
                        on aluno.cod_serie_v equals dados.id
                    join serie in _context.Series
                        on dados.cod_serie equals serie.id
                    join turno in _context.Turnos
                        on dados.cod_turno equals turno.id
                    join turma in _context.Turmas
                        on dados.cod_turma equals turma.id
                    join professor in _context.Professores
                        on dados.cod_prof equals professor.id
                    select new
                    {
                        aluno,
                        serie.serie,
                        turno.turno,
                        turma.turma,
                        professor.nom_prof,
                        atencao.atencao,
                        situacao.situacao
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
        public object Post(Aluno request)
        {
            try
            {
                msg.success = "Cadastramos esse aluno com sucesso.";
                msg.fail = "Não conseguimos cadastrar esse aluno.";

                Candidato candidato = BuscaCandidato(request.cod_can);
                if (candidato == null)
                {
                    msg.fail = "Não conseguimos encontrar esse candidato.";
                    return RespFail();
                }

                SerieVinculo vserie = BuscaDadosSerie(request.cod_serie_v);
                if (candidato == null)
                {
                    msg.fail = "Não conseguimos encontrar os dados dessa série.";
                    return RespFail();
                }

                Aluno dados = new()
                {
                    nom_aluno = request.nom_aluno,
                    email = request.email,
                    telefone = request.telefone,
                    cpf = request.cpf,
                    num_matricula = GeraRA(request),
                    cod_can = request.cod_can,
                    cod_serie_v = request.cod_serie_v,
                    cod_atencao = request.cod_atencao,
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
