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
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BimestreController : ResponseService
    {
        private readonly IConfiguration _config;
        private readonly string connectionString;
        private readonly string queueName = "bimestre";

        public BimestreController(MySqlContext context, IConfiguration config) : base(context) 
        {
            _config = config;
            connectionString = _config.GetValue<string>("AzureServiceBus");
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

        private void SendMessageQueue(Bimestre request)
        {
            QueueClient client = new(connectionString, queueName, ReceiveMode.PeekLock);
            string messageBody = JsonSerializer.Serialize(request);
            Message message = new(Encoding.UTF8.GetBytes(messageBody));

            client.SendAsync(message);
            client.CloseAsync();
        }

        [HttpPost]
        public object Post(Bimestre request)
        {
            try
            {
                msg.success = "Cadastramos esse bimestre com sucesso.";
                msg.fail = "Não conseguimos cadastrar esse bimestre.";

                SendMessageQueue(request);

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
