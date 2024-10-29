using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DotnetAspireExample.FunctionApp.Application;

public interface IExamService
{
    public Task GetExamsAsync(HttpClient httpClient, CancellationToken cancellationToken);
}