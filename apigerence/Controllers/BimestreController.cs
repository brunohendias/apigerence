using apigerence.Models;
using apigerence.Models.Context;
using apigerence.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace apigerence.Controllers
{
    [ApiController, Route("api/v1/[controller]")]
    public class BimestreController : ResponseService
    {
        private readonly Queue queue;

        public BimestreController(MySqlContext context, IConfiguration config) : base(context)
        {
            queue = new Queue(config, "bimestre");
        }

        [HttpGet]
        public object Get()
        {
            try
            {
                msg.success = "Buscamos os bimestres com sucesso.";
                msg.fail = "Não conseguimos encontrar os bimestres.";

                var query = (
                        from bimestre in _context.Bimestres select bimestre
                    ).ToList();

                if (query.Count > 0) Dados = query;

                return MontaRetorno();
            }
            catch (Exception e)
            {
                return RespErrorLog(e);
            }
        }

        private async Task SendMessageQueue(Bimestre request)
        {
            var client = new QueueClient(queue._connection, queue._queueName, ReceiveMode.PeekLock);
            string messageBody = JsonSerializer.Serialize(request);
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            await client.SendAsync(message);
            await client.CloseAsync();
        }

        [HttpPost]
        public async Task<object> Post(Bimestre request)
        {
            try
            {
                msg.success = "Cadastramos esse bimestre com sucesso.";
                msg.fail = "Não conseguimos cadastrar esse bimestre.";

                await SendMessageQueue(request);

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
