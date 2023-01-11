using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Serial
{
    public partial class Form1 : Form
    {
        SerialPort sp = new SerialPort();
        char stx = Convert.ToChar(0x02);
        char etx = Convert.ToChar(0x03);
        bool button_checked = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!sp.IsOpen)
            {
                sp.PortName = comboBox_port.Text;
                sp.BaudRate = int.Parse(comboBox_baudrate.Text);
                sp.DataBits = int.Parse(textBox_databits.Text);
                sp.StopBits = (StopBits)comboBox_stop.SelectedItem;
                sp.Parity = Parity.None;
                sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataRecevied);

                sp.Open();
                MessageBox.Show("포트가 열렸습니다.");
                textBox_databits.Enabled = false;
                comboBox_port.Enabled = false;
                comboBox_baudrate.Enabled = false;
                comboBox_stop.Enabled = false;
                button_connect.Text = "disconnect";
            }
            else
            {
                sp.Close();
                MessageBox.Show("포트가 닫혔습니다.");
                textBox_databits.Enabled = true;
                comboBox_port.Enabled = true;
                comboBox_baudrate.Enabled = true;
                comboBox_stop.Enabled = true;
                button_connect.Text = "connect";

            }
        }

        private void sp_DataRecevied(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(SerialRecevied));
        }

        private void SerialRecevied(object sender, EventArgs e)
        {
            string RecevieData = sp.ReadExisting();
            int nstx, netx;

            //없으면 -1 반환
            nstx = RecevieData.IndexOf(Convert.ToChar(0x02));
            netx = RecevieData.IndexOf(Convert.ToChar(0x03));

            if (nstx >= 0 && netx >= 0)
            {
                if (nstx < netx)
                {
                    RecevieData = RecevieData.Substring(nstx+1, (netx - nstx)-1 );
                    richTextBox_receive.AppendText(RecevieData+"\r\n");
                    richTextBox_receive.ScrollToCaret();


                }
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            comboBox_port.DataSource = SerialPort.GetPortNames();
            comboBox_stop.DataSource = Enum.GetValues(typeof(StopBits));
            comboBox_stop.SelectedIndex = 1;
            comboBox_baudrate.SelectedIndex = 5;
            textBox_databits.Text = "8";
            

        }
        Thread thread_send;
        private void button_send_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {
                programExit = false;
                if (button_checked)
                    return;
                button_checked = true;

             
                    
                thread_send = new Thread(() =>
                {
                    while (true)
                    {
                        this.Invoke(new Action(() => {
                            richTextBox_receive.AppendText(textBox_send.Text + "\r\n");
                            richTextBox_receive.ScrollToCaret();
                            sp.Write(stx + textBox_send.Text + etx);
                        }));
                        Thread.Sleep(int.Parse(textBox_delay.Text)*1000);
                        if (programExit)
                            break;

                                
                    }
                });
                thread_send.Start();
                thread_send.IsBackground = true;
                                   
                
            }
            else
            {
                MessageBox.Show("포트를 연결하세요.");
            }
           
        }
        bool programExit = false;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            programExit = true;
            if (thread_send != null && thread_send.IsAlive)
                thread_send.Abort();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            programExit = true;
            button_checked = false;
        }
    }
}
