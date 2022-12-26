using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_GUI02
{
    public partial class CreateUser : Form
    {


        OracleConnection conn;
        OracleCommand cmd;
        OracleDataReader rdr;
        string strConn = "Data Source=(DESCRIPTION=" +
               "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
               "(HOST=localhost)(PORT=1521)))" +
               "(CONNECT_DATA=(SERVER=DEDICATED)" +
               "(SERVICE_NAME=xe)));" +
               "User Id=hr;Password=hr;";

        Login login_form;
        public CreateUser()
        {
            InitializeComponent();
            conn = new OracleConnection(strConn);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(txt_ID.Text == ""|| txt_Name.Text == "" || txt_Number.Text == "" || txt_PW.Text =="")
            {
                MessageBox.Show("빈칸에 공백이 존재합니다. 모든 항목을 작성해 주십시오.");
            }
            else
            {
                cmd.CommandText = $"insert into create_User values('{txt_ID.Text}','{txt_PW.Text}','{txt_Name.Text}','{txt_Number.Text}','-','X')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "commit";
                cmd.ExecuteNonQuery();
                MessageBox.Show("아이디가 생성되었습니다.");
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            login_form = new Login();
            login_form.Show();
        }

       
    }
}
