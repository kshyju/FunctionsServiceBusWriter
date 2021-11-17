using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Azure.Messaging.ServiceBus;

namespace ServiceBusWriterInProc
{
    public static class Function1
    {
        [FunctionName("WriteToServiceBus1")]
        [return: ServiceBus("myqueue", Connection = "MyServiceBusConn")]
        public static ServiceBusMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            ServiceBusMessage message = new ServiceBusMessage("Hello world :)")
            {
                MessageId = "my-message-id-inproc",
                Subject = "Money transfer"
            };

            return message;
        }
    }
}
