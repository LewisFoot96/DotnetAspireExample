using System.Diagnostics;
using System.Text.Json;
using DotnetAspireExample.Shared;

namespace DotnetAspireExample.Web;

public class ExamApiClient(HttpClient httpClient, ILogger<ExamApiClient> logger)
{
    private static readonly ActivitySource RegisteredActivity = new ("Examples.ManualInstrumentations.Registered");
    
    public async Task<ExamDto[]> GetExamAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        using (var activity = RegisteredActivity.StartActivity("Main"))
        {
            activity?.SetTag("foo", "bar1");
            // your logic for Main activity
        }
        List<ExamDto>? exams = null;

        await foreach (var exam in httpClient.GetFromJsonAsAsyncEnumerable<ExamDto>("/exam", cancellationToken))
        {
            if (exams?.Count >= maxItems)
            {
                break;
            }

            if (exam is not null)
            {
                exams ??= [];
                exams.Add(exam);
            }
        }

        logger.LogInformation("Received {Count} exams", exams?.Count ?? 0);
        logger.LogError("Test error");
        return exams?.ToArray() ?? [];
    }

    public async Task CreateExamAsync(ExamDto examItem, CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(examItem);

        var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        await httpClient.PostAsync("/exam/", httpContent, cancellationToken);
    }
}