namespace DotnetAspireExample.ApiService.Exams.Domain
{
    public class Exam :IAggregationRoot
    {
        public Guid ExamId { get;init; }

        public required string ExamName { get; init; }

        public int MaxMark { get; private set; }

        public void SetMarks(int maxMark)
        {
            MaxMark = maxMark;
        }
    }
}
