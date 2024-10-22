using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using System.Net.Http;
using System.Text.Json;
using DotnetAspireExample.Shared;

namespace DotnetAspireExample.Web;

public class ExamApiClient(HttpClient httpClient)
{
    public async Task<ExamDto[]> GetExamAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<ExamDto>? exams = null;

        await foreach (var exam in httpClient.GetFromJsonAsAsyncEnumerable<ExamDto>("/exam/lewis", cancellationToken))
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
        var httpResult = await httpClient.PostAsync($"/exam/", httpContent);

        if (httpResult.IsSuccessStatusCode)
        {
            var result = (await JsonSerializer.DeserializeAsync<ExamDto>(
                await httpResult.Content.ReadAsStreamAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = false,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }))!;
        }
    }
}
