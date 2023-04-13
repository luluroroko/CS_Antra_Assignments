using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            dbConnection = new SqlConnection("Data Source=.;Initial Catalog=MarchDapper2023;Integrated Security=True");
            return dbConnection;
        }
    }
}
