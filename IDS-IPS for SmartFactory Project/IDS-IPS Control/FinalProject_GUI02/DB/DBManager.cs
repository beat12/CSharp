using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
namespace FinalProject_GUI02.DB
{
    public class DBManager
    {
        /// <summary>
        /// 추후 코드 보완 예정
        /// </summary>
        public string strConn;
        private OracleConnection conn;
        private string ip = "localhost";
        private string port = "1521";
        private string id = "hr";
        private string pwd = "hr";

        public DBManager()
        {
            //starConn = "";

                strConn = "Data Source=(DESCRIPTION=" +
                   "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                   "(HOST=" + ip + ")(PORT=" + port + ")))" +
                   "(CONNECT_DATA=(SERVER=DEDICATED)" +
                   "(SERVICE_NAME=xe)));" +
                   $"User Id= '{id}' ;Password='{pwd}';";
                conn = new OracleConnection(strConn);
                this.Open(conn);

        }

        private void Open(OracleConnection con)
        {
            this.conn = con;
        }

    }
}
