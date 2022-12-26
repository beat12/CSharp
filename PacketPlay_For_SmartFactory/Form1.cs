using PacketDotNet.Ieee80211;
using Renci.SshNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System.IO.Compression;
using System.Net.Mail;
using System.Net;
using PacketDotNet;
using System;
using System.Net.NetworkInformation;
using System.Xml;


namespace PacketPlay_For_SmartFactory
{
    public partial class Form1 : Form
    {
        string BaseDir = "";
        string PktDir = "Pcap";
        List<FileInfo> fileInfos = new List<FileInfo>();

        //ssh process
        SshClient sshSvr = null;
        ConnectionInfo sshInfo = null;
        ShellStream SvrshellStream = null;
        Thread monThread = null;

        //��Ŷ ����
        ICaptureDevice device;

        public Form1()
        {
            InitializeComponent();
            BaseDir = Application.StartupPath;
            PktDir = Path.Combine(BaseDir, PktDir);
            
            
            //Pcap ���
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(PktDir);
            
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                if (File.Extension.ToLower().CompareTo(".pcap") == 0)
                {
                    FileInfo f = new FileInfo(File.FullName);
                    fileInfos.Add(f);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            foreach (FileInfo f in fileInfos)
                checkedListBox1.Items.Add(f.Name);
            comboBox1.SelectedIndex = 0;




        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox_svr.Text = "";
            richTextBox_svr.AppendText(textBox_tip.Text + " �� ������ �õ��մϴ�.\r\n");
            sshInfo = new ConnectionInfo(textBox_tip.Text, textBox_tid.Text, new PasswordAuthenticationMethod(textBox_tid.Text, textBox_tpwd.Text));
            if (comboBox1.SelectedItem ==null)
            {
                MessageBox.Show("�������̽��� �������ּ���.");
                return;
            }
            monThread = new Thread(new ThreadStart(SshSvrThread));
            monThread.Start();
        }

        private void SshSvrThread()
        {
            sshSvr = new SshClient(sshInfo);
            try
            {
                sshSvr.Connect();
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        richTextBox2.AppendText("����Ǿ����ϴ�.\r\n�α� ���� ��带 �����մϴ�.\r\n\r\n");
                    }));
                }
                else
                {
                    richTextBox2.AppendText("����Ǿ����ϴ�.\r\n�α� ���� ��带 �����մϴ�.\r\n\r\n");
                }

                string command = $"tcpdump -i {comboBox1.SelectedItem} -n not port 22 and not port 443";
                //string command = "cp /etc/snort/rules/test.rules /root/test.rules.20221203132132; echo \"alet test .... \" >> /etc/snort/rules/test.rules; /etc/init.d/snort reload";
                //string command = "tail -f /var/log/alert_fast.txt";
                SvrshellStream = sshSvr.CreateShellStream("run_logger", 0, 0, 0, 0, 10240);


                // Send the command
                SvrshellStream.WriteLine(command);

                // Read with a suitable timeout to avoid hanging
                string line;
                while ((line = SvrshellStream.ReadLine()) != null)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            richTextBox_svr.AppendText(line + "\r\n");
                            richTextBox_svr.ScrollToCaret();
                        }));
                    }
                    else
                    {
                        richTextBox_svr.AppendText(line + "\r\n");
                        richTextBox_svr.ScrollToCaret();
                    }

                    //Console.WriteLine(line);
                    // if a termination pattern is known, check it here and break to exit immediately
                }
                // ...
                SvrshellStream.Close();

                //var output = ssh.CreateCommand("bash ./run_bringup.sh").Execute();
                //richTextBox1.AppendText(output);
                //richTextBox1.ScrollToCaret();

            }
            catch (Exception e)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        richTextBox2.AppendText("������ ����Ǿ����ϴ�.");
                        richTextBox2.ScrollToCaret();
                    }));
                }
                else
                {
                    richTextBox2.AppendText("������ ����Ǿ����ϴ�.");
                    richTextBox2.ScrollToCaret();
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex < 0)
                return;
            else
            {
                //checkedListBox1.ClearSelected();

                string keyFile = checkedListBox1.Items[checkedListBox1.SelectedIndex].ToString();


                foreach (int i in checkedListBox1.CheckedIndices)
                {
                    if(i == checkedListBox1.SelectedIndex)
                        checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                    else
                        checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }

                //ReadXml(keyFile);

            }
        }

        //private void ReadXml(string? keyFile)
        //{
        //    // xml�� ���� ���� �о�ͼ� �Ʒ� ������� ä���ִ� �ڵ� ����
        //    // ����� xml �̿ϼ�
        //    string filePath = "C:\\Users\\Admin\\source\\repos\\SharpPcap\\SharpPcap\\authors.xml";

        //    //AuthorsDataSet.ReadXml(filePath);

        //    dataGridView1.DataSource = AuthorsDataSet;
        //    dataGridView1.DataMember = "authors";
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            string pcapfile = "";
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    pcapfile = checkedListBox1.Items[i].ToString();
                    break;
                }
            }
            if(string.IsNullOrEmpty(pcapfile))
            {
                MessageBox.Show("���õ� Pcap ������ �����ϴ�.\r\n������ üũ�� �ּ���.");
                return;
            }

            //ĸó ����̽� ����
            string pcapfileFullName = Path.Combine(PktDir, pcapfile);
            try
            {
                // Get an offline file pcap device
                device = new CaptureFileReaderDevice(pcapfileFullName);

                // Open the device for capturing
                device.Open();
                richTextBox_attacker.Text = "";
                richTextBox2.AppendText("ĸó ����̽� ����\r\n");
            }
            catch (Exception ex)
            {
                richTextBox2.AppendText(ex.Message);
                return;
            }

            SendQueue squeue = ReadPcap(pcapfileFullName);
            
            //Send Packet!
            ////////////////////// �����ʹ� �ʿ��� �ڵ����� Ȯ�� �ʿ�
            ///
            var devices = LibPcapLiveDeviceList.Instance;

            //device = devices[0];  //�ڽ��� Ȱ��ȭ�� �������̽� �ڵ����� �����ϵ��� ������ ��!
            

            devices[9].Open();
            ///////////////////������ ///////////////////////////

            if (devices[9].LinkType != device.LinkType)
            {
                    devices[9].Close();
                    return;
             }

            // �������� ��ġ�� �ݴ�
            device.Close();

            // ���� ��Ŷ�� �����ϱ� ���� ��Ʈ��ũ ��ġ�� ã���ϴ�.
            device = devices[9];
            richTextBox2.AppendText("Original Eth packet Modification completed\r\nOriginal IP packet Modification completed\r\nOriginal TCPorUDP packet Modification completed\r\n");
            //resp = "y";
            richTextBox2.AppendText("���� ���� �غ� ��..");
            //if ((resp != "") && (!resp.StartsWith("y")))
            //{
            //    return;
            //}

            try
            {
                var liveDevice = device as LibPcapLiveDevice;
                for (int i = 1; i <= Int32.Parse(textBox3.Text); i++)
                {
                    richTextBox2.AppendText($"{i}��° ���� ���� ��...\r\n");
                    int sent = squeue.Transmit(liveDevice, SendQueueTransmitModes.Synchronized);
                    richTextBox2.AppendText("���� �Ϸ�!\r\n");
                    richTextBox2.ScrollToCaret();

                    if (sent < squeue.CurrentLength)
                    {
                        richTextBox2.AppendText($"An error occurred sending the packets: {device.LastError}. " +
                            "Only {sent} bytes were sent\r\n");
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox2.AppendText("Error: " + ex.Message);
            }

            // ��⿭ ����
            squeue.Dispose();
            richTextBox2.AppendText("-- ��Ŷ ��⿭ ����");
            // pcap ��ġ �ݱ�
            device.Close();


            //var liveDevice = device as LibPcapLiveDevice;
            //int sent = squeue.Transmit(liveDevice, SendQueueTransmitModes.Synchronized);

        }

        private SendQueue ReadPcap(string pcapfile)
        {
            //Allocate a new send queue
            SendQueue squeue = new SharpPcap.LibPcap.SendQueue
                ((int)((CaptureFileReaderDevice)device).FileSize);

            RawCapture rawpacket;
            PacketCapture e;
            GetPacketStatus retval;
            try
            {
                // ������ ��� ��Ŷ�� ����Ͽ� ��⿭�� �߰�
                while ((retval = device.GetNextPacket(out e)) == GetPacketStatus.PacketRead)
                {
                    rawpacket = e.GetPacket();
                    
                    rawpacket = editPacket(rawpacket, textBox_dstip.Text.ToString(), textBox_dstport.Text.ToString());
                    
                    if (!squeue.Add(rawpacket))
                    {
                        richTextBox2.AppendText("Warning: packet buffer too small, " +
                            "not all the packets will be sent.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox2.AppendText(ex.Message);
                return null;
            }
            return squeue;
            
        }
       
        private RawCapture editPacket(RawCapture rawPacket, string dstIP, string dstPort)
        {
            RawCapture rtnPacket = rawPacket;
            var packet = PacketDotNet.Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
            if (packet is PacketDotNet.EthernetPacket eth)
            {
                
                richTextBox_attacker.AppendText("Original Eth packet: " + eth.ToString() + "\r\n");
                richTextBox_attacker.ScrollToCaret();

                //Manipulate ethernet parameters
                //eth.SourceHardwareAddress = PhysicalAddress.Parse("98-83-89-28-B1-02");
                //eth.DestinationHardwareAddress = PhysicalAddress.Parse("58-86-94-59-93-98");
                
                var ip = packet.Extract<PacketDotNet.IPv4Packet>();
                if (ip != null)
                {
                    richTextBox_attacker.AppendText("Original IP packet: " + ip.ToString() + "\r\n");
                    richTextBox_attacker.ScrollToCaret();
                    //manipulate IP parameters

                    //ip.SourceAddress = System.Net.IPAddress.Parse("1.2.3.4");
                    if ((textBox_dstip.Text)!="" )
                        ip.DestinationAddress = System.Net.IPAddress.Parse(textBox_dstip.Text);
                    
                    

                    ip.Checksum=ip.CalculateIPChecksum();

                    //ip.TimeToLive = 11;

                    var tcp = packet.Extract<PacketDotNet.TcpPacket>();
                    if (tcp != null)
                    {
                        richTextBox_attacker.AppendText("Original TCP packet: " + tcp.ToString() + "\r\n");
                        richTextBox_attacker.ScrollToCaret();
                        //manipulate TCP parameters
                        //tcp.SourcePort = 9999;
                        if(textBox_dstport.Text != "")
                        {
                            tcp.DestinationPort = ushort.Parse(textBox_dstport.Text);
                        }
                        
                        tcp.Checksum = tcp.CalculateTcpChecksum();

                        //tcp.Synchronize = !tcp.Synchronize;
                        //tcp.Finished = !tcp.Finished;
                        //tcp.Acknowledgment = !tcp.Acknowledgment;
                        //tcp.WindowSize = 500;
                        //tcp.AcknowledgmentNumber = 800;
                        //tcp.SequenceNumber = 800;
                    }

                    var udp = packet.Extract<PacketDotNet.UdpPacket>();
                    if (udp != null)
                    {
                        richTextBox_attacker.AppendText("Original UDP packet: " + udp.ToString() + "\r\n");
                        richTextBox_attacker.ScrollToCaret();
                        //manipulate UDP parameters
                        //udp.SourcePort = 9999;
                        if (textBox_dstport.Text != "")
                        {
                            udp.DestinationPort = ushort.Parse(textBox_dstport.Text);
                        }
                        

                        udp.Checksum = udp.CalculateUdpChecksum();
                    }
                }

                richTextBox_attacker.AppendText("Manipulated Eth packet: " + eth.ToString() + "\r\n");
                richTextBox_attacker.ScrollToCaret();
            }
            
            return rtnPacket;
        }

    }
}