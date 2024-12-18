﻿using DotnetAspireExample.Shared;
using MediatR;

namespace DotnetAspireExample.ApiService.Exams.Application.Exams.Queries
{
    public record GetExamsQuery : IRequest<List<ExamDto>>;
}
