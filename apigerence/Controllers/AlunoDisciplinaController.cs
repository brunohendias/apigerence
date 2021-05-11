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

                var query = (
                        from daluno in _context.AlunoDisciplinas
                        where daluno.cod_aluno == request.cod_aluno
                            || daluno.cod_bimestre == request.cod_bimestre
                            || daluno.SerieDisciplinas.cod_serie == request.SerieDisciplinas.cod_serie
                            || daluno.SerieDisciplinas.cod_disciplina == request.SerieDisciplinas.cod_disciplina
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
    }
}
