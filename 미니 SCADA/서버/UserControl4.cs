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
    public partial class UserControl4 : UserControl
    {
        OracleConnection conn;
        public UserControl4()
        {
            InitializeComponent();
        }
        private void update()
        {
            dataGridView1.Rows.Clear();

            dataGridView1.Font = new Font("Tahoma", 15, FontStyle.Regular);




            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false; // 왼쪽 화살표 안보이게
            dataGridView1.AllowUserToAddRows = false; //맨 아래 로그 가리기

            this.Controls.Add(dataGridView1);
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "납품 날짜";
            dataGridView1.Columns[2].Name = "납품 업체";
            dataGridView1.Columns[3].Name = "500ML";
            dataGridView1.Columns[4].Name = "1L";

            // 오라클 연결
            Database db = new Database();
            OracleConnection conn = db.dbConnect();
            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT ID, DEL_DATE, SUPPLIER, SIZE_500, SIZE_1000 FROM DELIVERY_LIST ORDER BY ID";
            cmd.CommandType = CommandType.Text;
            OracleDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                string id = rdr["ID"].ToString();
                string del_date = rdr["DEL_DATE"].ToString();
                string supplier = rdr["SUPPLIER"].ToString();
                string size_500 = rdr["SIZE_500"].ToString();
                string size_1000 = rdr["SIZE_1000"].ToString();



                dataGridView1.Rows.Add(id, del_date, supplier, size_500, size_1000);

                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            }

            cmd.CommandText = "SELECT  SUM(SIZE_500), SUM(SIZE_1000) FROM DELIVERY_LIST";
            cmd.CommandType = CommandType.Text;
            rdr = cmd.ExecuteReader();

            rdr.Read();

            string sum_500 = rdr["SUM(SIZE_500)"].ToString();
            string sum_1000 = rdr["SUM(SIZE_1000)"].ToString();

            dataGridView1.Rows.Add("총 수량", "", "", sum_500, sum_1000);

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            int chart_500;
            int chart_1000;
            if (sum_500 == "")
            {
                chart_500=0;
            }
            else {
                chart_500 = Int32.Parse(sum_500);
            }
            if (sum_1000 == "")
            {
                chart_1000 = 0;
            }
            else
            {
                chart_1000 = Int32.Parse(sum_1000);
            }

            chart1.Titles.Clear();
            chart1.Series[0].Points.Clear();
            chart1.Titles.Add("납품량");
            chart1.Series[0].Points.AddXY("500ML", chart_500);
            chart1.Series[0].Points.AddXY("1L", chart_1000);
        }
       
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void UserControl4_Load(object sender, EventArgs e)
        {
            update();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            update();
        }
    }
}
