using apigerence.Models.Context;
using apigerence.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace apigerence.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BimestreController : ResponseService
    {
        public BimestreController(MySqlContext context) : base(context) { }

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos os bimestres com sucesso.";
                msg.fail = "Não conseguimos encontrar os bimestres.";

                var query = (
                        from bimestre in _context.Bimestres
                        select bimestre
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
