using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace Data.Database
{
    public class Adapter
    {
     
        public SqlConnection sqlConn { get; set; }
        const string cnnStrDefault = "ConectionStringExpress";

        protected void OpenConnection()
        {
            string connstr= ConfigurationManager.ConnectionStrings[cnnStrDefault].ConnectionString;
            sqlConn = new SqlConnection(connstr);
            //sqlConn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Academia;Integrated Security=True");
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
