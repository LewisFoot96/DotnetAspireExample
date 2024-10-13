namespace DotnetAspireExample.Web;

public class ExamApiClient(HttpClient httpClient)
{
    public async Task<ExamItem[]> GetExamAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<ExamItem>? exams = null;

        await foreach (var exam in httpClient.GetFromJsonAsAsyncEnumerable<ExamItem>("/exam/lewis", cancellationToken))
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
}

public record ExamItem(string ExamName);
