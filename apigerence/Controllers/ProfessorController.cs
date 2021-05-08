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
    public class ProfessorController : ResponseService
    {
        private readonly MySqlContext _context;

        public ProfessorController(MySqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos os professores com sucesso.";
                msg.fail = "Não encontramos os professores.";

                List<Professor> query = (from professor in _context.Professores select professor).ToList();

                if (query.Count > 0) Dados = query;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpPost]
        public object Post(Professor request)
        {
            try
            {
                msg.success = "Cadastramos esse professor com sucesso.";
                msg.fail = "Não conseguimos cadastrar esse professor.";

                _context.Professores.Add(request);
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
                msg.success = "Removemos esse professor com sucesso.";
                msg.fail = "Não encontramos esse professor.";

                Professor request = _context.Professores.Find(id);
                if (request == null) return RespFail();

                int vinculo = _context.SerieVinculos.Where(vserie => vserie.cod_prof == id).Count();
                if (vinculo > 0)
                {
                    msg.fail = "Não podemos remover um professor que esta sendo utilizada.";
                    return RespFail();
                }

                _context.Professores.Remove(request);
                _context.SaveChanges();

                Dados = request;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }
    }
}
