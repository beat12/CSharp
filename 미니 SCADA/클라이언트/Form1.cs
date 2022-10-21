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

namespace MINIPROJECT
{
    public partial class Form1 : Form
    {
        Socket socket;


        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, 11223);

            socket.Connect(endpoint);

            
        }

        
        private void showMsg(string msg)
        {
            textBox1.AppendText($"{msg}\r\n");
            textBox1.AppendText("\r\n");

            //this.Activate();
            //textBox1.Focus();
            //textBox1.SelectionStart = textBox1.Text.Length;
            //textBox1.ScrollToCaret();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex != -1)
                {
                    if(MessageBox.Show($"선택하신 품목이\r\n{listBox1.SelectedItem.ToString()}\r\n\r\n맞으십니까?", "주문 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(listBox1.SelectedItem.ToString());
                        socket.Send(bytes);
                        showMsg(listBox1.SelectedItem.ToString());

                        MessageBox.Show($"{listBox1.SelectedItem.ToString()}\r\n\r\n주문 완료되었습니다.", "주문 완료");
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    MessageBox.Show("물건이 선택되지 않았습니다.", "주문 실패");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("서버 상태가 불안정합니다.", "주문 실패");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("용량 : " + guna2ComboBox1.SelectedItem + " / 업체 : "
                + guna2ComboBox2.SelectedItem + " / 개수 : " + textBox2.Text);

            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);

            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                if (listBox1.SelectedIndex != -1)
                {
                    foreach (var input_items in listBox1.Items)
                    {
                        result += string.Format("{0}\r\n", input_items);
                    }
                    if (MessageBox.Show($"선택하신 품목이\r\n{result}\r\n맞으십니까?", "주문 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(result);
                        socket.Send(bytes);
                        showMsg(result);
                        MessageBox.Show($"{result}\r\n주문 완료되었습니다.", "주문 완료");
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("물건이 추가되지 않았거나 물건이 없습니다.", "주문 실패");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("서버 상태가 불안정합니다.", "주문 실패");
            }
        }
    }
}