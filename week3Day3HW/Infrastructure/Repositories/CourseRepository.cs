using System;
using Dapper;
using System.Data;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
	public class CourseRepository : ICourseRepository
	{
        private readonly DapperDbContext _dbContext;

        public CourseRepository(DapperDbContext context)
        {
            _dbContext = context;
        }
        public int DeletebyId(int id)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Delete From Courses Where Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Courses> GetAll()
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Query<Courses>("Select classId, courses From Courses");
            }
        }

        public int Insert(Courses obj)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                DynamicParameters paramters = new DynamicParameters();
                return conn.Execute("Insert Into Courses Values(@classId, @courses)", obj);
            }// @ represents for local variables
        }

        public int Update(Courses obj)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Update Courses set courses = @courses Where classId = @classId)", obj);
            }
        }
    }
}

