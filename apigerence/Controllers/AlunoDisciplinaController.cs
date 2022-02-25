using apigerence.Models;
using apigerence.Models.Context;
using apigerence.Requests;
using apigerence.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace apigerence.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlunoDisciplinaController : ResponseService
    {
        public AlunoDisciplinaController(MySqlContext context) : base(context) { }

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos as notas dos alunos com sucesso.";
                msg.fail = "Não encontramos as notas dos alunos.";

                var query = (
                        from daluno in _context.AlunoDisciplinas
                        select new
                        {
                            daluno.Aluno,
                            daluno.SerieDisciplina.Serie.serie,
                            daluno.SerieDisciplina.Disciplina.disciplina,
                            daluno.Bimestre.bimestre
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

        [HttpGet("notas")]
        public object Notas([FromQuery] AlunoDisciplinaRequestGet request)
        {
            try
            {
                msg.success = "Buscamos as notas desse alunos com sucesso.";
                msg.fail = "Não encontramos as notas desse alunos.";

                var query = (
                        from daluno in _context.AlunoDisciplinas
                        where daluno.cod_aluno == request.cod_aluno
                            || daluno.cod_bimestre == request.cod_bimestre
                            || daluno.SerieDisciplina.cod_serie == request.cod_serie
                            || daluno.SerieDisciplina.cod_disciplina == request.cod_disciplina
                        select new
                        {
                            daluno,
                            daluno.Aluno.nome,
                            daluno.SerieDisciplina.Serie.serie,
                            daluno.SerieDisciplina.Disciplina.disciplina,
                            daluno.Bimestre.bimestre
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

        private bool DadosInvalido(AlunoDisciplinaRequestPost request) =>
            request.nota > 100 || request.nota < 0
         || _context.Alunos.Find(request.cod_aluno) == null
         || _context.SerieDisciplinas.Find(request.cod_serie_disc) == null
         || _context.Bimestres.Find(request.cod_bimestre) == null;

        [HttpPost]
        public object Post([FromBody] AlunoDisciplinaRequestPost request)
        {
            try
            {
                msg.success = "Cadastramos essa nota para esse aluno com sucesso.";
                msg.fail = "Não conseguimos cadastrar essa nota para esse aluno.";

                if (DadosInvalido(request))
                {
                    msg.fail = "Existe dado invalido.";
                    return RespFail();
                }

                AlunoDisciplina dados = new()
                {
                    nota = request.nota,
                    cod_aluno = request.cod_aluno,
                    cod_serie_disc = request.cod_serie_disc,
                    cod_bimestre = request.cod_bimestre
                };

                _context.AlunoDisciplinas.Add(dados);
                _context.SaveChanges();

                Dados = dados;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpPut]
        public object Put([FromBody] AlunoDisciplinaRequestPost request)
        {
            try
            {
                msg.success = "Editamos essa nota com sucesso.";
                msg.fail = "Não conseguimos editar essa nota.";

                if (DadosInvalido(request))
                {
                    msg.fail = "Existe dado invalido.";
                    return RespFail();
                }

                AlunoDisciplina dado = _context.AlunoDisciplinas.Find(request.cod_aluno_disc);
                if (dado == null)
                {
                    msg.fail = "Não conseguimos encontrar essa nota.";
                    return RespFail();
                }

                AlunoDisciplina dados = new()
                {
                    nota = request.nota,
                    cod_aluno = request.cod_aluno,
                    cod_serie_disc = request.cod_serie_disc,
                    cod_bimestre = request.cod_bimestre
                };

                _context.Entry(dado).CurrentValues.SetValues(dados);
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
