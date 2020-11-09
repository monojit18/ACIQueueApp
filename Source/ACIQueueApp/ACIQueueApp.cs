using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ACIQueueApp
{
    public static class ACIQueueApp
    {
        [FunctionName("ACIQueueApp")]
        public static void Run([QueueTrigger("aciimagequeue", Connection = "AzureWebJobsStorage")]
                                string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
