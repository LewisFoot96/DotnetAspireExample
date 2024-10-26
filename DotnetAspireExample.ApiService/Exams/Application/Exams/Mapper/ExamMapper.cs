using DotnetAspireExample.ApiService.Exams.Domain;
using DotnetAspireExample.Shared;

namespace DotnetAspireExample.ApiService.Exams.Application.Exams.Mapper;

public static class ExamMapper
{
    public static ExamDto ToExamDto(this Exam exam)
    {
        return new ExamDto(exam.ExamName, exam.MaxMark);
    }
    
    public static Exam ToExam(this ExamDto examDto)
    {
        return new Exam
        {
            ExamName = examDto.ExamName,
        };
    }
}