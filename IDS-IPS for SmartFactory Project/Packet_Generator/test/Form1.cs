using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpPcap;
using SharpPcap.LibPcap;

namespace test
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ver = Pcap.SharpPcapVersion;
            richTextBox1.AppendText($"SharpPcap {ver}, Example10.SendQueues.cs\n");

            richTextBox1.AppendText("-- Please enter an input capture file name: ");

        }
        ICaptureDevice device;
        SendQueue squeue;
        private void button1_Click(object sender, EventArgs e)
        {
            
            string capFile = "C:\\Users\\Admin\\Desktop\\PacketPlay_test\\PacketPlay_For_SmartFactory\\PacketPlay_For_SmartFactory\\bin\\Debug\\net6.0-windows\\Pcap\\" + textBox1.Text.ToString();
            try
            {
                // Get an offline file pcap device
                device = new CaptureFileReaderDevice(capFile);

                // Open the device for capturing
                device.Open();
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText(ex.Message);
                return;
            }

            richTextBox1.AppendText("Queueing packets...");

            //Allocate a new send queue
            var squeue = new SharpPcap.LibPcap.SendQueue
                ((int)((CaptureFileReaderDevice)device).FileSize);
            RawCapture packet;
            PacketCapture whdkd;
            GetPacketStatus retval;

            try
            {
                //Go through all packets in the file and add to the queue
                while ((retval = device.GetNextPacket(out whdkd)) == GetPacketStatus.PacketRead)
                {
                    packet = whdkd.GetPacket();
                    if (!squeue.Add(packet))
                    {
                        richTextBox1.AppendText("Warning: packet buffer too small, " +
                            "not all the packets will be sent.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText(ex.Message);
                return;
            }

            richTextBox1.AppendText("OK");

            richTextBox1.AppendText("\r\n");
            richTextBox1.AppendText("The following devices are available on this machine:");
            richTextBox1.AppendText("----------------------------------------------------");
            richTextBox1.AppendText("\r\n");
            textBox1.Text = "";
            var devices = LibPcapLiveDeviceList.Instance;
            /* Scan the list printing every entry */
            foreach (var dev in devices)
            {
                /* Description */
                richTextBox1.AppendText($"{i}) {dev.Name} {dev.Description}");
                i++;
            }
            richTextBox1.AppendText("\r\n");
            richTextBox1.AppendText("-- Please choose a device to transmit on: ");
            i = int.Parse(textBox2.Text);
            devices[i].Open();
            textBox2.Text = "";
            string resp;

            if (devices[i].LinkType != device.LinkType)
            {
                richTextBox1.AppendText("Warning: the datalink of the capture" +
                    " differs from the one of the selected interface, continue? [YES|no]");
                resp = textBox3.Text.ToString();

                if ((resp != "") && (!resp.StartsWith("y")))
                {
                    richTextBox1.AppendText("Cancelled by user!");
                    devices[i].Close();
                    return;
                }
            }

            // close the offline device
            device.Close();

            // find the network device for sending the packets we read
            device = devices[i];

            richTextBox1.AppendText("This will transmit all queued packets through" +
                " this device, continue? [YES|no]");
            resp = textBox3.Text.ToString();

            if ((resp != "") && (!resp.StartsWith("y")))
            {
                richTextBox1.AppendText("Cancelled by user!");
                return;
            }

            try
            {
                var liveDevice = device as LibPcapLiveDevice;

                richTextBox1.AppendText("Sending packets...");
                int sent = squeue.Transmit(liveDevice, SendQueueTransmitModes.Synchronized);
                richTextBox1.AppendText("Done!");
                if (sent < squeue.CurrentLength)
                {
                    richTextBox1.AppendText($"An error occurred sending the packets: {device.LastError}. " +
                        "Only {sent} bytes were sent\n");
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText("Error: " + ex.Message);
            }

            //Free the queue
            squeue.Dispose();
            richTextBox1.AppendText("-- Queue is disposed.");
            //Close the pcap device
            device.Close();
            richTextBox1.AppendText("-- Device closed.");
            richTextBox1.AppendText("Hit 'Enter' to exit...");
            Console.ReadLine();
        }
        LibPcapLiveDeviceList devices;
        int i = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            

            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}

