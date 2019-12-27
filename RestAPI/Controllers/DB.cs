using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace RestAPI.Controllers
{
    public class DB
    {
        private String  connectionString= "Data Source=DESKTOP-3AI36LO\\MSSQLSERVERD;Initial Catalog=mas_isscs;Integrated Security=True";

        public SqlConnection DBConnection()
        {
            SqlConnection mySqlConn = new SqlConnection(connectionString);
            return mySqlConn;
        }


    }
}