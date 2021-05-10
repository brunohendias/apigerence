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
    public class DadosSerieController : ResponseService
    {
        private readonly MySqlContext _context;
        public DadosSerieController(MySqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos as informações das séries com successo.";
                msg.fail = "Não encontramos as informações das séries.";

                var query = (
                    from dados in _context.SerieVinculos 
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
                        dados,
                        serie.serie,
                        turno.turno,
                        turma.turma,
                        professor.nom_prof
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

        [HttpPost]
        public object Post(SerieVinculo request)
        {
            try
            {
                msg.success = "Cadastramos as informações dessa série com successo.";
                msg.fail = "Não conseguimos cadastrar as informações dessa série.";

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

                SerieVinculo dado = _context.SerieVinculos.Find(id);
                Dados = dado;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpPut]
        public object Put(SerieVinculo request)
        {
            try
            {
                msg.success = "Editamos as informações dessa série com successo.";
                msg.fail = "Não conseguimos encontrar as informações dessa série.";

                SerieVinculo dado = _context.SerieVinculos.Find(request.id);
                if (dado == null) return RespFail();

                SerieVinculo dados = new()
                {
                    id = request.id,
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

                SerieVinculo dado = _context.SerieVinculos.Find(id);
                if (dado == null) return RespFail();

                msg.fail = "Não podemos deletar uma série com aluno.";
                if (dado.qtd_alunos > 0) return RespFail();

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
