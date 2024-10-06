using DotnetAspireExample.ApiService.Exams.Application.Exams.Repository;
using DotnetAspireExample.ApiService.Exams.Domain;
using Microsoft.Data.SqlClient;

namespace DotnetAspireExample.ApiService.Exams.Repository
{
    public class ExamDatabaseRepository : IRepository<Exam>
    {
        public SqlConnection Client { get; }

        public ExamDatabaseRepository(SqlConnection client)
        {
            Client = client;
        }

        public async Task<Exam> CreateAsync(Exam exam, CancellationToken cancellationToken)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT Exam (ExamId, ExamName) VALUES (1, 'LewisTest')";
            cmd.Connection = Client;

            await Client.OpenAsync();
            cmd.ExecuteNonQuery();
            await Client.CloseAsync();

            return new Exam
            {
                ExamName = "Lewis"
            };
        }

        public void DeleteAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<Exam> UpdateAsync(Exam exam, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Exam> GetAsync(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT Exam (ExamId, ExamName) VALUES (1, 'LewisTest')";
            cmd.Connection = Client;

            return new Task<Exam>(() => new Exam
            {
                ExamName = "Lewis"
            });
        }
    }
}
