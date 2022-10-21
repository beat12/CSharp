using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coke_mainPage
{
    internal class Database
    {
        string strConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
               "(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));" +
               "User Id=hr;Password=hr;";
        public Database()
        {

        }
        public OracleConnection dbConnect()
        {
            OracleConnection conn = new OracleConnection(strConn);
            conn.Open();

            return conn;
        }
        public void dbClose(OracleConnection conn)
        {
            if (conn != null)
            {
                try
                {
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
