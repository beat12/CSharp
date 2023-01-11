namespace Serial
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.comboBox_baudrate = new System.Windows.Forms.ComboBox();
            this.textBox_databits = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox_receive = new System.Windows.Forms.RichTextBox();
            this.textBox_send = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_stop = new System.Windows.Forms.ComboBox();
            this.textBox_delay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM포트";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baudrate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Databits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stopbits";
            // 
            // comboBox_port
            // 
            this.comboBox_port.FormattingEnabled = true;
            this.comboBox_port.Location = new System.Drawing.Point(119, 64);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(136, 23);
            this.comboBox_port.TabIndex = 4;
            // 
            // comboBox_baudrate
            // 
            this.comboBox_baudrate.FormattingEnabled = true;
            this.comboBox_baudrate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800"});
            this.comboBox_baudrate.Location = new System.Drawing.Point(119, 113);
            this.comboBox_baudrate.Name = "comboBox_baudrate";
            this.comboBox_baudrate.Size = new System.Drawing.Size(136, 23);
            this.comboBox_baudrate.TabIndex = 5;
            // 
            // textBox_databits
            // 
            this.textBox_databits.Location = new System.Drawing.Point(119, 165);
            this.textBox_databits.Name = "textBox_databits";
            this.textBox_databits.Size = new System.Drawing.Size(136, 25);
            this.textBox_databits.TabIndex = 6;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(70, 268);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(116, 32);
            this.button_connect.TabIndex = 8;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(369, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "수신";
            // 
            // richTextBox_receive
            // 
            this.richTextBox_receive.Location = new System.Drawing.Point(364, 67);
            this.richTextBox_receive.Name = "richTextBox_receive";
            this.richTextBox_receive.Size = new System.Drawing.Size(391, 232);
            this.richTextBox_receive.TabIndex = 10;
            this.richTextBox_receive.Text = "";
            // 
            // textBox_send
            // 
            this.textBox_send.Location = new System.Drawing.Point(364, 328);
            this.textBox_send.Name = "textBox_send";
            this.textBox_send.Size = new System.Drawing.Size(238, 25);
            this.textBox_send.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(361, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "송신";
            // 
            // comboBox_stop
            // 
            this.comboBox_stop.FormattingEnabled = true;
            this.comboBox_stop.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800"});
            this.comboBox_stop.Location = new System.Drawing.Point(119, 219);
            this.comboBox_stop.Name = "comboBox_stop";
            this.comboBox_stop.Size = new System.Drawing.Size(136, 23);
            this.comboBox_stop.TabIndex = 14;
            // 
            // textBox_delay
            // 
            this.textBox_delay.Location = new System.Drawing.Point(625, 328);
            this.textBox_delay.Name = "textBox_delay";
            this.textBox_delay.Size = new System.Drawing.Size(73, 25);
            this.textBox_delay.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(622, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Delay(Sec)";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(704, 329);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(51, 24);
            this.button_send.TabIndex = 12;
            this.button_send.Text = "start";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(704, 359);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(51, 24);
            this.button_stop.TabIndex = 17;
            this.button_stop.Text = "stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_delay);
            this.Controls.Add(this.comboBox_stop);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.textBox_send);
            this.Controls.Add(this.richTextBox_receive);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_databits);
            this.Controls.Add(this.comboBox_baudrate);
            this.Controls.Add(this.comboBox_port);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_port;
        private System.Windows.Forms.ComboBox comboBox_baudrate;
        private System.Windows.Forms.TextBox textBox_databits;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox_receive;
        private System.Windows.Forms.TextBox textBox_send;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_stop;
        private System.Windows.Forms.TextBox textBox_delay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_stop;
    }
}

