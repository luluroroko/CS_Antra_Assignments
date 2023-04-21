using System;
using System.Data.Common;
using System.Data.SqlClient;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
	public class HRMDbContext
	{
        public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<WebAppDbContext>
        {
            public WebAppDbContext CreateDbContext(string[] args)
            {
                DbContextOptionsBuilder<WebAppDbContext> builder = new DbContextOptionsBuilder<WebAppDbContext>();
                builder.UseSqlServer("Server=localhost; Database=HRMApiDb; TrustServerCertificate=true");
                return new WebAppDbContext(builder.Options);
            }

        }
    }
}

