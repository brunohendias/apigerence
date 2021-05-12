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
    public class DisciplinaController : ResponseService
    {
        private readonly MySqlContext _context;
        public DisciplinaController(MySqlContext context) => _context = context;

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos as disciplinas com sucesso.";
                msg.fail = "Não conseguimos encontrar as disciplinas.";

                var query = (
                        from disciplina in _context.Disciplinas
                        select disciplina
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
        public object Post([FromBody] Disciplina request)
        {
            try
            {
                msg.success = "Cadastramos essa disciplina com sucesso.";
                msg.fail = "Não conseguimos cadastrar essa disciplina.";

                _context.Disciplinas.Add(request);
                _context.SaveChanges();

                Dados = request;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        private Disciplina Find(long id) => _context.Disciplinas.Find(id);

        private SerieDisciplina Serie(long id) =>
            ( from serie in _context.SerieDisciplinas where serie.cod_disciplina == id select serie ).FirstOrDefault();

        [HttpPut]
        public object Put([FromBody] Disciplina request)
        {
            try
            {
                msg.success = "Editamos essa disciplina com sucesso.";
                msg.fail = "Não conseguimos editar essa disciplina.";

                Disciplina dado = Find(request.cod_disciplina);
                if (dado == null)
                {
                    msg.fail = "Não conseguimos encontrar essa disciplina.";
                    return RespFail();
                }

                _context.Entry(dado).CurrentValues.SetValues(request);
                _context.SaveChanges();

                Dados = request;

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
                msg.success = "Removemos essa disciplina com sucesso.";
                msg.fail = "Não conseguimos remover essa disciplina.";

                Disciplina dado = Find(id);
                if (dado == null)
                {
                    msg.fail = "Não conseguimos encontrar essa disciplina.";
                    return RespFail();
                }

                SerieDisciplina serie = Serie(id);
                if (serie == null)
                {
                    _context.Disciplinas.Remove(dado);
                    _context.SaveChanges();

                    Dados = dado;
                } 
                else
                {
                    msg.fail = "Não podemos remover uma disciplina que está cadastrada em uma série.";
                    return RespFail();
                }

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }
    }
}