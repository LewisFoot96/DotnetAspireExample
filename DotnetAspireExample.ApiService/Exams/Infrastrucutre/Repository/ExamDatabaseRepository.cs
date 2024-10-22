using Dapper;
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
            string sqlString = $"INSERT into Exams (ExamId, ExamName) VALUES ('{Guid.NewGuid()}', '{exam.ExamName}')";

            try
            {
                await Client.OpenAsync();
                var rowsAffected = await Client.ExecuteAsync(sqlString, exam);
                await Client.CloseAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


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

        public async Task<Exam> GetAsync(string name)
        {
            var exams = new List<Exam>();

            var sqlStatement = "SELECT * FROM Exams";

            try
            {
                await Client.OpenAsync();
                exams = Client.Query<Exam>(sqlStatement).ToList();
                await Client.CloseAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new Exam
            {
                ExamName = "Lewis"
            };
        }
    }
}
