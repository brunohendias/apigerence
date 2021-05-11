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
    public class TurnoController : ResponseService
    {
        private readonly MySqlContext _context;

        public TurnoController(MySqlContext context) => _context = context;

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos os turnos com sucesso.";
                msg.fail = "Não encontramos os turnos.";

                List<Turno> query = (from turno in _context.Turnos select turno).ToList();

                if (query.Count > 0) Dados = query;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpPost]
        public object Post([FromBody] Turno request)
        {
            try
            {
                msg.success = "Cadastramos esse turno com sucesso.";
                msg.fail = "Não conseguimos cadastrar esse turno.";

                _context.Turnos.Add(request);
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
                msg.success = "Removemos esse turno com sucesso.";
                msg.fail = "Não encontramos esse turno.";

                Turno request = _context.Turnos.Find(id);
                if (request == null) return RespFail();

                int vinculo = _context.SerieVinculos.Where(vserie => vserie.cod_turno == id).Count();
                if (vinculo > 0)
                {
                    msg.fail = "Não podemos remover um turno que esta sendo utilizado.";
                    return RespFail();
                }
                
                _context.Turnos.Remove(request);
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
