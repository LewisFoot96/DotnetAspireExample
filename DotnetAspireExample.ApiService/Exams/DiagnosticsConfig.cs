using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace DotnetAspireExample.ApiService.Exams
{
    public static class DiagnosticsConfig
    {
        public const string ServiceName = "ExamApi";
        public static readonly ActivitySource ActivitySource = new("ExamSource");

        public static Meter Meter = new(ServiceName);

        public static Counter<int> SalesCounter = Meter.CreateCounter<int>("exams.count");

    }
}
