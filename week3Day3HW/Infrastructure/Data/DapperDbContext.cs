using System;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Data
{
	public class DapperDbContext
	{
        IDbConnection dbConnection; // connection object we used to link current c# code to sql db
        public DapperDbContext()
        {
            //dbConnection = new SqlConnection("Data Source=.;Initial Catalog=MarchDapper2023;Integrated Security=True");
        }

        public IDbConnection GetConnection() // creating a new obj in each connection
        {
            dbConnection = new SqlConnection("Data Source=.;Initial Catalog=HW3DAY3;Integrated Security=True");
            return dbConnection;
        }
    }
}

