using DotnetAspireExample.ApiService.Exams.Domain;

namespace DotnetAspireExample.ApiService.Exams.Application.Exams.Repository
{
    public interface IRepository<T> where T : IAggregationRoot
    {
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken);

        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);

        void DeleteAsync(CancellationToken cancellationToken);

        Task<T> GetAsync(string name);

    }
}
