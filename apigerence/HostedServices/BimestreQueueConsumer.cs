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
    public class BimestreQueueConsumer : IHostedService
    {
        private readonly Queue _queue;

        public BimestreQueueConsumer(IConfiguration config)
        {
            _queue = new Queue(config, "bimestre");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("  Fila iniciada  ");
            ProcessMessageHandler();
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("  Fila finalizada  ");
            await _queue._queueClient.CloseAsync();
            await Task.CompletedTask;
        }

        private void ProcessMessageHandler()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _queue._queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            Bimestre request = JsonSerializer.Deserialize<Bimestre>(message.Body);

            // Dar sequencia com os dados recebidos da fila na variavel request
            using (var conn = new MySqlConnection(_queue._builder))
            {
                Console.WriteLine("Opening connection");
                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {
                    //@"INSERT INTO inventory (name, quantity) VALUES (@name1, @quantity1),(@name2, @quantity2), (@name3, @quantity3);";
                    command.CommandText = @"INSERT INTO bimestre (bimestre) VALUES (@name);";
                    command.Parameters.AddWithValue("@name", request.bimestre);

                    Console.WriteLine("Executando o sql... ");
                    await command.ExecuteNonQueryAsync();
                }
            }

            await _queue._queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            var error = exceptionReceivedEventArgs.Exception.Message;
            Console.WriteLine($" error: {error} ");
            return Task.CompletedTask;
        }
    }
}
