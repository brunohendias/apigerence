﻿using apigerence.Models;
using apigerence.Models.Context;
using apigerence.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace apigerence.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SerieController : ResponseService
    {
        private readonly MySqlContext _context;

        public SerieController(MySqlContext context) => _context = context;

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos as séries com successo.";
                msg.fail = "Não encontramos as séries.";

                var query = ( from serie in _context.Series select serie ).ToList();

                Dados = query.Count == 0 ? null : query;

                return MontaRetorno();
            }
            catch(Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpPost]
        public object Post([FromBody] Serie request)
        {
            try
            {
                msg.success = "Cadastramos essa série com successo.";
                msg.fail = "Não conseguimos cadastrar essa série.";

                Serie dados = new()
                {
                    serie = request.serie
                };

                _context.Series.Add(dados);
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
                msg.success = "Buscamos essa série com successo.";
                msg.fail = "Não conseguimos encontrar essa série.";

                Serie dado = _context.Series.Find(id);
                Dados = dado;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpPut]
        public object Put([FromBody] Serie request)
        {
            try
            {
                msg.success = "Editamos essa série com successo.";
                msg.fail = "Não conseguimos encontrar essa série.";

                Serie dado = _context.Series.Find(request.id);
                if (dado == null) return RespFail();

                Serie dados = new()
                {
                    id = request.id,
                    serie = request.serie
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
                msg.success = "Removemos essa série com successo.";
                msg.fail = "Não encontramos essa série.";

                Serie dado = _context.Series.Find(id);
                if (dado == null) return RespFail();

                int vinculo = _context.SerieVinculos.Where(serie => serie.id == id).Count();
                if (vinculo > 0)
                {
                    msg.fail = "Não podemos remover uma série que esta sendo utilizada.";
                    return RespFail();
                }

                _context.Series.Remove(dado);
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
