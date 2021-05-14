﻿using apigerence.Models;
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
    public class AtencaoController : ResponseService
    {
        public AtencaoController(MySqlContext context) : base(context) { }

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos as atenções com sucesso.";
                msg.fail = "Não encontramos as atenções.";

                List<Atencao> query = (from atencao in _context.Atencoes select atencao).ToList();

                if (query.Count > 0) Dados = query;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpGet("inscricoes")]
        public object InscricoesPorAtencao()
        {
            try
            {
                msg.success = "Buscamos as inscrições com essas atenções com sucesso.";
                msg.fail = "Não encontramos as inscrições com essas atenções.";

                long[] atencoes = new long[] { 1, 3, 5 };

                var query = (from atencao in _context.Atencoes
                             where atencoes.Contains(atencao.cod_atencao)
                             select new
                             {
                                 atencao,
                                 inscricoes = (from insc in _context.Inscricoes
                                               where insc.cod_atencao == atencao.cod_atencao
                                               select new
                                               {
                                                   insc.cod_insc,
                                                   insc.nome
                                               }).ToList()
                             }).ToList();

                if (query.Count > 0) Dados = query;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        [HttpPost]
        public object Post([FromBody] Atencao request)
        {
            try
            {
                msg.success = "Cadastramos essa turma com sucesso.";
                msg.fail = "Não conseguimos cadastrar essa turma.";

                _context.Atencoes.Add(request);
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
                msg.success = "Removemos essa turma com sucesso.";
                msg.fail = "Não encontramos essa turma.";

                Atencao request = _context.Atencoes.Find(id);
                if (request == null) return RespFail();

                _context.Atencoes.Remove(request);
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
