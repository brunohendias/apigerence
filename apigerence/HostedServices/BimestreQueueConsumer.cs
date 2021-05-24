using apigerence.Models;
using apigerence.Models.Context;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
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
