namespace Wangfs763.Cards.ControlPanel
{
    partial class PortPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.chkDTR = new System.Windows.Forms.CheckBox();
            this.chkRTS = new System.Windows.Forms.CheckBox();
            this.chkBreak = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.comModals = new System.Windows.Forms.ComboBox();
            this.btnBindModal = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClearSum = new System.Windows.Forms.Button();
            this.txtSumRecive = new System.Windows.Forms.TextBox();
            this.txtSumSend = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.comEncod = new System.Windows.Forms.ComboBox();
            this.comNames = new System.Windows.Forms.ComboBox();
            this.comBaundRate = new System.Windows.Forms.ComboBox();
            this.comParity = new System.Windows.Forms.ComboBox();
            this.comDataBit = new System.Windows.Forms.ComboBox();
            this.comStopBit = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtRecive = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClearReciev = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAutoTime = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.chkAutoSend = new System.Windows.Forms.CheckBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnClearSend = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "数据位：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "停止位：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "校验位：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(132, 456);
            this.panel1.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.chkDTR);
            this.panel7.Controls.Add(this.chkRTS);
            this.panel7.Controls.Add(this.chkBreak);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(2, 366);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(128, 88);
            this.panel7.TabIndex = 3;
            // 
            // chkDTR
            // 
            this.chkDTR.AutoSize = true;
            this.chkDTR.Location = new System.Drawing.Point(21, 12);
            this.chkDTR.Name = "chkDTR";
            this.chkDTR.Size = new System.Drawing.Size(42, 16);
            this.chkDTR.TabIndex = 0;
            this.chkDTR.Text = "DTR";
            this.chkDTR.UseVisualStyleBackColor = true;
            this.chkDTR.CheckedChanged += new System.EventHandler(this.chkDTR_CheckedChanged);
            // 
            // chkRTS
            // 
            this.chkRTS.AutoSize = true;
            this.chkRTS.Location = new System.Drawing.Point(21, 34);
            this.chkRTS.Name = "chkRTS";
            this.chkRTS.Size = new System.Drawing.Size(42, 16);
            this.chkRTS.TabIndex = 1;
            this.chkRTS.Text = "RTS";
            this.chkRTS.UseVisualStyleBackColor = true;
            this.chkRTS.CheckedChanged += new System.EventHandler(this.chkRTS_CheckedChanged);
            // 
            // chkBreak
            // 
            this.chkBreak.AutoSize = true;
            this.chkBreak.Location = new System.Drawing.Point(21, 56);
            this.chkBreak.Name = "chkBreak";
            this.chkBreak.Size = new System.Drawing.Size(54, 16);
            this.chkBreak.TabIndex = 2;
            this.chkBreak.Text = "BREAK";
            this.chkBreak.UseVisualStyleBackColor = true;
            this.chkBreak.CheckedChanged += new System.EventHandler(this.chkBreak_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.comModals);
            this.panel6.Controls.Add(this.btnBindModal);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(2, 304);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(128, 62);
            this.panel6.TabIndex = 2;
            // 
            // comModals
            // 
            this.comModals.DisplayMember = "Name";
            this.comModals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comModals.FormattingEnabled = true;
            this.comModals.Location = new System.Drawing.Point(14, 34);
            this.comModals.Name = "comModals";
            this.comModals.Size = new System.Drawing.Size(102, 20);
            this.comModals.TabIndex = 1;
            this.comModals.SelectedIndexChanged += new System.EventHandler(this.comModals_SelectedIndexChanged);
            // 
            // btnBindModal
            // 
            this.btnBindModal.Location = new System.Drawing.Point(14, 6);
            this.btnBindModal.Name = "btnBindModal";
            this.btnBindModal.Size = new System.Drawing.Size(102, 23);
            this.btnBindModal.TabIndex = 0;
            this.btnBindModal.Text = "加载模型(&M)";
            this.btnBindModal.UseVisualStyleBackColor = true;
            this.btnBindModal.Click += new System.EventHandler(this.btnBindModal_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.btnClearSum);
            this.panel5.Controls.Add(this.txtSumRecive);
            this.panel5.Controls.Add(this.txtSumSend);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(2, 208);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(128, 96);
            this.panel5.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "发送";
            // 
            // btnClearSum
            // 
            this.btnClearSum.Location = new System.Drawing.Point(14, 62);
            this.btnClearSum.Name = "btnClearSum";
            this.btnClearSum.Size = new System.Drawing.Size(102, 27);
            this.btnClearSum.TabIndex = 2;
            this.btnClearSum.Text = "清空计数(&C)";
            this.btnClearSum.UseVisualStyleBackColor = true;
            this.btnClearSum.Click += new System.EventHandler(this.btnClearSum_Click);
            // 
            // txtSumRecive
            // 
            this.txtSumRecive.Location = new System.Drawing.Point(43, 34);
            this.txtSumRecive.Name = "txtSumRecive";
            this.txtSumRecive.ReadOnly = true;
            this.txtSumRecive.Size = new System.Drawing.Size(73, 21);
            this.txtSumRecive.TabIndex = 1;
            // 
            // txtSumSend
            // 
            this.txtSumSend.Location = new System.Drawing.Point(43, 6);
            this.txtSumSend.Name = "txtSumSend";
            this.txtSumSend.ReadOnly = true;
            this.txtSumSend.Size = new System.Drawing.Size(73, 21);
            this.txtSumSend.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "接收";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnOpen);
            this.panel4.Controls.Add(this.comEncod);
            this.panel4.Controls.Add(this.comNames);
            this.panel4.Controls.Add(this.comBaundRate);
            this.panel4.Controls.Add(this.comParity);
            this.panel4.Controls.Add(this.comDataBit);
            this.panel4.Controls.Add(this.comStopBit);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(128, 206);
            this.panel4.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(14, 174);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(102, 27);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "打开(&C)";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // comEncod
            // 
            this.comEncod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comEncod.FormattingEnabled = true;
            this.comEncod.Items.AddRange(new object[] {
            "Default",
            "ASCII",
            "Unicode",
            "UTF32",
            "UTF8"});
            this.comEncod.Location = new System.Drawing.Point(62, 146);
            this.comEncod.Name = "comEncod";
            this.comEncod.Size = new System.Drawing.Size(54, 20);
            this.comEncod.TabIndex = 5;
            this.comEncod.SelectedIndexChanged += new System.EventHandler(this.comEncod_SelectedIndexChanged);
            // 
            // comNames
            // 
            this.comNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comNames.FormattingEnabled = true;
            this.comNames.Location = new System.Drawing.Point(62, 6);
            this.comNames.Name = "comNames";
            this.comNames.Size = new System.Drawing.Size(54, 20);
            this.comNames.TabIndex = 0;
            this.comNames.SelectedIndexChanged += new System.EventHandler(this.comProperty_SelectedIndexChanged);
            // 
            // comBaundRate
            // 
            this.comBaundRate.FormattingEnabled = true;
            this.comBaundRate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.comBaundRate.Location = new System.Drawing.Point(62, 34);
            this.comBaundRate.Name = "comBaundRate";
            this.comBaundRate.Size = new System.Drawing.Size(54, 20);
            this.comBaundRate.TabIndex = 1;
            // 
            // comParity
            // 
            this.comParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comParity.FormattingEnabled = true;
            this.comParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.comParity.Location = new System.Drawing.Point(62, 118);
            this.comParity.Name = "comParity";
            this.comParity.Size = new System.Drawing.Size(54, 20);
            this.comParity.TabIndex = 4;
            this.comParity.SelectedIndexChanged += new System.EventHandler(this.comProperty_SelectedIndexChanged);
            // 
            // comDataBit
            // 
            this.comDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comDataBit.FormattingEnabled = true;
            this.comDataBit.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comDataBit.Location = new System.Drawing.Point(62, 62);
            this.comDataBit.Name = "comDataBit";
            this.comDataBit.Size = new System.Drawing.Size(54, 20);
            this.comDataBit.TabIndex = 2;
            this.comDataBit.SelectedIndexChanged += new System.EventHandler(this.comProperty_SelectedIndexChanged);
            // 
            // comStopBit
            // 
            this.comStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comStopBit.FormattingEnabled = true;
            this.comStopBit.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.comStopBit.Location = new System.Drawing.Point(62, 90);
            this.comStopBit.Name = "comStopBit";
            this.comStopBit.Size = new System.Drawing.Size(54, 20);
            this.comStopBit.TabIndex = 3;
            this.comStopBit.SelectedIndexChanged += new System.EventHandler(this.comProperty_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "字符编码";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(132, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.txtRecive);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.txtSend);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(531, 456);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 1;
            // 
            // txtRecive
            // 
            this.txtRecive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecive.Location = new System.Drawing.Point(3, 24);
            this.txtRecive.Multiline = true;
            this.txtRecive.Name = "txtRecive";
            this.txtRecive.ReadOnly = true;
            this.txtRecive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRecive.Size = new System.Drawing.Size(525, 263);
            this.txtRecive.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Location = new System.Drawing.Point(3, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(525, 21);
            this.label10.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBox3);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnClearReciev);
            this.panel3.Controls.Add(this.btnPause);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 287);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(525, 30);
            this.panel3.TabIndex = 0;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(15, 8);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(84, 16);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "16进制接收";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(230, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存(&A)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClearReciev
            // 
            this.btnClearReciev.Location = new System.Drawing.Point(167, 4);
            this.btnClearReciev.Name = "btnClearReciev";
            this.btnClearReciev.Size = new System.Drawing.Size(57, 23);
            this.btnClearReciev.TabIndex = 2;
            this.btnClearReciev.Text = "清空(&E)";
            this.btnClearReciev.UseVisualStyleBackColor = true;
            this.btnClearReciev.Click += new System.EventHandler(this.btnClearReciev_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(104, 4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(57, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "暂停(&P)";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // txtSend
            // 
            this.txtSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSend.Location = new System.Drawing.Point(3, 3);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSend.Size = new System.Drawing.Size(525, 91);
            this.txtSend.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtAutoTime);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.chkAutoSend);
            this.panel2.Controls.Add(this.btnRead);
            this.panel2.Controls.Add(this.btnClearSend);
            this.panel2.Controls.Add(this.btnSend);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 35);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "ms";
            // 
            // txtAutoTime
            // 
            this.txtAutoTime.Location = new System.Drawing.Point(391, 6);
            this.txtAutoTime.Name = "txtAutoTime";
            this.txtAutoTime.Size = new System.Drawing.Size(38, 21);
            this.txtAutoTime.TabIndex = 1;
            this.txtAutoTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutoTime_KeyPress);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(14, 10);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 16);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "16进制发送";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // chkAutoSend
            // 
            this.chkAutoSend.AutoSize = true;
            this.chkAutoSend.Location = new System.Drawing.Point(293, 10);
            this.chkAutoSend.Name = "chkAutoSend";
            this.chkAutoSend.Size = new System.Drawing.Size(108, 16);
            this.chkAutoSend.TabIndex = 0;
            this.chkAutoSend.Text = "自动发送间隔：";
            this.chkAutoSend.UseVisualStyleBackColor = true;
            this.chkAutoSend.CheckedChanged += new System.EventHandler(this.chkAutoSend_CheckedChanged);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(104, 6);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(57, 23);
            this.btnRead.TabIndex = 4;
            this.btnRead.Text = "文件(&O)";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnClearSend
            // 
            this.btnClearSend.Location = new System.Drawing.Point(167, 6);
            this.btnClearSend.Name = "btnClearSend";
            this.btnClearSend.Size = new System.Drawing.Size(57, 23);
            this.btnClearSend.TabIndex = 5;
            this.btnClearSend.Text = "清空(&X)";
            this.btnClearSend.UseVisualStyleBackColor = true;
            this.btnClearSend.Click += new System.EventHandler(this.btnClearSend_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(230, 6);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(57, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "发送(&S)";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // PortPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "PortPanel";
            this.Size = new System.Drawing.Size(663, 456);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox comParity;
        private System.Windows.Forms.ComboBox comStopBit;
        private System.Windows.Forms.ComboBox comDataBit;
        private System.Windows.Forms.ComboBox comBaundRate;
        private System.Windows.Forms.ComboBox comNames;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClearSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtAutoTime;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox chkAutoSend;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClearReciev;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.ComboBox comEncod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSumRecive;
        private System.Windows.Forms.TextBox txtSumSend;
        private System.Windows.Forms.Button btnClearSum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox chkBreak;
        private System.Windows.Forms.CheckBox chkRTS;
        private System.Windows.Forms.CheckBox chkDTR;
        private System.Windows.Forms.Button btnBindModal;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox comModals;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.TextBox txtRecive;
        private System.Windows.Forms.Label label10;
    }
}
