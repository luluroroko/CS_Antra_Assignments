using System;
using System.Data;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Dapper;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
	public class StudentRepository : IStudentRepository
    {
        private readonly DapperDbContext _dbContext;

        public StudentRepository()
        {
            _dbContext = new DapperDbContext();
        }

        public int Insert(Students obj)
        {
            using IDbConnection conn = _dbContext.GetConnection();
            DynamicParameters paramters = new DynamicParameters();
            return conn.Execute("Insert Into Students Values(@FirstName, @LastName, @Grade, @courses)", obj);
        }

        public int Update(Students obj)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Update Students set FirstName = @FirstName,LastName = @LastName, Grade = @Grade, courses = @courses Where Id = @Id)", obj);
            }
        }

        public int DeletebyId(int id)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Delete From Students Where Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Students> GetAll()
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Query<Students>("Select Id, FirstName, LastName, Grade, courses From Students");
            }
        }
	}
}
