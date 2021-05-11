using apigerence.Models;
using apigerence.Models.Context;
using apigerence.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                        join aluno in _context.Alunos
                            on daluno.cod_aluno equals aluno.id
                        join bimestre in _context.Bimestres
                            on daluno.cod_bimestre equals bimestre.id
                        join sdiciplina in _context.SerieDisciplinas
                            on daluno.cod_serie_disc equals sdiciplina.id
                        join serie in _context.Series
                            on sdiciplina.cod_serie equals serie.id
                        join disciplina in _context.Disciplinas
                            on sdiciplina.cod_disciplina equals disciplina.id
                        select new
                        {
                            daluno,
                            aluno.nom_aluno,
                            bimestre.bimestre,
                            serie.serie,
                            disciplina.disciplina
                        }
                    ).ToList();

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpGet("notas")]
        public object Notas([FromBody] AlunoDisciplina request)
        {
            try
            {
                msg.success = "Buscamos as notas desse alunos com sucesso.";
                msg.fail = "Não encontramos as notas desse alunos.";

                var query = (
                        from daluno in _context.AlunoDisciplinas
                        join aluno in _context.Alunos
                            on daluno.cod_aluno equals aluno.id
                        join bimestre in _context.Bimestres
                            on daluno.cod_bimestre equals bimestre.id
                        join sdiciplina in _context.SerieDisciplinas
                            on daluno.cod_serie_disc equals sdiciplina.id
                        join serie in _context.Series
                            on sdiciplina.cod_serie equals serie.id
                        join disciplina in _context.Disciplinas
                            on sdiciplina.cod_disciplina equals disciplina.id
                        where daluno.cod_aluno == request.cod_aluno 
                            || daluno.cod_bimestre == request.cod_bimestre
                            || sdiciplina.cod_serie == request.cod_serie
                            || sdiciplina.cod_disciplina == request.cod_disciplina
                        select new
                        {
                            daluno,
                            aluno.nom_aluno,
                            bimestre.bimestre,
                            serie.serie,
                            disciplina.disciplina
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
