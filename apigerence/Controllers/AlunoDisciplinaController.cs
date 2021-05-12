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
    public class AlunoDisciplinaController : ResponseService
    {
        private readonly MySqlContext _context;
        public AlunoDisciplinaController(MySqlContext context) => _context = context;

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
                            daluno.Alunos,
                            daluno.SerieDisciplinas.Serie.serie,
                            daluno.SerieDisciplinas.Disciplina.disciplina,
                            daluno.Bimestres.bimestre
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
        public object Notas([FromQuery] AlunoDisciplina request)
        {
            try
            {
                msg.success = "Buscamos as notas desse alunos com sucesso.";
                msg.fail = "Não encontramos as notas desse alunos.";

                long cod_aluno = request.cod_aluno;
                long cod_bimestre = request.cod_bimestre;
                long cod_serie = request.SerieDisciplinas.cod_serie;
                long cod_disciplina = request.SerieDisciplinas.cod_disciplina;

                var query = (
                        from daluno in _context.AlunoDisciplinas
                        where daluno.cod_aluno == cod_aluno
                            || daluno.cod_bimestre == cod_bimestre
                            || daluno.SerieDisciplinas.cod_serie == cod_serie
                            || daluno.SerieDisciplinas.cod_disciplina == cod_disciplina
                        select new
                        {
                            daluno,
                            daluno.Alunos.nom_aluno,
                            daluno.SerieDisciplinas.Serie.serie,
                            daluno.SerieDisciplinas.Disciplina.disciplina,
                            daluno.Bimestres.bimestre
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

        private bool DadosInvalido(AlunoDisciplina request)
        {
            if (request.nota > 100 || request.nota < 0) return true;
            Aluno aluno = _context.Alunos.Find(request.cod_aluno);
            if (aluno == null) return true;
            SerieDisciplina disciplina = _context.SerieDisciplinas.Find(request.cod_serie_disc);
            if (disciplina == null) return true;
            Bimestre bimestre = _context.Bimestres.Find(request.cod_bimestre);
            return bimestre == null;
        }

        [HttpPost]
        public object Post([FromBody] AlunoDisciplina request)
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
        public object Put([FromBody] AlunoDisciplina request)
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
