using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace apigerence.Models
{
    public class Queue
    {
        private readonly IConfiguration _config;
        private readonly static string _key = "AzureServiceBus";
        public readonly string _connection;
        public readonly string _queueName;
        public IQueueClient _queueClient;

        public Queue(IConfiguration config, string queueName)
        {
            _config = config;
            _connection = _config.GetValue<string>(_key);
            _queueName = queueName;
            _queueClient = new QueueClient(_connection, _queueName);
        }
    }
}
