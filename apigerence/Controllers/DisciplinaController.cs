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

                Dados = query;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpPost]
        public object Post(Disciplina request)
        {
            try
            {
                msg.success = "Cadastramos essa disciplina com sucesso.";
                msg.fail = "Não conseguimos cadastrar essa disciplina.";

                Disciplina dados = new()
                {
                    disciplina = request.disciplina
                };

                _context.Disciplinas.Add(dados);
                _context.SaveChanges();

                Dados = dados;

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
        public object Put(Disciplina request)
        {
            try
            {
                msg.success = "Editamos essa disciplina com sucesso.";
                msg.fail = "Não conseguimos editar essa disciplina.";

                Disciplina dado = Find(request.id);
                if (dado == null)
                {
                    msg.fail = "Não conseguimos encontrar essa disciplina.";
                    return RespFail();
                }

                Disciplina dados = new()
                {
                    id = request.id,
                    disciplina = request.disciplina
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
                } else
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