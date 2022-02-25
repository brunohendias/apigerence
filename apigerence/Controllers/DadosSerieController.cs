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
    public class DadosSerieController : ResponseService
    {
        public DadosSerieController(MySqlContext context) : base(context) { }

        [HttpGet]
        public object Get([FromQuery] SerieVinculoRequestGet request)
        {
            try
            {
                msg.success = "Buscamos as informações das séries com successo.";
                msg.fail = "Não encontramos as informações das séries.";

                var query = (
                    from dados in _context.SerieVinculos
                    where dados.cod_serie == request.cod_serie
                        || dados.cod_turno == request.cod_turno
                        || dados.cod_turma == request.cod_turma
                        || dados.cod_prof == request.cod_prof
                    select new
                    {
                        dados,
                        dados.Serie.serie,
                        dados.Turno.turno,
                        dados.Turma.turma,
                        dados.Professor.nom_prof
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

        private SerieVinculo Find(long id) => _context.SerieVinculos.Find(id);

        private bool DadosInvalido(SerieVinculoRequestPost request) =>
            _context.Series.Find(request.cod_serie) == null
         || _context.Turnos.Find(request.cod_turno) == null
         || _context.Turmas.Find(request.cod_turma) == null
         || _context.Professores.Find(request.cod_prof) == null;

        [HttpPost]
        public object Post([FromBody] SerieVinculoRequestPost request)
        {
            try
            {
                msg.success = "Cadastramos as informações dessa série com successo.";
                msg.fail = "Não conseguimos cadastrar as informações dessa série.";

                if (DadosInvalido(request))
                {
                    msg.fail = "Existe dado invalido.";
                    return RespFail();
                }

                SerieVinculo dados = new()
                {
                    cod_serie = request.cod_serie,
                    cod_turno = request.cod_turno,
                    cod_turma = request.cod_turma,
                    cod_prof = request.cod_prof,
                    limite_alunos = request.limite_alunos
                };

                _context.SerieVinculos.Add(dados);
                _context.SaveChanges();

                Dados = dados;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpGet("{id}")]
        public object FindById(long id)
        {
            try
            {
                msg.success = "Buscamos as informações dessa série com successo.";
                msg.fail = "Não conseguimos encontrar as informações dessa série.";

                var query = (
                    from dados in _context.SerieVinculos
                    where dados.cod_serie_v == id
                    select new
                    {
                        dados,
                        dados.Serie.serie,
                        dados.Turno.turno,
                        dados.Turma.turma,
                        dados.Professor.nom_prof
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

        [HttpPut]
        public object Put([FromBody] SerieVinculoRequestPost request)
        {
            try
            {
                msg.success = "Editamos as informações dessa série com successo.";
                msg.fail = "Não conseguimos encontrar as informações dessa série.";

                SerieVinculo dado = Find(request.cod_serie_v);
                if (dado == null) return RespFail();

                if (DadosInvalido(request))
                {
                    msg.fail = "Existe dado invalido.";
                    return RespFail();
                }

                SerieVinculo dados = new()
                {
                    cod_serie_v = request.cod_serie_v,
                    cod_serie = request.cod_serie,
                    cod_turno = request.cod_turno,
                    cod_turma = request.cod_turma,
                    cod_prof = request.cod_prof,
                    limite_alunos = request.limite_alunos
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

        [HttpDelete("{id}")]
        public object Delete(long id)
        {
            try
            {
                msg.success = "Removemos as informações dessa série com successo.";
                msg.fail = "Não conseguimos encontrar as informações dessa série.";

                SerieVinculo dado = Find(id);
                if (dado == null) return RespFail();

                if (dado.qtd_alunos > 0)
                {
                    msg.fail = "Não podemos deletar uma série com aluno.";
                    return RespFail();
                }

                _context.SerieVinculos.Remove(dado);
                _context.SaveChanges();

                Dados = dado;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }
    }
}
