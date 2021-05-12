using apigerence.Models.Context;
using apigerence.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace apigerence.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InscricaoController : ResponseService
    {
        public InscricaoController(MySqlContext context) : base(context) { }

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos as inscrições com sucesso.";
                msg.fail = "Não encontramos as inscrições.";

                var query = (
                    from inscricao in _context.Inscricoes
                    select new {
                        inscricao,
                        inscricao.Serie.serie,
                        inscricao.Atencao.atencao,
                        inscricao.Turno.turno
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

        [HttpGet("{id}")]
        public object FindById(long id)
        {
            try
            {
                msg.success = "Buscamos essa inscrição com sucesso.";
                msg.fail = "Não encontramos essa inscrição.";

                var query = (
                    from inscricao in _context.Inscricoes
                    where inscricao.cod_insc == id
                    select new {
                        inscricao,
                        inscricao.Serie.serie,
                        inscricao.Atencao.atencao,
                        inscricao.Turno.turno
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
