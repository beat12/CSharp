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

namespace Coke_mainPage.Forms
{
    public partial class UserControl2 : UserControl
    {
        
        //Forms.UserControl5 page5 = new Forms.UserControl5();
        OracleConnection conn;
        public UserControl2()
        {
            InitializeComponent();
        }
        private void updateDataGrid()
        {
            myDataGrid.Rows.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.Font = new Font("Tahoma",15 , FontStyle.Regular);
            myDataGrid.Font =new Font("Tahoma", 15, FontStyle.Regular);



            myDataGrid.ReadOnly = true;
            myDataGrid.RowHeadersVisible = false; // 왼쪽 화살표 안보이게
            myDataGrid.AllowUserToAddRows = false; //맨 아래 로그 가리기
        

            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false; // 왼쪽 화살표 안보이게
            dataGridView1.AllowUserToAddRows = false; //맨 아래 로그 가리기


            this.Controls.Add(myDataGrid);
            myDataGrid.ColumnCount = 2;
            myDataGrid.Columns[0].Name = "재료명";
            myDataGrid.Columns[1].Name = "수량";

            this.Controls.Add(dataGridView1);
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "병 사이즈";
            dataGridView1.Columns[1].Name = "수량";

            // 오라클 연결
            Database db = new Database();
            conn = db.dbConnect();
            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT MATERIAL_NAME, MATERIAL_NUMBER FROM INVENTORY";
            cmd.CommandType = CommandType.Text;
            OracleDataReader rdr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            chart1.Series[0].Points.Clear();
            while (rdr.Read())
            {
                string material_name = rdr["MATERIAL_NAME"].ToString();
                string matrial_number = rdr["MATERIAL_NUMBER"].ToString();

                myDataGrid.Rows.Add(material_name, matrial_number);
                chart1.Series[0].Points.AddXY(material_name, Int32.Parse(matrial_number));
                myDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                myDataGrid.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            }

            cmd.CommandText = "SELECT SIZE_NAME, LEFTOVER_NUMBER FROM LEFT_LIST";
            cmd.CommandType = CommandType.Text;
            rdr = cmd.ExecuteReader();
            chart2.Series[0].Points.Clear();
            while (rdr.Read())
            {
                string size_name = rdr["SIZE_NAME"].ToString();
                string leftover_number = rdr["LEFTOVER_NUMBER"].ToString();
                chart2.Series[0].Points.AddXY(size_name, Int32.Parse(leftover_number));
                dataGridView1.Rows.Add(size_name, leftover_number);
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.updateDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {  
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            //materialOrder matorderform = new materialOrder();
            //matorderform.Show();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.updateDataGrid();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            this.updateDataGrid();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}

