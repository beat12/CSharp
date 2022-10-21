using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coke_mainPage
{
    public partial class Form1 : Form
    {
        private Socket client;
        OracleConnection conn;
        string supplier;
        string date;
        int size_500 = 0;
        int size_1000 = 0;
        string[] result;
        //Forms.UserControl1 page1 = new Forms.UserControl1();
        Forms.UserControl2 page2 = new Forms.UserControl2();
        Forms.UserControl3 page3 = new Forms.UserControl3();
        Forms.UserControl4 page4 = new Forms.UserControl4();
        Forms.UserControl5 page5 = new Forms.UserControl5();
        public Form1()
        {
            InitializeComponent();
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(page3);
            Thread serverthread = new Thread(serverFunc);
            serverthread.Start();
            serverthread.IsBackground = true;
        }
        private void serverFunc(object obj)
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                EndPoint endPoint = new IPEndPoint(IPAddress.Any, 11223);
                socket.Bind(endPoint);
                socket.Listen(10);

                client = socket.Accept();

                Thread receivethread = new Thread(receive);
                receivethread.Start();
                receivethread.IsBackground = true;
            }
        }
        private void receive()
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                int nRecv = client.Receive(bytes);

                string txt = Encoding.UTF8.GetString(bytes, 0, nRecv);
                showMsg(txt);
            }
        }

        private void showMsg(string msg)
        {
            string textBuff = msg;

            //guna2TextBox1.AppendText("\r\n");q
            //guna2TextBox1.AppendText("\r\n");

            string[] result = textBuff.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            string[] s = new string[result.Length];
            string replace;
            for (int i = 0; i < result.Length; i++)
            {
                s[i] = result[i];
                replace = s[i].Replace("개수", "\t").Replace("용량", "").Replace(":", "").Replace("업체", "\t").Replace("/", "");
                if (replace != "")
                {
                    listBox1.Items.Add(replace);
                }
            }
            //this.Activate();
            //guna2TextBox1.Focus();

            //guna2TextBox1.SelectionStart = guna2TextBox1.Text.Length;
            //guna2TextBox1.ScrollToCaret();

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Remove(page3);
            panel1.Controls.Remove(page4);
            panel1.Controls.Remove(page5);
            panel2.Visible = true;
           
           // panel1.Controls.Add(page1);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Controls.Remove(page3);
            panel1.Controls.Remove(page4);
            panel1.Controls.Remove(page5);
            //panel1.Controls.Clear();
            panel1.Controls.Add(page2);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Controls.Remove(page2);
            panel1.Controls.Remove(page4);
            panel1.Controls.Remove(page5);
            //panel1.Controls.Clear();
            panel1.Controls.Add(page3);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Controls.Remove(page2);
            panel1.Controls.Remove(page3);
            panel1.Controls.Remove(page5);
            //panel1.Controls.Clear();
            panel1.Controls.Add(page4);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            int leftover = 0;
            size_500 = 0;
            size_1000 = 0;
            string select;
            // 오라클 연결
            Database db = new Database();

            conn = db.dbConnect();
            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            if (listBox1.SelectedItem != null)
            {
                //MessageBox.Show($"....{listBox1.SelectedItem}....");
                select = listBox1.SelectedItem.ToString();
                result = select.Split(' ');




                supplier = result[7];   //업체
                date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");



                if (result[3] == "1L")
                {
                    size_1000 = Int32.Parse(result[12]);

                    cmd.CommandText = "SELECT LEFTOVER_NUMBER FROM LEFT_LIST WHERE SIZE_ID='SIZE_1000'";
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    leftover = rdr.GetInt32(0);

                    if (leftover >= size_1000)
                    {
                        cmd.CommandText = $"INSERT INTO DELIVERY_LIST VALUES (DELIVERY_SEQ.NEXTVAL,'{supplier}',TO_DATE('{date}','YYYY/MM/DD HH24:MI:SS'),{size_500},{size_1000})";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = $"UPDATE LEFT_LIST SET LEFTOVER_NUMBER=LEFTOVER_NUMBER-{size_1000} WHERE SIZE_ID='SIZE_1000'";
                        cmd.ExecuteNonQuery();
                        listBox1.Items.Remove(listBox1.SelectedItem);
                        MessageBox.Show("납품 되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("제품이 부족합니다. 제품을 생산해 주세요.");
                    }

                }
                else
                {
                    size_500 = Int32.Parse(result[12]);

                    cmd.CommandText = "SELECT LEFTOVER_NUMBER FROM LEFT_LIST WHERE SIZE_ID='SIZE_500'";
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    leftover = rdr.GetInt32(0);

                    if (leftover >= size_500)
                    {
                        cmd.CommandText = $"INSERT INTO DELIVERY_LIST VALUES (DELIVERY_SEQ.NEXTVAL,'{supplier}',TO_DATE('{date}','YYYY/MM/DD HH24:MI:SS'),{size_500},{size_1000})";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = $"UPDATE LEFT_LIST SET LEFTOVER_NUMBER=LEFTOVER_NUMBER-{size_500} WHERE SIZE_ID='SIZE_500'";
                        cmd.ExecuteNonQuery();
                        listBox1.Items.Remove(listBox1.SelectedItem);
                        MessageBox.Show("납품 되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("제품이 부족합니다. 제품을 생산해 주세요.");
                    }
                }
            }
            else
            {
                MessageBox.Show("납품할 항목을 선택해주세요.");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Form2 newform2 = new Form2();
            newform2.ShowDialog();
        }
    }
}
