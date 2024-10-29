using System.Text.Json;
using DotnetAspireExample.Shared;

namespace DotnetAspireExample.Web;

public class ExamApiClient(HttpClient httpClient)
{
    public async Task<ExamDto[]> GetExamAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
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

        return exams?.ToArray() ?? [];
    }

    public async Task CreateExamAsync(ExamDto examItem, CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(examItem);

        var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        await httpClient.PostAsync("/exam/", httpContent, cancellationToken);
    }
}