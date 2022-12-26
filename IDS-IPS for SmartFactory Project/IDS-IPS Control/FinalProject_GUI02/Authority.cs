using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_GUI02
{
    public class Authority
    {
        public static OracleDataAdapter CreateAdapter(OracleConnection conn)
        {
            OracleDataAdapter adapter = new OracleDataAdapter();
            OracleCommand cmd;
     

            string sql1 = "select * from create_User";
            cmd = new OracleCommand(sql1);

            



            return adapter;
        }
    }
}
