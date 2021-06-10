using apigerence.Models;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MySqlConnector;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace apigerence.HostedServices
{
    public class BemestreQueueConsumer : IHostedService
    {
        private readonly Queue _queue;

        public BemestreQueueConsumer(IConfiguration config) =>
            _queue = new Queue(config, "bimestre");

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("  Fila iniciada  ");
            ProcessMessageHandler();
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("  Fila finalizada  ");
            await _queue.Client.CloseAsync();
            await Task.CompletedTask;
        }

        private void ProcessMessageHandler() =>
            _queue.Client.RegisterMessageHandler(Handler, _queue.HandlerOptions);

        private async Task Handler(Message message, CancellationToken token)
        {
            Bimestre request = JsonSerializer.Deserialize<Bimestre>(message.Body);

            // Dar sequencia com os dados recebidos da fila na variavel request
            using (var conn = new MySqlConnection(_queue.DBBuilder))
            {
                Console.WriteLine("Opening connection");
                await conn.OpenAsync(token);

                using (var command = conn.CreateCommand())
                {
                    //@"INSERT INTO inventory (name, quantity) VALUES (@name1, @quantity1),(@name2, @quantity2), (@name3, @quantity3);";
                    command.CommandText = @"INSERT INTO bimestre (bimestre) VALUES (@name);";
                    command.Parameters.AddWithValue("@name", request.bimestre);

                    Console.WriteLine("Executando o sql... ");
                    await command.ExecuteNonQueryAsync();
                }
            }

            await _queue.Client.CompleteAsync(message.SystemProperties.LockToken);
        }
    }
}
