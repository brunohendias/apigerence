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
    public class SerieDisciplinaController : ResponseService
    {
        public SerieDisciplinaController(MySqlContext context) : base(context) { }

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos as disciplinas das séries com sucesso.";
                msg.fail = "Não conseguimos encontrar as disciplinas das séries.";

                List<SerieDisciplina> query = _context.SerieDisciplinas.ToList();

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
                        from dados in _context.SerieDisciplinas
                        where dados.cod_serie == request.cod_serie 
                            || dados.cod_disciplina == request.cod_disciplina
                        select dados
                    ).ToList();

                if (query.Count > 0) Dados = query;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpPost]
        public object Post(SerieDisciplina request)
        {
            try
            {
                msg.success = "Cadastramos essa disciplina nessa série com sucesso.";
                msg.fail = "Não conseguimos cadastrar essa disciplina nessa série.";

                Disciplina disciplina = _context.Disciplinas.Find(request.cod_disciplina);
                if (disciplina == null)
                {
                    msg.fail = "Não conseguimos encontrar essa disciplina.";
                    return RespFail();
                }

                Serie serie = _context.Series.Find(request.cod_serie);
                if (serie == null)
                {
                    msg.fail = "Não conseguimos encontrar essa série.";
                    return RespFail();
                }

                SerieDisciplina dados = new()
                {
                    cod_serie = request.cod_serie,
                    cod_disciplina = request.cod_disciplina
                };

                _context.SerieDisciplinas.Add(dados);
                _context.SaveChanges();

                Dados = dados;

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
                msg.success = "Removemos essa disciplina dessa série com sucesso.";
                msg.fail = "Não conseguimos remover essa disciplina dessa série.";

                SerieDisciplina dados = _context.SerieDisciplinas.Find(id);
                if (dados == null)
                {
                    msg.fail = "Não conseguimos encontrar essa disciplina nessa série.";
                    return RespFail();
                }

                int vinculo = _context.AlunoDisciplinas.Where(aluno => aluno.cod_serie_disc == dados.cod_serie_disc).Count();
                if (vinculo > 0)
                {
                    msg.fail = "Não podemos remover uma disciplina de uma série que possui aluno.";
                    return RespFail();
                }

                _context.SerieDisciplinas.Remove(dados);
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
