//using FinalProject_GUI02.DB;
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
    public partial class Login : Form
    {
        string login_ID;
        string login_author;
        string strConn = "Data Source=(DESCRIPTION=" +
                  "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                  "(HOST=localhost)(PORT=1521)))" +
                  "(CONNECT_DATA=(SERVER=DEDICATED)" +
                  "(SERVICE_NAME=xe)));" +
                  "User Id=hr ;Password=hr;";

        OracleDataReader rdr;
        OracleConnection conn;
        OracleCommand cmd;
       
        
       

        public Login()
        {
            InitializeComponent();
            conn = new OracleConnection(strConn);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;


        }

        //bool TagMove;
        dashBoard dash;
        CreateUser create;

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txt_PW.Text =="" || txt_ID.Text =="")
            {
                label4.Text = "아이디/비밀번호를 입력하세요.";

            }
            else {
                cmd.CommandText = $"select PASSWORD from login_User where ID = '{txt_ID.Text}'";
                rdr = cmd.ExecuteReader();              
                
                string password = "";

                while (rdr.Read())
                {
                    password = rdr["PASSWORD"].ToString();
                }

                if (txt_PW.Text == password)
                {
                    
                    cmd.CommandText = $"select * from login_User where ID = '{txt_ID.Text}'";
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        login_ID = rdr["ID"].ToString();
                        login_author = rdr["authority"].ToString();
                    }


                    this.Hide();
                    //create.Hide();
                    MessageBox.Show($"{login_author}권한으로 로그인 성공. 메인화면으로 갑니다.");
                    
                    dash = new dashBoard();
                    dash.login_id = login_ID;
                    dash.login_author = login_author;
                    conn.Close();
                    dash.Show();
                }
                else
                {
                    label4.Text = "아이디/비밀번호가 틀립니다.";
                }
                
                
            }
           
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            create = new CreateUser();
            create.Show();
        }
    }
}
