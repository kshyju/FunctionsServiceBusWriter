using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ServiceBusWriterOOP
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("WriteToServiceBus")]
        [ServiceBusOutput("myqueue", Connection = "MyServiceBusConn")]
        public ServiceBusMessage Run2([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("WriteToServiceBus2 http endpoint is writing a record to SBUS using ServiceBusMessage");

            ServiceBusMessage message = new ServiceBusMessage("Hello world :)")
            {
                MessageId = "my-message-id-oop",
                Subject = "Money transfer"
            };

            return message;
        }
    }
}
