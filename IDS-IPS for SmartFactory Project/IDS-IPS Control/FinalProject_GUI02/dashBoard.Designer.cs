namespace FinalProject_GUI02
{
    partial class dashBoard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreateRule = new System.Windows.Forms.Button();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnThreats = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.Authority = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Theme = new System.Windows.Forms.Label();
            this.TrafficGraph = new LiveCharts.WinForms.CartesianChart();
            this.label6 = new System.Windows.Forms.Label();
            this.Dash_Panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Dashboard_Panel = new System.Windows.Forms.Panel();
            this.btnIPS = new System.Windows.Forms.Button();
            this.btnIDS = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Threats_Panel = new System.Windows.Forms.Panel();
            this.btnIpsLog = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnIdsLog = new System.Windows.Forms.Button();
            this.dtThreat = new System.Windows.Forms.DataGridView();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.CreateRule_Panel = new System.Windows.Forms.Panel();
            this.createSid = new System.Windows.Forms.Button();
            this.btnApply_Server = new System.Windows.Forms.Button();
            this.btnAddRule_Server = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.option = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.value = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.textBox_candiRule = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboProtocol = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAction = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_sIp = new System.Windows.Forms.TextBox();
            this.textBox_sPort = new System.Windows.Forms.TextBox();
            this.cboDirection = new System.Windows.Forms.ComboBox();
            this.textBox_dIp = new System.Windows.Forms.TextBox();
            this.textBox_dPort = new System.Windows.Forms.TextBox();
            this.Users_Panel = new System.Windows.Forms.Panel();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnRevoke = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.userGrid = new System.Windows.Forms.DataGridView();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.createGrid = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Dash_Panel1.SuspendLayout();
            this.Dashboard_Panel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.Threats_Panel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtThreat)).BeginInit();
            this.panel10.SuspendLayout();
            this.CreateRule_Panel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.Users_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.createGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.btnCreateRule);
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.btnUsers);
            this.panel1.Controls.Add(this.btnThreats);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 641);
            this.panel1.TabIndex = 0;
            // 
            // btnCreateRule
            // 
            this.btnCreateRule.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnCreateRule.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateRule.FlatAppearance.BorderSize = 0;
            this.btnCreateRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateRule.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateRule.ForeColor = System.Drawing.Color.LightCoral;
            this.btnCreateRule.Image = global::FinalProject_GUI02.Properties.Resources.settings;
            this.btnCreateRule.Location = new System.Drawing.Point(0, 294);
            this.btnCreateRule.Name = "btnCreateRule";
            this.btnCreateRule.Size = new System.Drawing.Size(212, 50);
            this.btnCreateRule.TabIndex = 1;
            this.btnCreateRule.Text = "Create Rule";
            this.btnCreateRule.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCreateRule.UseVisualStyleBackColor = true;
            this.btnCreateRule.Click += new System.EventHandler(this.btnCreateRule_Click);
            this.btnCreateRule.Leave += new System.EventHandler(this.btnCreateRule_Leave);
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 144);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(3, 100);
            this.pnlNav.TabIndex = 4;
            // 
            // btnUsers
            // 
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnUsers.Image = global::FinalProject_GUI02.Properties.Resources.Conact;
            this.btnUsers.Location = new System.Drawing.Point(0, 244);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(212, 50);
            this.btnUsers.TabIndex = 1;
            this.btnUsers.Text = "Users";
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            this.btnUsers.Leave += new System.EventHandler(this.btnUsers_Leave);
            // 
            // btnThreats
            // 
            this.btnThreats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThreats.FlatAppearance.BorderSize = 0;
            this.btnThreats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThreats.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThreats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnThreats.Image = global::FinalProject_GUI02.Properties.Resources.diagram;
            this.btnThreats.Location = new System.Drawing.Point(0, 194);
            this.btnThreats.Name = "btnThreats";
            this.btnThreats.Size = new System.Drawing.Size(212, 50);
            this.btnThreats.TabIndex = 1;
            this.btnThreats.Text = "Threats";
            this.btnThreats.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnThreats.UseVisualStyleBackColor = true;
            this.btnThreats.Click += new System.EventHandler(this.btnThreats_Click);
            this.btnThreats.Leave += new System.EventHandler(this.btnThreats_Leave);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnDashboard.Image = global::FinalProject_GUI02.Properties.Resources.home;
            this.btnDashboard.Location = new System.Drawing.Point(0, 144);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(212, 50);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            this.btnDashboard.Leave += new System.EventHandler(this.btnDashboard_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.Authority);
            this.panel2.Controls.Add(this.UserName);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 144);
            this.panel2.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogout.Location = new System.Drawing.Point(144, 88);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(69, 38);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Authority
            // 
            this.Authority.AutoSize = true;
            this.Authority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Authority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(161)))), ((int)(((byte)(178)))));
            this.Authority.Location = new System.Drawing.Point(53, 113);
            this.Authority.Name = "Authority";
            this.Authority.Size = new System.Drawing.Size(77, 13);
            this.Authority.TabIndex = 2;
            this.Authority.Text = "No Authority";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.UserName.Location = new System.Drawing.Point(57, 88);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(81, 16);
            this.UserName.TabIndex = 1;
            this.UserName.Text = "UserName";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FinalProject_GUI02.Properties.Resources.Untitled_11;
            this.pictureBox1.Location = new System.Drawing.Point(69, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Theme
            // 
            this.Theme.AutoSize = true;
            this.Theme.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Theme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.Theme.Location = new System.Drawing.Point(256, 32);
            this.Theme.Name = "Theme";
            this.Theme.Size = new System.Drawing.Size(162, 32);
            this.Theme.TabIndex = 4;
            this.Theme.Text = "Dashboard";
            // 
            // TrafficGraph
            // 
            this.TrafficGraph.Location = new System.Drawing.Point(14, 39);
            this.TrafficGraph.Name = "TrafficGraph";
            this.TrafficGraph.Size = new System.Drawing.Size(801, 210);
            this.TrafficGraph.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 17F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 31);
            this.label6.TabIndex = 12;
            this.label6.Text = "트래픽/차단율";
            // 
            // Dash_Panel1
            // 
            this.Dash_Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.Dash_Panel1.Controls.Add(this.label6);
            this.Dash_Panel1.Controls.Add(this.TrafficGraph);
            this.Dash_Panel1.Location = new System.Drawing.Point(219, 11);
            this.Dash_Panel1.Name = "Dash_Panel1";
            this.Dash_Panel1.Size = new System.Drawing.Size(834, 249);
            this.Dash_Panel1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1247, 32);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dashboard_Panel
            // 
            this.Dashboard_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Dashboard_Panel.Controls.Add(this.btnIPS);
            this.Dashboard_Panel.Controls.Add(this.btnIDS);
            this.Dashboard_Panel.Controls.Add(this.panel4);
            this.Dashboard_Panel.Controls.Add(this.Dash_Panel1);
            this.Dashboard_Panel.Location = new System.Drawing.Point(229, 61);
            this.Dashboard_Panel.Name = "Dashboard_Panel";
            this.Dashboard_Panel.Size = new System.Drawing.Size(1056, 571);
            this.Dashboard_Panel.TabIndex = 15;
            // 
            // btnIPS
            // 
            this.btnIPS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnIPS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnIPS.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnIPS.FlatAppearance.BorderSize = 0;
            this.btnIPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIPS.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnIPS.Location = new System.Drawing.Point(22, 144);
            this.btnIPS.Name = "btnIPS";
            this.btnIPS.Size = new System.Drawing.Size(191, 116);
            this.btnIPS.TabIndex = 15;
            this.btnIPS.Text = "IPS MODE";
            this.btnIPS.UseVisualStyleBackColor = false;
            this.btnIPS.Click += new System.EventHandler(this.btnIPS_Click);
            // 
            // btnIDS
            // 
            this.btnIDS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnIDS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnIDS.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnIDS.FlatAppearance.BorderSize = 0;
            this.btnIDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIDS.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnIDS.Location = new System.Drawing.Point(22, 11);
            this.btnIDS.Name = "btnIDS";
            this.btnIDS.Size = new System.Drawing.Size(191, 115);
            this.btnIDS.TabIndex = 3;
            this.btnIDS.Text = "IDS MODE";
            this.btnIDS.UseVisualStyleBackColor = false;
            this.btnIDS.Click += new System.EventHandler(this.btnIDS_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.richTextBox1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(23, 266);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1030, 286);
            this.panel4.TabIndex = 14;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(15, 56);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(996, 219);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 17F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 31);
            this.label2.TabIndex = 13;
            this.label2.Text = "실시간 로그";
            // 
            // Threats_Panel
            // 
            this.Threats_Panel.Controls.Add(this.btnIpsLog);
            this.Threats_Panel.Controls.Add(this.panel3);
            this.Threats_Panel.Controls.Add(this.btnIdsLog);
            this.Threats_Panel.Controls.Add(this.dtThreat);
            this.Threats_Panel.Controls.Add(this.panel10);
            this.Threats_Panel.Location = new System.Drawing.Point(229, 69);
            this.Threats_Panel.Name = "Threats_Panel";
            this.Threats_Panel.Size = new System.Drawing.Size(1056, 560);
            this.Threats_Panel.TabIndex = 16;
            // 
            // btnIpsLog
            // 
            this.btnIpsLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(72)))));
            this.btnIpsLog.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIpsLog.Location = new System.Drawing.Point(891, 85);
            this.btnIpsLog.Name = "btnIpsLog";
            this.btnIpsLog.Size = new System.Drawing.Size(156, 62);
            this.btnIpsLog.TabIndex = 12;
            this.btnIpsLog.Text = "IPS 로그 새로고침";
            this.btnIpsLog.UseVisualStyleBackColor = false;
            this.btnIpsLog.Click += new System.EventHandler(this.btnIpsLog_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(266, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(619, 51);
            this.panel3.TabIndex = 11;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.label22.Location = new System.Drawing.Point(360, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(173, 31);
            this.label22.TabIndex = 5;
            this.label22.Text = "최다 공격 횟수 :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(539, 15);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(24, 25);
            this.label21.TabIndex = 4;
            this.label21.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(215, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 25);
            this.label20.TabIndex = 3;
            this.label20.Text = "1.1.1.1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(17, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 31);
            this.label5.TabIndex = 2;
            this.label5.Text = "최다 공격 IP :";
            // 
            // btnIdsLog
            // 
            this.btnIdsLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(72)))));
            this.btnIdsLog.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnIdsLog.Location = new System.Drawing.Point(891, 19);
            this.btnIdsLog.Name = "btnIdsLog";
            this.btnIdsLog.Size = new System.Drawing.Size(156, 62);
            this.btnIdsLog.TabIndex = 10;
            this.btnIdsLog.Text = "IDS 로그 새로고침";
            this.btnIdsLog.UseVisualStyleBackColor = false;
            this.btnIdsLog.Click += new System.EventHandler(this.btnIdsLog_Click);
            // 
            // dtThreat
            // 
            this.dtThreat.AllowUserToAddRows = false;
            this.dtThreat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtThreat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtThreat.Location = new System.Drawing.Point(22, 153);
            this.dtThreat.Name = "dtThreat";
            this.dtThreat.RowHeadersVisible = false;
            this.dtThreat.RowTemplate.Height = 23;
            this.dtThreat.Size = new System.Drawing.Size(1025, 390);
            this.dtThreat.TabIndex = 8;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel10.Controls.Add(this.label28);
            this.panel10.Controls.Add(this.label29);
            this.panel10.Location = new System.Drawing.Point(22, 24);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(255, 51);
            this.panel10.TabIndex = 5;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(255)))));
            this.label28.Location = new System.Drawing.Point(4, 7);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(115, 31);
            this.label28.TabIndex = 0;
            this.label28.Text = "발생건수 :";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(125, 14);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(24, 25);
            this.label29.TabIndex = 1;
            this.label29.Text = "0";
            // 
            // CreateRule_Panel
            // 
            this.CreateRule_Panel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CreateRule_Panel.Controls.Add(this.createSid);
            this.CreateRule_Panel.Controls.Add(this.btnApply_Server);
            this.CreateRule_Panel.Controls.Add(this.btnAddRule_Server);
            this.CreateRule_Panel.Controls.Add(this.label24);
            this.CreateRule_Panel.Controls.Add(this.label30);
            this.CreateRule_Panel.Controls.Add(this.label15);
            this.CreateRule_Panel.Controls.Add(this.label16);
            this.CreateRule_Panel.Controls.Add(this.label14);
            this.CreateRule_Panel.Controls.Add(this.label13);
            this.CreateRule_Panel.Controls.Add(this.groupBox2);
            this.CreateRule_Panel.Controls.Add(this.textBox_candiRule);
            this.CreateRule_Panel.Controls.Add(this.comboBox1);
            this.CreateRule_Panel.Controls.Add(this.label12);
            this.CreateRule_Panel.Controls.Add(this.groupBox1);
            this.CreateRule_Panel.Location = new System.Drawing.Point(229, 70);
            this.CreateRule_Panel.Name = "CreateRule_Panel";
            this.CreateRule_Panel.Size = new System.Drawing.Size(1112, 565);
            this.CreateRule_Panel.TabIndex = 9;
            // 
            // createSid
            // 
            this.createSid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.createSid.Location = new System.Drawing.Point(869, 253);
            this.createSid.Name = "createSid";
            this.createSid.Size = new System.Drawing.Size(131, 45);
            this.createSid.TabIndex = 13;
            this.createSid.Text = "고유번호 생성";
            this.createSid.UseVisualStyleBackColor = true;
            this.createSid.Click += new System.EventHandler(this.createSid_Click);
            // 
            // btnApply_Server
            // 
            this.btnApply_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply_Server.Location = new System.Drawing.Point(869, 366);
            this.btnApply_Server.Name = "btnApply_Server";
            this.btnApply_Server.Size = new System.Drawing.Size(131, 44);
            this.btnApply_Server.TabIndex = 12;
            this.btnApply_Server.Text = "서버 적용";
            this.btnApply_Server.UseVisualStyleBackColor = true;
            this.btnApply_Server.Click += new System.EventHandler(this.btnApply_Server_Click);
            // 
            // btnAddRule_Server
            // 
            this.btnAddRule_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRule_Server.Location = new System.Drawing.Point(869, 309);
            this.btnAddRule_Server.Name = "btnAddRule_Server";
            this.btnAddRule_Server.Size = new System.Drawing.Size(131, 44);
            this.btnAddRule_Server.TabIndex = 11;
            this.btnAddRule_Server.Text = "서버 룰 추가";
            this.btnAddRule_Server.UseVisualStyleBackColor = true;
            this.btnAddRule_Server.Click += new System.EventHandler(this.btnAddRule_Server_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.SystemColors.Control;
            this.label24.Location = new System.Drawing.Point(889, 206);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 12);
            this.label24.TabIndex = 10;
            this.label24.Text = "Running";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.SystemColors.Control;
            this.label30.Location = new System.Drawing.Point(826, 206);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(56, 12);
            this.label30.TabIndex = 9;
            this.label30.Text = "Status :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(889, 182);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 12);
            this.label15.TabIndex = 8;
            this.label15.Text = "RIP-IPS";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.Control;
            this.label16.Location = new System.Drawing.Point(826, 182);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 12);
            this.label16.TabIndex = 7;
            this.label16.Text = "Type :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.Control;
            this.label14.Location = new System.Drawing.Point(889, 161);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "192.168.0.13";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(826, 161);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 12);
            this.label13.TabIndex = 5;
            this.label13.Text = "Server :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeList1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Location = new System.Drawing.Point(446, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 319);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.option,
            this.value});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(3, 17);
            this.treeList1.Name = "treeList1";
            this.treeList1.BeginUnboundLoad();
            this.treeList1.AppendNode(new object[] {
            "Meta Data",
            null}, -1);
            this.treeList1.AppendNode(new object[] {
            "msg",
            null}, 0);
            this.treeList1.AppendNode(new object[] {
            "priority",
            null}, 0);
            this.treeList1.AppendNode(new object[] {
            "rev",
            null}, 0);
            this.treeList1.AppendNode(new object[] {
            "payload",
            null}, -1);
            this.treeList1.AppendNode(new object[] {
            "content",
            null}, 4);
            this.treeList1.AppendNode(new object[] {
            "nocase",
            null}, 5);
            this.treeList1.AppendNode(new object[] {
            "rawbytes",
            null}, 5);
            this.treeList1.AppendNode(new object[] {
            "depth",
            null}, 5);
            this.treeList1.AppendNode(new object[] {
            "offset",
            null}, 5);
            this.treeList1.AppendNode(new object[] {
            "distance",
            null}, 5);
            this.treeList1.AppendNode(new object[] {
            "within",
            null}, 5);
            this.treeList1.AppendNode(new object[] {
            "isdataat",
            null}, 4);
            this.treeList1.AppendNode(new object[] {
            "pcre",
            null}, 4);
            this.treeList1.AppendNode(new object[] {
            "byte_test",
            null}, 4);
            this.treeList1.AppendNode(new object[] {
            "byte_jump",
            null}, 4);
            this.treeList1.AppendNode(new object[] {
            "Non-Payload",
            null}, -1);
            this.treeList1.AppendNode(new object[] {
            "ttl",
            null}, 16);
            this.treeList1.AppendNode(new object[] {
            "iType",
            null}, 16);
            this.treeList1.AppendNode(new object[] {
            "iCode",
            null}, 16);
            this.treeList1.AppendNode(new object[] {
            "icmp_id",
            null}, 16);
            this.treeList1.AppendNode(new object[] {
            "icmp_seq",
            null}, 16);
            this.treeList1.EndUnboundLoad();
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.Size = new System.Drawing.Size(319, 299);
            this.treeList1.TabIndex = 0;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // option
            // 
            this.option.Caption = "option";
            this.option.FieldName = "option";
            this.option.Name = "option";
            this.option.Visible = true;
            this.option.VisibleIndex = 0;
            // 
            // value
            // 
            this.value.Caption = "value";
            this.value.FieldName = "value";
            this.value.Name = "value";
            this.value.Visible = true;
            this.value.VisibleIndex = 1;
            // 
            // textBox_candiRule
            // 
            this.textBox_candiRule.Location = new System.Drawing.Point(64, 441);
            this.textBox_candiRule.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_candiRule.Multiline = true;
            this.textBox_candiRule.Name = "textBox_candiRule";
            this.textBox_candiRule.Size = new System.Drawing.Size(936, 99);
            this.textBox_candiRule.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(76, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(309, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.Location = new System.Drawing.Point(76, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "<스마트팩토리 유해 모델>";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(76, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 325);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Header";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.1194F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.8806F));
            this.tableLayoutPanel1.Controls.Add(this.cboProtocol, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboAction, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBox_sIp, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_sPort, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboDirection, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_dIp, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox_dPort, 1, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(316, 298);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cboProtocol
            // 
            this.cboProtocol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboProtocol.FormattingEnabled = true;
            this.cboProtocol.Items.AddRange(new object[] {
            "tcp",
            "udp",
            "icmp",
            "ip"});
            this.cboProtocol.Location = new System.Drawing.Point(94, 53);
            this.cboProtocol.Name = "cboProtocol";
            this.cboProtocol.Size = new System.Drawing.Size(210, 20);
            this.cboProtocol.TabIndex = 7;
            this.cboProtocol.SelectedIndexChanged += new System.EventHandler(this.cboProtocol_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(3, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Protocol";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Action";
            // 
            // cboAction
            // 
            this.cboAction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboAction.FormattingEnabled = true;
            this.cboAction.Items.AddRange(new object[] {
            "alert",
            "drop"});
            this.cboAction.Location = new System.Drawing.Point(94, 11);
            this.cboAction.Name = "cboAction";
            this.cboAction.Size = new System.Drawing.Size(210, 20);
            this.cboAction.TabIndex = 1;
            this.cboAction.SelectedIndexChanged += new System.EventHandler(this.cboAction_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(3, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "Src IP";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(3, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "Src Port";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(3, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "Direction";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(3, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "Dst IP";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(3, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "Dst Port";
            // 
            // textBox_sIp
            // 
            this.textBox_sIp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_sIp.Font = new System.Drawing.Font("맑은 고딕 Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_sIp.Location = new System.Drawing.Point(94, 93);
            this.textBox_sIp.Name = "textBox_sIp";
            this.textBox_sIp.Size = new System.Drawing.Size(209, 23);
            this.textBox_sIp.TabIndex = 8;
            this.textBox_sIp.Text = "any";
            this.textBox_sIp.TextChanged += new System.EventHandler(this.textBox_sIp_TextChanged);
            // 
            // textBox_sPort
            // 
            this.textBox_sPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_sPort.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_sPort.Location = new System.Drawing.Point(94, 135);
            this.textBox_sPort.Name = "textBox_sPort";
            this.textBox_sPort.Size = new System.Drawing.Size(209, 23);
            this.textBox_sPort.TabIndex = 8;
            this.textBox_sPort.Text = "any";
            this.textBox_sPort.TextChanged += new System.EventHandler(this.textBox_sPort_TextChanged);
            // 
            // cboDirection
            // 
            this.cboDirection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboDirection.FormattingEnabled = true;
            this.cboDirection.Items.AddRange(new object[] {
            "->",
            "<-",
            "<>"});
            this.cboDirection.Location = new System.Drawing.Point(94, 179);
            this.cboDirection.Name = "cboDirection";
            this.cboDirection.Size = new System.Drawing.Size(210, 20);
            this.cboDirection.TabIndex = 7;
            this.cboDirection.SelectedIndexChanged += new System.EventHandler(this.cboDirection_SelectedIndexChanged);
            // 
            // textBox_dIp
            // 
            this.textBox_dIp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_dIp.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_dIp.Location = new System.Drawing.Point(94, 219);
            this.textBox_dIp.Name = "textBox_dIp";
            this.textBox_dIp.Size = new System.Drawing.Size(209, 23);
            this.textBox_dIp.TabIndex = 8;
            this.textBox_dIp.Text = "any";
            this.textBox_dIp.TextChanged += new System.EventHandler(this.textBox_dIp_TextChanged);
            // 
            // textBox_dPort
            // 
            this.textBox_dPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_dPort.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_dPort.Location = new System.Drawing.Point(94, 263);
            this.textBox_dPort.Name = "textBox_dPort";
            this.textBox_dPort.Size = new System.Drawing.Size(209, 23);
            this.textBox_dPort.TabIndex = 8;
            this.textBox_dPort.Text = "any";
            this.textBox_dPort.TextChanged += new System.EventHandler(this.textBox_dPort_TextChanged);
            // 
            // Users_Panel
            // 
            this.Users_Panel.Controls.Add(this.btnDeleteUser);
            this.Users_Panel.Controls.Add(this.btnAccept);
            this.Users_Panel.Controls.Add(this.btnRevoke);
            this.Users_Panel.Controls.Add(this.btnUser);
            this.Users_Panel.Controls.Add(this.btnAdmin);
            this.Users_Panel.Controls.Add(this.txtAuthor);
            this.Users_Panel.Controls.Add(this.label18);
            this.Users_Panel.Controls.Add(this.userGrid);
            this.Users_Panel.Controls.Add(this.label17);
            this.Users_Panel.Controls.Add(this.label1);
            this.Users_Panel.Controls.Add(this.createGrid);
            this.Users_Panel.Location = new System.Drawing.Point(229, 67);
            this.Users_Panel.Name = "Users_Panel";
            this.Users_Panel.Size = new System.Drawing.Size(1101, 961);
            this.Users_Panel.TabIndex = 21;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDeleteUser.FlatAppearance.BorderSize = 0;
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
            this.btnDeleteUser.Location = new System.Drawing.Point(855, 252);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(145, 45);
            this.btnDeleteUser.TabIndex = 25;
            this.btnDeleteUser.Text = "회원 삭제";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(855, 182);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(145, 45);
            this.btnAccept.TabIndex = 24;
            this.btnAccept.Text = "가입 승인";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnRevoke
            // 
            this.btnRevoke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRevoke.FlatAppearance.BorderSize = 0;
            this.btnRevoke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevoke.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevoke.ForeColor = System.Drawing.Color.White;
            this.btnRevoke.Location = new System.Drawing.Point(666, 182);
            this.btnRevoke.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRevoke.Name = "btnRevoke";
            this.btnRevoke.Size = new System.Drawing.Size(145, 45);
            this.btnRevoke.TabIndex = 23;
            this.btnRevoke.Text = "권환 회수";
            this.btnRevoke.UseVisualStyleBackColor = false;
            this.btnRevoke.Click += new System.EventHandler(this.btnRevoke_Click_1);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Location = new System.Drawing.Point(855, 114);
            this.btnUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(145, 45);
            this.btnUser.TabIndex = 22;
            this.btnUser.Text = "사용자 권한 부여";
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click_1);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.Location = new System.Drawing.Point(666, 114);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(145, 45);
            this.btnAdmin.TabIndex = 21;
            this.btnAdmin.Text = "관리자 권한 부여";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click_1);
            // 
            // txtAuthor
            // 
            this.txtAuthor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.txtAuthor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtAuthor.Location = new System.Drawing.Point(662, 67);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(338, 24);
            this.txtAuthor.TabIndex = 20;
            this.txtAuthor.Text = "ID를 입력하세요.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.Info;
            this.label18.Location = new System.Drawing.Point(668, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 31);
            this.label18.TabIndex = 19;
            this.label18.Text = "권한 설정";
            // 
            // userGrid
            // 
            this.userGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userGrid.Location = new System.Drawing.Point(23, 312);
            this.userGrid.Name = "userGrid";
            this.userGrid.RowHeadersVisible = false;
            this.userGrid.RowTemplate.Height = 23;
            this.userGrid.Size = new System.Drawing.Size(588, 251);
            this.userGrid.TabIndex = 3;
            this.userGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.userGrid_CellMouseClick);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.Info;
            this.label17.Location = new System.Drawing.Point(27, 278);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 31);
            this.label17.TabIndex = 2;
            this.label17.Text = "유저 목록";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "회원가입 신청목록";
            // 
            // createGrid
            // 
            this.createGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.createGrid.Location = new System.Drawing.Point(22, 68);
            this.createGrid.Name = "createGrid";
            this.createGrid.RowHeadersVisible = false;
            this.createGrid.RowTemplate.Height = 23;
            this.createGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.createGrid.Size = new System.Drawing.Size(589, 196);
            this.createGrid.TabIndex = 0;
            this.createGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.createGrid_CellMouseClick);
            // 
            // dashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1317, 641);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Theme);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Dashboard_Panel);
            this.Controls.Add(this.CreateRule_Panel);
            this.Controls.Add(this.Users_Panel);
            this.Controls.Add(this.Threats_Panel);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Dash_Panel1.ResumeLayout(false);
            this.Dash_Panel1.PerformLayout();
            this.Dashboard_Panel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.Threats_Panel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtThreat)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.CreateRule_Panel.ResumeLayout(false);
            this.CreateRule_Panel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Users_Panel.ResumeLayout(false);
            this.Users_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.createGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Button btnDashboard;
        public System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label Authority;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnThreats;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Label Theme;
        private LiveCharts.WinForms.CartesianChart TrafficGraph;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel Dash_Panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel Dashboard_Panel;
        private System.Windows.Forms.Panel Threats_Panel;
        private System.Windows.Forms.DataGridView dtThreat;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel Users_Panel;
        private System.Windows.Forms.DataGridView userGrid;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView createGrid;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateRule;
        private System.Windows.Forms.Panel CreateRule_Panel;
        private System.Windows.Forms.Button btnIdsLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private System.Windows.Forms.TextBox textBox_candiRule;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cboProtocol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboAction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_sIp;
        private System.Windows.Forms.TextBox textBox_sPort;
        private System.Windows.Forms.ComboBox cboDirection;
        private System.Windows.Forms.TextBox textBox_dIp;
        private System.Windows.Forms.TextBox textBox_dPort;
        private DevExpress.XtraTreeList.Columns.TreeListColumn option;
        private DevExpress.XtraTreeList.Columns.TreeListColumn value;
        private System.Windows.Forms.Button btnApply_Server;
        private System.Windows.Forms.Button btnAddRule_Server;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnRevoke;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button createSid;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.Button btnIPS;
        public System.Windows.Forms.Button btnIDS;
        private System.Windows.Forms.Button btnIpsLog;
    }
}

