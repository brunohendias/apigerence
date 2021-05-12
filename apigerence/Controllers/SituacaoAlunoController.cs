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
    public class SituacaoAlunoController : ResponseService
    {
        private readonly MySqlContext _context;

        public SituacaoAlunoController(MySqlContext context) => _context = context;

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos as situações com sucesso.";
                msg.fail = "Não encontramos as situações.";

                List<SituacaoAluno> query = (from situacao in _context.SituacaoAlunos select situacao).ToList();

                if (query.Count > 0) Dados = query;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpPost]
        public object Post([FromBody] SituacaoAluno request)
        {
            try
            {
                msg.success = "Cadastramos essa situação com sucesso.";
                msg.fail = "Não conseguimos cadastrar essa situação.";

                _context.SituacaoAlunos.Add(request);
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
                msg.success = "Removemos essa situação com sucesso.";
                msg.fail = "Não encontramos essa situação.";

                SituacaoAluno request = _context.SituacaoAlunos.Find(id);
                if (request == null) return RespFail();

                int vinculo = _context.Alunos.Where(aluno => aluno.cod_situacao == id).Count();
                if (vinculo > 0)
                {
                    msg.fail = "Não podemos remover essa situação que esta sendo utilizada.";
                    return RespFail();
                }

                _context.SituacaoAlunos.Remove(request);
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
