﻿using Dapper;
using DotnetAspireExample.ApiService.Exams.Application.Exams.Repository;
using DotnetAspireExample.ApiService.Exams.Domain;
using DotnetAspireExample.Shared;
using Microsoft.Data.SqlClient;

namespace DotnetAspireExample.ApiService.Exams.Infrastrucutre.Repository
{
    public class ExamDatabaseRepository(SqlConnection client) : IRepository<Exam>
    {
        public SqlConnection Client { get; } = client;

        public async Task<Exam> CreateAsync(Exam exam, CancellationToken cancellationToken)
        {
            string sqlString = $"INSERT into Exams (ExamId, ExamName) VALUES ('{Guid.NewGuid()}', '{exam.ExamName}')";

            try
            {
                await Client.OpenAsync(cancellationToken);
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
        public async Task<List<Exam>> GetAllAsync()
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

            return exams;
        }

        public Task<Exam> GetAsync(ExamDto exam)
        {
            throw new NotImplementedException();
        }

        public Task<Exam> UpdateAsync(Exam exam, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
