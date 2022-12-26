using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Oracle.ManagedDataAccess.Client;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace FinalProject_GUI02
{
    public partial class dashBoard : Form
    {
        // DB
        string strConn = "Data Source=(DESCRIPTION=" +
                  "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                  "(HOST=localhost)(PORT=1521)))" +
                  "(CONNECT_DATA=(SERVER=DEDICATED)" +
                  "(SERVICE_NAME=xe)));" +
                  "User Id=hr ;Password=hr;";

        OracleDataReader rdr;
        OracleConnection conn;
        OracleCommand cmd;
        
        //login_id
        public string login_id;
        public string login_author;
        Login login_form;

        rHeader rheader = new rHeader();
        rOption roption = new rOption();
        rPayload rp = new rPayload();

        //log Thread
        Thread logThread = null;
        Thread ruleThread = null;
        Thread applyThread = null;
        Thread nanoThread = null;
        Thread dropThread = null;
        Thread ips_logThread = null;
        //Thread sudoThread = null;

        //suricata
        public string ip = "192.168.1.177";
        public string id = "root";
        public string pwd = "root123";

        //snort
        public string snort_ip = "192.168.1.1";
        public string snort_id = "root";
        public string snort_pwd = "root123";
        //Threats DB
        public string time;
        public string drop;
        public string message;
        public string priority;
        public string src_ip;
        public string src_port;
        public string dst_ip;
        public string dst_port;
        
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        
        private static extern IntPtr CreateRoundRectRgn
        (
             int nLeftRect,
             int nTopRect,
             int nRightRect,
             int nBottomRect,
             int nWidthEllipse,
             int nHeightEllipse

         );
        public dashBoard()
        {
            InitializeComponent();

            ConnectLookup();

            /// 그래프
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            TrafficGraph.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 3),
                        new ObservablePoint(1, 2),
                        new ObservablePoint(2, 1),
                        new ObservablePoint(3, 0)
                    },
                    PointGeometrySize = 10
                },
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 1),
                        new ObservablePoint(1, 1),
                        new ObservablePoint(2, 1),
                        new ObservablePoint(3, 1)
                    },
                    PointGeometrySize = 10
                }

            };

        }
               

        private void Form1_Load(object sender, EventArgs e)
        {
            UserName.Text = login_id;
            Authority.Text = login_author;
            if (login_author != "admin")
            {
                btnUsers.Visible = false;                
                btnCreateRule.Visible = false;
            }
         

        }
        /// <summary>
        /// IDS        
        private void SshCliThread()
        {
            
            var sshInfo = new ConnectionInfo(ip, id, new PasswordAuthenticationMethod(id, pwd));
            var sshCli = new SshClient(sshInfo);
            try
            {
                
                sshCli.Connect();
                
                string command = "tail -f /var/log/suricata/fast.log";
                var ClishellStream = sshCli.CreateShellStream("fast.log", 0, 0, 0, 0, 10240);

                // Send the command
                ClishellStream.WriteLine(command);

                // Read with a suitable timeout to avoid hanging
                string line;
                while ((line = ClishellStream.ReadLine()) != null)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            richTextBox1.AppendText(line + "\r\n");
                            richTextBox1.ScrollToCaret();
                        }));
                    }
                    else
                    {
                        richTextBox1.AppendText(line + "\r\n");
                        richTextBox1.ScrollToCaret();
                    }

                }
                ClishellStream.Close();
            }
            catch
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        richTextBox1.AppendText("연결이 종료되었습니다.");
                        richTextBox1.ScrollToCaret();

                    }));
                }
                else
                {
                    richTextBox1.AppendText("연결이 종료되었습니다.");
                    richTextBox1.ScrollToCaret();
                }
            }
        }


        private void SshThreatsThread()
        {
            var sshInfo = new ConnectionInfo(ip, id, new PasswordAuthenticationMethod(id, pwd));
            var sshCli = new SshClient(sshInfo);
            try
            {
                sshCli.Connect();

                string command = "tail -f /var/log/suricata/fast.log";
                var ClishellStream = sshCli.CreateShellStream("cat.log", 0, 0, 0, 0, 10240);

                // Send the command
                ClishellStream.WriteLine(command);

                if (conn == null)
                {
                    conn = new OracleConnection(strConn);
                }
                conn.Open();
                string sql1 = "delete from Threats";
                cmd = new OracleCommand(sql1, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                // Read with a suitable timeout to avoid hanging
                string line;
                while ((line = ClishellStream.ReadLine()) != null)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            if (line.Contains("**"))
                            {
                                string[] line_sep = line.Split('[', ']', '{', '}');                                
                                string prioritys = line_sep[9];
                                string ip_port = line_sep[12];
                                string ip_port_result = ip_port.Replace("->", " ");
                                string[] ip_port_sep = ip_port_result.Split(':', ' ');
                                string[] priority_sep = prioritys.Split(':',' ');

                                time = line_sep[0];
                                message = line_sep[4];
                                priority = priority_sep[2];                                                                
                                src_ip = ip_port_sep[1];
                                src_port = ip_port_sep[2];
                                dst_ip = ip_port_sep[5];
                                dst_port = ip_port_sep[6];
  
                                
                                try
                                {
                                    if (conn == null)
                                    {
                                        conn = new OracleConnection(strConn);
                                    }
                                    conn.Open();
                                  

                                    string sql = $"INSERT INTO Threats(time, message, priority, src_ip, src_port, dst_ip, dst_port) VALUES('{time}','{message}','{priority}','{src_ip}','{src_port}','{dst_ip}','{dst_port}')";
                                    DataTable ds = new DataTable();
                                    OracleDataAdapter adapter = new OracleDataAdapter(sql,conn);
                                    adapter.Fill(ds);

                                    conn.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }                            
                        }));
                    }              
                }
                ClishellStream.Close();
            }
            catch
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        richTextBox1.AppendText("연결이 종료되었습니다.");
                        richTextBox1.ScrollToCaret();

                    }));
                }
                else
                {
                    richTextBox1.AppendText("연결이 종료되었습니다.");
                    richTextBox1.ScrollToCaret();
                }
            }
        }
        
        private void SshCli_RUle_Thread()
        {
            var sshInfo = new ConnectionInfo(ip, id, new PasswordAuthenticationMethod(id, pwd));
            var sshCli = new SshClient(sshInfo);
            try
            {
                sshCli.Connect();

                string command = $"echo -e \"{textBox_candiRule.Text}\" >> /var/lib/suricata/rules/test.rules";

                var ClishellStream = sshCli.CreateShellStream("test.rules", 0, 0, 0, 0, 10240);

                // Send the command                

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {

                        if (sshCli.IsConnected == false) { return; }
                        SshCommand cmd = sshCli.CreateCommand(command);
                        cmd.Execute();

                        MessageBox.Show("룰이 추가되었습니다.");
                    }));
                }
                else
                {

                    if (sshCli.IsConnected == false) { return; }
                    SshCommand cmd = sshCli.CreateCommand(command);
                    cmd.Execute();

                    MessageBox.Show("룰이 추가되었습니다.");
                }
                ClishellStream.Close();
            }
            catch
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        richTextBox1.AppendText("연결이 종료되었습니다.");
                        richTextBox1.ScrollToCaret();

                    }));
                }
                else
                {
                    richTextBox1.AppendText("연결이 종료되었습니다.");
                    richTextBox1.ScrollToCaret();
                }
            }
        }
       
        private void SshCli_Apply_Thread()
        {
            var sshInfo = new ConnectionInfo(ip, id, new PasswordAuthenticationMethod(id, pwd));
            var sshCli = new SshClient(sshInfo);
            try
            {
                sshCli.Connect();

                string command = "kill -USR2 $(pidof suricata)";

                var ClishellStream = sshCli.CreateShellStream("rulesApply", 0, 0, 0, 0, 10240);

                // Send the command                

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        if (sshCli.IsConnected == false) { return; }
                        SshCommand cmd = sshCli.CreateCommand(command);
                        cmd.Execute();

                        MessageBox.Show("룰이 적용되었습니다.");
                    }));
                }
                else
                {

                    if (sshCli.IsConnected == false) { return; }
                    SshCommand cmd = sshCli.CreateCommand(command);
                    cmd.Execute();

                    MessageBox.Show("룰이 적용되었습니다.");
                }
                ClishellStream.Close();
            }
            catch
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        richTextBox1.AppendText("연결이 종료되었습니다.");
                        richTextBox1.ScrollToCaret();

                    }));
                }
                else
                {
                    richTextBox1.AppendText("연결이 종료되었습니다.");
                    richTextBox1.ScrollToCaret();
                }
            }
        }
        /// </summary>

        /// <summary>
        /// IPS
        private void SshIPSCliThread()
        {

            var sshInfo = new ConnectionInfo(snort_ip, snort_id, new PasswordAuthenticationMethod(snort_id, snort_pwd));
            var sshCli = new SshClient(sshInfo);
            try
            {

                sshCli.Connect();

                string command = "tail -f /var/log/alert_fast.txt";
                var ClishellStream = sshCli.CreateShellStream("fast.txt", 0, 0, 0, 0, 10240);

                // Send the command
                ClishellStream.WriteLine(command);

                // Read with a suitable timeout to avoid hanging
                string line;
                while ((line = ClishellStream.ReadLine()) != null)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            richTextBox1.AppendText(line + "\r\n");
                            richTextBox1.ScrollToCaret();
                        }));
                    }
                    else
                    {
                        richTextBox1.AppendText(line + "\r\n");
                        richTextBox1.ScrollToCaret();
                    }

                }
                ClishellStream.Close();
            }
            catch
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        richTextBox1.AppendText("연결이 종료되었습니다.");
                        richTextBox1.ScrollToCaret();

                    }));
                }
                else
                {
                    richTextBox1.AppendText("연결이 종료되었습니다.");
                    richTextBox1.ScrollToCaret();
                }
            }
        }
       
        private void SshIPSThreatsThread()
        {
            var sshInfo = new ConnectionInfo(snort_ip, snort_id, new PasswordAuthenticationMethod(snort_id, snort_pwd));
            var sshCli = new SshClient(sshInfo);
            try
            {
                sshCli.Connect();


                string command = "tail -f /var/log/alert_fast.txt";
                var ClishellStream = sshCli.CreateShellStream("snort_log", 0, 0, 0, 0, 10240);

                // Send the command
                ClishellStream.WriteLine(command);

                if (conn == null)
                {
                    conn = new OracleConnection(strConn);
                }
                conn.Open();
                string sql1 = "delete from DropThreats";
                cmd = new OracleCommand(sql1, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                // Read with a suitable timeout to avoid hanging
                string line;
                while ((line = ClishellStream.ReadLine()) != null)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            if (line.Contains("**"))
                            {

                                string[] line_sep = line.Split('[', ']', '{', '}');

                                //for(int i = 0; i < line_sep.Length; i++)
                                //{
                                //    richTextBox1.Text += line_sep[i] + "\n\r";
                                //}
                                string prioritys = line_sep[9];
                                string ip_port = line_sep[12];
                                string ip_port_result = ip_port.Replace("->", " ");
                                string[] ip_port_sep = ip_port_result.Split(':', ' ');
                                string[] priority_sep = prioritys.Split(':', ' ');
                               

                                time = line_sep[0];
                                drop = line_sep[1];
                                message = line_sep[6];
                                priority = priority_sep[2];
                                src_ip = ip_port_sep[1];
                                src_port = ip_port_sep[2];
                                dst_ip = ip_port_sep[5];
                                dst_port = ip_port_sep[6];


                                try
                                {
                                    if (conn == null)
                                    {
                                        conn = new OracleConnection(strConn);
                                    }
                                    conn.Open();


                                    string sql = $"INSERT INTO DropThreats(time, isdrop, message, priority, src_ip, src_port, dst_ip, dst_port) VALUES('{time}','{drop}','{message}','{priority}','{src_ip}','{src_port}','{dst_ip}','{dst_port}')";
                                    DataTable ds = new DataTable();
                                    OracleDataAdapter adapter = new OracleDataAdapter(sql, conn);
                                    adapter.Fill(ds);

                                    conn.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }));
                    }
                }
                ClishellStream.Close();
            }
            catch
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        richTextBox1.AppendText("연결이 종료되었습니다.");
                        richTextBox1.ScrollToCaret();

                    }));
                }
                else
                {
                    richTextBox1.AppendText("연결이 종료되었습니다.");
                    richTextBox1.ScrollToCaret();
                }
            }
        }
        
        private void SshCli_IPS_RUle_Thread()
        {
            var sshInfo = new ConnectionInfo(snort_ip, snort_id, new PasswordAuthenticationMethod(snort_id, snort_pwd));
            var sshCli = new SshClient(sshInfo);
            try
            {
                sshCli.Connect();

                string command = $"echo -e \"{textBox_candiRule.Text}\" >> /etc/snort/rules/test.rules";

                var ClishellStream = sshCli.CreateShellStream("test.rules", 0, 0, 0, 0, 10240);

                // Send the command                

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {

                        if (sshCli.IsConnected == false) { return; }
                        SshCommand cmd = sshCli.CreateCommand(command);
                        cmd.Execute();

                        MessageBox.Show("룰이 추가되었습니다.");
                    }));
                }
                else
                {

                    if (sshCli.IsConnected == false) { return; }
                    SshCommand cmd = sshCli.CreateCommand(command);
                    cmd.Execute();

                    MessageBox.Show("룰이 추가되었습니다.");
                }
                ClishellStream.Close();
            }
            catch
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        richTextBox1.AppendText("연결이 종료되었습니다.");
                        richTextBox1.ScrollToCaret();

                    }));
                }
                else
                {
                    richTextBox1.AppendText("연결이 종료되었습니다.");
                    richTextBox1.ScrollToCaret();
                }
            }
        }
        
        private void SshCli_IPS_Apply_Thread()
        {
            var sshInfo = new ConnectionInfo(snort_ip, snort_id, new PasswordAuthenticationMethod(snort_id, snort_pwd));
            var sshCli = new SshClient(sshInfo);

            try
            {
                sshCli.Connect();

                string command = "kill -1 $(pidof snort)";

                var ClishellStream = sshCli.CreateShellStream("rulesApply", 0, 0, 0, 0, 10240);

                // Send the command                

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        if (sshCli.IsConnected == false) { return; }
                        SshCommand cmd = sshCli.CreateCommand(command);
                        cmd.Execute();

                        MessageBox.Show("룰이 적용되었습니다.");
                    }));
                }
                else
                {

                    if (sshCli.IsConnected == false) { return; }
                    SshCommand cmd = sshCli.CreateCommand(command);
                    cmd.Execute();

                    MessageBox.Show("룰이 적용되었습니다.");
                }
                ClishellStream.Close();
            }
            catch
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        richTextBox1.AppendText("연결이 종료되었습니다.");
                        richTextBox1.ScrollToCaret();

                    }));
                }
                else
                {
                    richTextBox1.AppendText("연결이 종료되었습니다.");
                    richTextBox1.ScrollToCaret();
                }
            }
        }
        /// </summary>
        
        private void btnDashboard_Click(object sender, EventArgs e)
        {

            Theme.Text = "Dashboard";
            Dashboard_Panel.Visible = true;
            Threats_Panel.Visible = false;
            Users_Panel.Visible = false;
            CreateRule_Panel.Visible = false;
           // Settings_panel.Visible = false;           
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void btnThreats_Click(object sender, EventArgs e)
        {

            Dashboard_Panel.Visible = false;
            Threats_Panel.Visible = true;
            Users_Panel.Visible = false;
            CreateRule_Panel.Visible = false;
           // Settings_panel.Visible = false;            
            Theme.Text = "Threats";           
            pnlNav.Height = btnThreats.Height;
            pnlNav.Top = btnThreats.Top;
            pnlNav.Left = btnThreats.Left;
            btnThreats.BackColor = Color.FromArgb(46, 51, 73);
           
        }
        
        private void btnUsers_Click(object sender, EventArgs e)
        {
            Dashboard_Panel.Visible = false;
            Threats_Panel.Visible = false;
            Users_Panel.Visible = true;
            CreateRule_Panel.Visible = false;
            //Settings_panel.Visible = false;            
            Theme.Text = "Users";            
            pnlNav.Height = btnUsers.Height;
            pnlNav.Top = btnUsers.Top;
            pnlNav.Left = btnUsers.Left;
            btnUsers.BackColor = Color.FromArgb(46, 51, 73);            
            
        }

        private void btnCreateRule_Click(object sender, EventArgs e)
        {
            Dashboard_Panel.Visible = false;
            Threats_Panel.Visible = false;
            Users_Panel.Visible = false;
            CreateRule_Panel.Visible = true;
            //Settings_panel.Visible = false;            
            Theme.Text = "Create Rules";
            pnlNav.Height = btnCreateRule.Height;
            pnlNav.Top = btnCreateRule.Top;
            pnlNav.Left = btnCreateRule.Left;
            btnCreateRule.BackColor = Color.FromArgb(46, 51, 73);

            
        }
        
        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnThreats_Leave(object sender, EventArgs e)
        {
            btnThreats.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnUsers_Leave(object sender, EventArgs e)
        {
            btnUsers.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCreateRule_Leave(object sender, EventArgs e)
        {
            btnCreateRule.BackColor = Color.FromArgb(24, 30, 54);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

      
      
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
            

        }
      

        private void cboAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAction.SelectedIndex < 0)
                return;
            autoCreateRule();
        }

        private void cboProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProtocol.SelectedIndex < 0)
                return;
            autoCreateRule();
        }

        private void textBox_sIp_TextChanged(object sender, EventArgs e)
        {
            autoCreateRule();
        }

        private void textBox_sPort_TextChanged(object sender, EventArgs e)
        {
            autoCreateRule();
        }

        private void cboDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDirection.SelectedIndex < 0)
                return;
            autoCreateRule();
        }

        private void textBox_dIp_TextChanged(object sender, EventArgs e)
        {
            autoCreateRule();
        }

        private void textBox_dPort_TextChanged(object sender, EventArgs e)
        {
            autoCreateRule();
        }
        
        private void autoCreateRule()
        {
            //탐지규칙 생성
            rheader.Action = cboAction.Text;
            rheader.Protocol = cboProtocol.Text;
            rheader.Direction = cboDirection.Text;
            rheader.SourceIP = textBox_sIp.Text;
            rheader.DestIP = textBox_dIp.Text;
            rheader.SourcePort = textBox_sPort.Text;
            rheader.DestPort = textBox_dPort.Text;
            
            RuleBuilder rBuilder = new RuleBuilder();

            string header = rBuilder.mkHeader(rheader);
            string option = rBuilder.mkOption(roption);
            
            textBox_candiRule.Text = header + " " + option;
        }


        /// <summary>
        /// ////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        internal rHeader Rheader
        {
            get { return rheader; }
            set { rheader = value; }
        }


        internal rOption Roption
        {
            get { return roption; }
            set { roption = value; }
        }



        internal rPayload Rp
        {
            get { return rp; }
            set { rp = value; }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            string nodeKey = e.Node.GetDisplayText(0);
            string nodeVal = (string)e.Node.GetValue(1);
            
            //TreeListSelection selectedNodes = treeList1.Selection;
            //string nodeVal = selectedNodes[0].GetValue(treeList1.Columns[0]).ToString();
            switch (nodeKey)
            {
                case "msg":
                    roption.Msg = nodeVal;
                    autoCreateRule();                                     
                    break;
                case "content":
                    roption.Content = nodeVal;
                    autoCreateRule();
                    break;
                case "nocase":
                    roption.Nocase = nodeVal;
                    autoCreateRule();
                    break;
                case "rawbytes":
                    roption.Rawbytes = nodeVal;
                    autoCreateRule();
                    break;
                case "depth":
                    roption.Depth = nodeVal;
                    autoCreateRule();
                    break;
                case "offset":
                    roption.Offset = nodeVal;
                    break;
                case "distance":
                    roption.Distance = nodeVal;
                    break;
                case "within":
                    roption.Within = nodeVal;
                    break;
                case "isdataat":
                    roption.Isdataat = nodeVal;
                    autoCreateRule();
                    break;
                case "pcre":
                    roption.Pcre = nodeVal;
                    autoCreateRule();
                    break;
                case "byte_test":
                    roption.Byte_test = nodeVal;
                    autoCreateRule();
                    break;
                case "byte_jump":
                    roption.Byte_jump = nodeVal;
                    autoCreateRule();
                    break;
                case "ttl":
                    roption.Ttl = nodeVal;
                    autoCreateRule();
                    break;
                case "iType":
                    roption.Itype = nodeVal;
                    autoCreateRule();
                    break;
                case "iCode":
                    roption.Icode = nodeVal;
                    autoCreateRule();
                    break;
                case "icmp_id":
                    roption.Icmp_id = nodeVal;
                    autoCreateRule();
                    break;
                case "icmp_seq":
                    roption.Icmp_seq = nodeVal;                    
                    autoCreateRule();
                    break;
                case "priority":
                    roption.Priority = nodeVal;
                    autoCreateRule();
                    break;
                case "rev":
                    roption.Rev = nodeVal;
                    autoCreateRule();
                    break;


            }
            
        }
       

        private void btnLogout_Click(object sender, EventArgs e)
        {
            login_form = new Login();
            login_form.Show();
            this.Hide();
        }

        //private void commit()
        //{
        //    cmd.CommandText = "commit";
        //    cmd.ExecuteNonQuery();
        //}


        private void ConnectLookup()
        {
            try
            {
                if (conn == null)
                {
                    conn = new OracleConnection(strConn);
                }
                conn.Open();
                string sql1 = "select * from create_User";
                string sql2 = "select * from login_User";

                OracleDataAdapter adapter = new OracleDataAdapter(sql1, conn);
                OracleDataAdapter adapter1 = new OracleDataAdapter(sql2, conn);
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                adapter.Fill(dt);
                adapter1.Fill(dt1);
                createGrid.DataSource = dt;
                userGrid.DataSource = dt1;
                createGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                userGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnAdmin_Click_1(object sender, EventArgs e)
        {
            string sql = $"UPDATE create_User set AUTHORITY = 'admin' where ID = '{txtAuthor.Text}'";
            DataTable dt = new DataTable();
            OracleDataAdapter adapt = new OracleDataAdapter(sql, conn);
            adapt.Fill(dt);
            conn.Close();
            ConnectLookup();
            MessageBox.Show($"{txtAuthor.Text}님의 권한이 admin로 설정되었습니다.");
        }

        private void btnUser_Click_1(object sender, EventArgs e)
        {
            string sql = $"UPDATE create_User set AUTHORITY = 'user' where ID = '{txtAuthor.Text}'";
            DataTable dt = new DataTable();
            OracleDataAdapter adapt = new OracleDataAdapter(sql, conn);
            adapt.Fill(dt);
            conn.Close();
            ConnectLookup();
            MessageBox.Show($"{txtAuthor.Text}님의 권한이 user로 설정되었습니다.");
        }

        private void btnRevoke_Click_1(object sender, EventArgs e)
        {
            string sql = $"UPDATE create_User set AUTHORITY = '-' where ID = '{txtAuthor.Text}'";
            DataTable dt = new DataTable();
            OracleDataAdapter adapt = new OracleDataAdapter(sql, conn);
            adapt.Fill(dt);
            conn.Close();
            ConnectLookup();
            MessageBox.Show($"{txtAuthor.Text}님의 권한이 회수되었습니다.");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try {
                string sql = $"UPDATE create_User set ACCEPT = 'O' where ID = '{txtAuthor.Text}'";
                string sql1 = $"INSERT INTO login_User(ID,PASSWORD,AUTHORITY) SELECT ID,PASSWORD,AUTHORITY FROM create_User WHERE ID = '{txtAuthor.Text}'";
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                OracleDataAdapter adapt = new OracleDataAdapter(sql, conn);
                OracleDataAdapter adapt1 = new OracleDataAdapter(sql1, conn);
                adapt.Fill(dt);
                adapt1.Fill(dt1);
                conn.Close();
                ConnectLookup();
                MessageBox.Show($"{txtAuthor.Text}님의 가입이 승인되었습니다.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void createGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtAuthor.Text = createGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
        private void userGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtAuthor.Text = userGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM login_User where ID ='{txtAuthor.Text}'";
            string sql1 = $"UPDATE create_User set ACCEPT = 'X' where ID = '{txtAuthor.Text}'";
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            OracleDataAdapter ad = new OracleDataAdapter(sql, conn);
            OracleDataAdapter ad1 = new OracleDataAdapter(sql1, conn);
            ad.Fill(dt);
            ad1.Fill(dt1);
            conn.Close();
            ConnectLookup();
            MessageBox.Show($"{txtAuthor.Text}이 회원목록에서 삭제되었습니다.");
        }               
        
        private void btnAddRule_Server_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (conn == null)
                {
                    conn = new OracleConnection(strConn);
                }
                conn.Open();
                string sql = $"INSERT INTO maked_rule(sid, msg, rule) VALUES('{roption.Sid}', '{roption.Msg}','{textBox_candiRule.Text}')";
                cmd = new OracleCommand(sql, conn);
                cmd.ExecuteNonQuery();
                
                conn.Close();
                ruleThread = new Thread(new ThreadStart(SshCli_RUle_Thread));
                ruleThread.Start();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
        private void btnApply_Server_Click(object sender, EventArgs e)
        {
            applyThread = new Thread(new ThreadStart(SshCli_Apply_Thread));
            applyThread.Start();
        }

        private void createSid_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null)
                {
                    conn = new OracleConnection(strConn);
                }
                conn.Open();
                string sql = "SELECT sid_seq.NEXTVAL from dual";
                cmd = new OracleCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    roption.Sid = rdr.GetString(0);
                }
                rdr.Close();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            autoCreateRule();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (conn == null)
                {
                    conn = new OracleConnection(strConn);
                }
                conn.Open();
                string sql = $"SELECT rule from maked_rule where msg = '{comboBox1.Text}'";
                cmd = new OracleCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    textBox_candiRule.Text = rdr.GetString(0);
                }

                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnIdsLog_Click(object sender, EventArgs e)
        {

            try
            {
                if (conn == null)
                {
                    conn = new OracleConnection(strConn);
                }
                conn.Open();

                string sql = "select * from Threats";
                OracleDataAdapter adapt = new OracleDataAdapter(sql, conn);
                DataTable dt1 = new DataTable();
                adapt.Fill(dt1);
                dtThreat.DataSource = dt1;
                dtThreat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                string sql1 = "select count(*) from Threats";
                cmd = new OracleCommand(sql1, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    label29.Text = rdr.GetString(0);
                }
                string sql2 = "select max(src_ip) , max(count(src_ip)) as cnt from Threats GROUP by src_ip";
                cmd = new OracleCommand(sql2, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    label20.Text = rdr.GetString(0);
                    label21.Text = rdr.GetString(1);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnIpsLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null)
                {
                    conn = new OracleConnection(strConn);
                }
                conn.Open();

                string sql = "select * from dropThreats";
                OracleDataAdapter adapt = new OracleDataAdapter(sql, conn);
                DataTable dt1 = new DataTable();
                adapt.Fill(dt1);
                dtThreat.DataSource = dt1;
                dtThreat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                string sql1 = "select count(*) from dropThreats";
                cmd = new OracleCommand(sql1, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    label29.Text = rdr.GetString(0);
                }
                string sql2 = "select max(src_ip) , max(count(src_ip)) as cnt from dropThreats GROUP by src_ip";
                cmd = new OracleCommand(sql2, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    label20.Text = rdr.GetString(0);
                    label21.Text = rdr.GetString(1);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIDS_Click(object sender, EventArgs e)
        {
            
            richTextBox1.Clear();
            label29.Text = "";
            label20.Text = "";
            label21.Text = "";
            richTextBox1.Text = "IDS모드 실행중.....\n\r";
            btnIdsLog.Enabled = true;


            var sshInfo = new ConnectionInfo(ip, id, new PasswordAuthenticationMethod(id, pwd));
            var Cli = new SshClient(sshInfo);

            try
            {
                Cli.Connect();

                string command = "suricata -c /etc/suricata/suricata.yaml -i wlan0 -q -D";
                var ClishellStream = Cli.CreateShellStream("suricataopen", 0, 0, 0, 0, 10200);

                // Send the command                

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        if (Cli.IsConnected == false)
                        {
                            SshCommand command1 = Cli.CreateCommand(command);
                            command1.Execute();               
                        }
                        else
                        {
                            SshCommand command1 = Cli.CreateCommand(command);
                            command1.Execute();
                        }                        
                    }));
                }
                else
                {
                    if (Cli.IsConnected == false)
                    {
                        SshCommand command1 = Cli.CreateCommand(command);
                        command1.Execute();
                    }
                    else
                    {
                        SshCommand command1 = Cli.CreateCommand(command);
                        command1.Execute();
                    }

                }
                ClishellStream.Close();
            }
            catch
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        richTextBox1.AppendText("연결이 종료되었습니다.");
                        richTextBox1.ScrollToCaret();

                    }));
                }
                else
                {
                    richTextBox1.AppendText("연결이 종료되었습니다.");
                    richTextBox1.ScrollToCaret();
                }
            }

            conn = new OracleConnection(strConn);

            conn.Open();
            OracleDataAdapter adapter = new OracleDataAdapter("select * from maked_rule", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "msg";
            comboBox1.ValueMember = "rule";
            conn.Close();
            Thread.Sleep(3000);

            if (dropThread != null && ips_logThread != null)
            {
                dropThread.Abort();
                ips_logThread.Abort();
            }

            nanoThread = new Thread(new ThreadStart(SshThreatsThread));
            nanoThread.Start();
            logThread = new Thread(new ThreadStart(SshCliThread));
            logThread.Start();            

        }


        public void btnIPS_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            label29.Text = "";
            label20.Text = "";
            label21.Text = "";
            dtThreat.Columns.Clear();
            btnIdsLog.Enabled = false;
            richTextBox1.Text = "IPS모드 실행중.....\n\r";


            var sshInfo = new ConnectionInfo(snort_ip, snort_id, new PasswordAuthenticationMethod(snort_id, snort_pwd));
            var Cli = new SshClient(sshInfo);

            try
            {
                Cli.Connect();

                string command = "snort -c /etc/snort/snort.lua -i wan:br-lan --daq-dir /usr/lib/daq -A alert_fast -Q -l /var/log/ -D -q";
                var ClishellStream = Cli.CreateShellStream("snortopen", 0, 0, 0, 0, 10200);

                // Send the command                

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        if (Cli.IsConnected == false) 
                        {
                            SshCommand command1 = Cli.CreateCommand(command);
                            command1.Execute();                            
                        }
                        else
                        {
                            SshCommand command1 = Cli.CreateCommand(command);
                            command1.Execute();
                        }
                        

                    }));
                }
                else
                {
                    if (Cli.IsConnected == false)
                    {
                        SshCommand command1 = Cli.CreateCommand(command);
                        command1.Execute();
                    }
                    else
                    {
                        SshCommand command1 = Cli.CreateCommand(command);
                        command1.Execute();
                    }
                }
                ClishellStream.Close();
            }
            catch
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {                        
                        richTextBox1.AppendText("연결이 종료되었습니다.");
                        richTextBox1.ScrollToCaret();

                    }));
                }
                else
                {
                    richTextBox1.AppendText("연결이 종료되었습니다.");
                    richTextBox1.ScrollToCaret();
                }
            } 


            if (nanoThread != null && logThread != null)
            {
                nanoThread.Abort();
                logThread.Abort();                                          
                
            }           
            dropThread = new Thread(SshIPSThreatsThread);
            dropThread.Start();
            ips_logThread = new Thread(SshIPSCliThread);
            ips_logThread.Start();
                      
            
        }

    
    }
}
