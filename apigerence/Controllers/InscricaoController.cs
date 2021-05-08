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
    public class InscricaoController : ResponseService
    {
        private readonly MySqlContext _context;

        public InscricaoController(MySqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos as inscrições com sucesso.";
                msg.fail = "Não encontramos as inscrições.";

                var query = (
                    from inscricao in _context.Inscricoes 
                    join serie in _context.Series
                        on inscricao.cod_serie equals serie.id
                    join atencao in _context.Atencoes
                        on inscricao.cod_atencao equals atencao.id
                    join turno in _context.Turnos
                        on inscricao.cod_turno equals turno.id
                    select new {
                        inscricao,
                        serie.serie,
                        atencao.atencao,
                        turno.turno
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
                    join serie in _context.Series
                        on inscricao.cod_serie equals serie.id
                    join atencao in _context.Atencoes
                        on inscricao.cod_atencao equals atencao.id
                    join turno in _context.Turnos
                        on inscricao.cod_turno equals turno.id
                    where inscricao.id == id
                    select new
                    {
                        inscricao,
                        serie.serie,
                        atencao.atencao,
                        turno.turno
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
