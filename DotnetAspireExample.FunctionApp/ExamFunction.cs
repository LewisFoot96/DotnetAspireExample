using System;
using System.Net.Http;
using System.Threading;
using DotnetAspireExample.FunctionApp.Application;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace DotnetAspireExample.FunctionApp
{
    public class ExamFunction(IExamService examService, HttpClient httpClient)
    {
        [FunctionName("ExamFunction")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            examService.GetExamsAsync(httpClient, new CancellationToken());
        }
    }
}