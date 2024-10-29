using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using DotnetAspireExample.Shared;

namespace DotnetAspireExample.FunctionApp.Application;

public class ExamService : IExamService
{
    public async Task GetExamsAsync(HttpClient httpClient, CancellationToken cancellationToken)
    {
        List<ExamDto> exams = null;

        await foreach (var exam in httpClient.GetFromJsonAsAsyncEnumerable<ExamDto>("/exam", cancellationToken))
        {
            if (exams?.Count >= 10)
            {
                break;
            }

            if (exam is not null)
            {
                exams ??= [];
                exams.Add(exam);
            }
        }
    }
}