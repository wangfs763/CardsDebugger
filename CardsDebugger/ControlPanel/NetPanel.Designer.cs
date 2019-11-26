namespace Wangfs763.Cards.ControlPanel
{
    partial class NetPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnBindModal = new System.Windows.Forms.Button();
            this.comModals = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.coboxEncoding = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnClearRec = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClearSum = new System.Windows.Forms.Button();
            this.txtSumRecive = new System.Windows.Forms.TextBox();
            this.txtSumSend = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.ipEditBox1 = new Wangfs763.Cards.IPEditBox();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.txtRemotePort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ipEditBox2 = new Wangfs763.Cards.IPEditBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAutoTime = new System.Windows.Forms.TextBox();
            this.chkAutoSend = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClearSnd = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "协议：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 453);
            this.panel1.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.btnBindModal);
            this.panel7.Controls.Add(this.comModals);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 389);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(168, 64);
            this.panel7.TabIndex = 10;
            // 
            // btnBindModal
            // 
            this.btnBindModal.Location = new System.Drawing.Point(17, 5);
            this.btnBindModal.Name = "btnBindModal";
            this.btnBindModal.Size = new System.Drawing.Size(135, 23);
            this.btnBindModal.TabIndex = 7;
            this.btnBindModal.Text = "加载模型(&M)";
            this.btnBindModal.UseVisualStyleBackColor = true;
            this.btnBindModal.Click += new System.EventHandler(this.btnBindModal_Click);
            // 
            // comModals
            // 
            this.comModals.DisplayMember = "Name";
            this.comModals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comModals.FormattingEnabled = true;
            this.comModals.Location = new System.Drawing.Point(17, 36);
            this.comModals.Name = "comModals";
            this.comModals.Size = new System.Drawing.Size(135, 20);
            this.comModals.TabIndex = 8;
            this.comModals.SelectedIndexChanged += new System.EventHandler(this.comModals_SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.coboxEncoding);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.checkBox1);
            this.panel6.Controls.Add(this.btnClearRec);
            this.panel6.Controls.Add(this.btnPause);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 261);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(168, 128);
            this.panel6.TabIndex = 9;
            // 
            // coboxEncoding
            // 
            this.coboxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coboxEncoding.FormattingEnabled = true;
            this.coboxEncoding.Items.AddRange(new object[] {
            "ASCII",
            "BigEndianUnicode",
            "Default",
            "Unicode",
            "UTF-32",
            "UTF-8"});
            this.coboxEncoding.Location = new System.Drawing.Point(51, 97);
            this.coboxEncoding.Name = "coboxEncoding";
            this.coboxEncoding.Size = new System.Drawing.Size(101, 20);
            this.coboxEncoding.TabIndex = 8;
            this.coboxEncoding.SelectedIndexChanged += new System.EventHandler(this.coboxEncoding_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "编码：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 26);
            this.button1.TabIndex = 7;
            this.button1.Text = "保存(&A)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "16进制显示";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnClearRec
            // 
            this.btnClearRec.Location = new System.Drawing.Point(86, 33);
            this.btnClearRec.Name = "btnClearRec";
            this.btnClearRec.Size = new System.Drawing.Size(66, 26);
            this.btnClearRec.TabIndex = 7;
            this.btnClearRec.Text = "清空(&E)";
            this.btnClearRec.UseVisualStyleBackColor = true;
            this.btnClearRec.Click += new System.EventHandler(this.btnClearRec_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(17, 33);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(66, 26);
            this.btnPause.TabIndex = 7;
            this.btnPause.Text = "暂停(&P)";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.btnClearSum);
            this.panel3.Controls.Add(this.txtSumRecive);
            this.panel3.Controls.Add(this.txtSumSend);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 148);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(168, 113);
            this.panel3.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "发送";
            // 
            // btnClearSum
            // 
            this.btnClearSum.Location = new System.Drawing.Point(17, 70);
            this.btnClearSum.Name = "btnClearSum";
            this.btnClearSum.Size = new System.Drawing.Size(135, 30);
            this.btnClearSum.TabIndex = 7;
            this.btnClearSum.Text = "清空计数(&C)";
            this.btnClearSum.UseVisualStyleBackColor = true;
            this.btnClearSum.Click += new System.EventHandler(this.btnClearSum_Click);
            // 
            // txtSumRecive
            // 
            this.txtSumRecive.Location = new System.Drawing.Point(46, 40);
            this.txtSumRecive.Name = "txtSumRecive";
            this.txtSumRecive.ReadOnly = true;
            this.txtSumRecive.Size = new System.Drawing.Size(106, 21);
            this.txtSumRecive.TabIndex = 5;
            // 
            // txtSumSend
            // 
            this.txtSumSend.Location = new System.Drawing.Point(46, 10);
            this.txtSumSend.Name = "txtSumSend";
            this.txtSumSend.ReadOnly = true;
            this.txtSumSend.Size = new System.Drawing.Size(106, 21);
            this.txtSumSend.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "接收";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnConnect);
            this.panel2.Controls.Add(this.ipEditBox1);
            this.panel2.Controls.Add(this.txtLocalPort);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 148);
            this.panel2.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(17, 109);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(135, 30);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "连接(&N)";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // ipEditBox1
            // 
            this.ipEditBox1.IP = ((System.Net.IPAddress)(resources.GetObject("ipEditBox1.IP")));
            this.ipEditBox1.Location = new System.Drawing.Point(51, 43);
            this.ipEditBox1.Name = "ipEditBox1";
            this.ipEditBox1.Size = new System.Drawing.Size(101, 21);
            this.ipEditBox1.TabIndex = 3;
            this.ipEditBox1.Text = "127.0.0.1";
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Location = new System.Drawing.Point(51, 76);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(101, 21);
            this.txtLocalPort.TabIndex = 2;
            this.txtLocalPort.Text = "9264";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "UDP",
            "TCP Client",
            "TCP Server"});
            this.comboBox1.Location = new System.Drawing.Point(51, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(101, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "端口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "IP：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(168, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.txtReceive);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.txtSend);
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(522, 453);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtReceive
            // 
            this.txtReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceive.Location = new System.Drawing.Point(3, 3);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReceive.Size = new System.Drawing.Size(516, 262);
            this.txtReceive.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.comboBox2);
            this.panel4.Controls.Add(this.txtRemotePort);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.ipEditBox2);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 265);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(516, 36);
            this.panel4.TabIndex = 1;
            this.panel4.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(67, 9);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(130, 20);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
            // 
            // txtRemotePort
            // 
            this.txtRemotePort.Location = new System.Drawing.Point(264, 7);
            this.txtRemotePort.Name = "txtRemotePort";
            this.txtRemotePort.Size = new System.Drawing.Size(101, 21);
            this.txtRemotePort.TabIndex = 8;
            this.txtRemotePort.Text = "9264";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(203, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "远端端口：";
            // 
            // ipEditBox2
            // 
            this.ipEditBox2.IP = ((System.Net.IPAddress)(resources.GetObject("ipEditBox2.IP")));
            this.ipEditBox2.Location = new System.Drawing.Point(67, 7);
            this.ipEditBox2.Name = "ipEditBox2";
            this.ipEditBox2.Size = new System.Drawing.Size(101, 21);
            this.ipEditBox2.TabIndex = 6;
            this.ipEditBox2.Text = "127.0.0.1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "远端IP：";
            // 
            // txtSend
            // 
            this.txtSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSend.Location = new System.Drawing.Point(3, 3);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSend.Size = new System.Drawing.Size(516, 103);
            this.txtSend.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.txtAutoTime);
            this.panel5.Controls.Add(this.chkAutoSend);
            this.panel5.Controls.Add(this.checkBox2);
            this.panel5.Controls.Add(this.btnSend);
            this.panel5.Controls.Add(this.btnClearSnd);
            this.panel5.Controls.Add(this.btnOpen);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 106);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(516, 36);
            this.panel5.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(420, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "ms";
            // 
            // txtAutoTime
            // 
            this.txtAutoTime.Location = new System.Drawing.Point(382, 6);
            this.txtAutoTime.Name = "txtAutoTime";
            this.txtAutoTime.Size = new System.Drawing.Size(38, 21);
            this.txtAutoTime.TabIndex = 9;
            this.txtAutoTime.Text = "500";
            this.txtAutoTime.TextChanged += new System.EventHandler(this.txtAutoTime_TextChanged);
            this.txtAutoTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutoTime_KeyPress);
            // 
            // chkAutoSend
            // 
            this.chkAutoSend.AutoSize = true;
            this.chkAutoSend.Location = new System.Drawing.Point(285, 10);
            this.chkAutoSend.Name = "chkAutoSend";
            this.chkAutoSend.Size = new System.Drawing.Size(108, 16);
            this.chkAutoSend.TabIndex = 8;
            this.chkAutoSend.Text = "自动发送间隔：";
            this.chkAutoSend.UseVisualStyleBackColor = true;
            this.chkAutoSend.CheckedChanged += new System.EventHandler(this.chkAutoSend_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 10);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 16);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "16进制数据";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(221, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(58, 26);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "发送(&S)";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClearSnd
            // 
            this.btnClearSnd.Location = new System.Drawing.Point(157, 4);
            this.btnClearSnd.Name = "btnClearSnd";
            this.btnClearSnd.Size = new System.Drawing.Size(58, 26);
            this.btnClearSnd.TabIndex = 7;
            this.btnClearSnd.Text = "清空(&X)";
            this.btnClearSnd.UseVisualStyleBackColor = true;
            this.btnClearSnd.Click += new System.EventHandler(this.btnClearSnd_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(93, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(58, 26);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "文件(&O)";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // NetPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "NetPanel";
            this.Size = new System.Drawing.Size(690, 453);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtLocalPort;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private IPEditBox ipEditBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClearSum;
        private System.Windows.Forms.TextBox txtSumRecive;
        private System.Windows.Forms.TextBox txtSumSend;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnClearRec;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button btnClearSnd;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAutoTime;
        private System.Windows.Forms.CheckBox chkAutoSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comModals;
        private System.Windows.Forms.Button btnBindModal;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox coboxEncoding;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtRemotePort;
        private System.Windows.Forms.Label label7;
        private IPEditBox ipEditBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}
