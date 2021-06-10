using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace apigerence.Models
{
    public class Queue
    {
        private readonly static string key = "AzureServiceBus";
        private readonly static string DBConnectionKey = "Connections:MySql";
        
        public readonly IQueueClient Client;
        public readonly MessageHandlerOptions HandlerOptions;
        public readonly string DBBuilder;

        public Queue(IConfiguration config, string name)
        {
            DBBuilder = config.GetValue<string>(DBConnectionKey);

            string connection = config.GetValue<string>(key);

            Client = new QueueClient(connection, name);

            HandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };
        }

        public async Task Send(object request)
        {
            string messageBody = JsonSerializer.Serialize(request);
            Message message = new (Encoding.UTF8.GetBytes(messageBody));

            await Client.SendAsync(message);
            await Client.CloseAsync();
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            var error = exceptionReceivedEventArgs.Exception.Message;
            Console.WriteLine($" error: {error} ");
            return Task.CompletedTask;
        }
    }
}
