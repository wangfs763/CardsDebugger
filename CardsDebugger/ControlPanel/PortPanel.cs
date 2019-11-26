using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Wangfs763.Cards.Models;

namespace Wangfs763.Cards.ControlPanel
{
    [ToolboxItem(false)]
    public partial class PortPanel : UserControl
    {
        public static string[] PortNames { get; private set; }
        static string header;
        bool status;
        Mutex m_Mutex;

        static PortPanel() { for (int i = 0; i < 128; i++) header += i.ToString("X2") + " "; }

        SerialPort m_Port;
        private Thread m_Send;
        private bool m_Pause;
        private SerialPortModal m_Model;

        public PortPanel(string[] ports)
        {
            InitializeComponent(); 
            this.txtAutoTime.Text = "500";
            this.comNames.Items.AddRange(PortNames = ports);
            this.comEncod.SelectedIndex =
            this.comBaundRate.SelectedIndex = 1;
            this.comDataBit.SelectedIndex = 4;
            this.txtSumRecive.Text = this.txtSumSend.Text = "0";
            this.comStopBit.SelectedIndex = 0;
            this.comParity.SelectedIndex = 0;
            this.Dock = DockStyle.Fill;
            this.checkBox2.Checked = this.checkBox3.Checked = true;
            this.txtAutoTime.TextChanged += new EventHandler(txtAutoTime_TextChanged);
            this.comModals.DataSource = this.m_Models;
            CardsDebugger.ComChanged += this.ComChanged;
            this.label10.Text = header;
            this.m_Mutex = new Mutex();
        }

        // 修改自动发送周期
        void txtAutoTime_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtAutoTime.Text)) return;
            int i = int.Parse(this.txtAutoTime.Text);
            if (i > 1) this.inter = i;
        }

        // 打开或关闭串口
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.comNames.Text)) return;
            if (this.status = !this.status)
            {
                this.m_Port = new SerialPort(this.comNames.Text);
                this.m_Port.BaudRate = int.Parse(this.comBaundRate.Text);
                this.m_Port.DataBits = int.Parse(this.comDataBit.Text);
                this.m_Port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), this.comStopBit.Text);
                this.m_Port.Parity = (Parity)Enum.Parse(typeof(Parity), this.comParity.Text);
                this.m_Port.Encoding = this.GetSelectedEncod();
                this.m_Port.DtrEnable = this.chkDTR.Checked;
                this.m_Port.RtsEnable = this.chkRTS.Checked;
                try
                {
                    this.m_Port.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (this.m_Model == null) this.m_Port.DataReceived += new SerialDataReceivedEventHandler(m_Port_DataReceived);
                else
                {
                    this.m_Model.Start();
                    if (this.m_Model.UseEvent) this.m_Port.DataReceived += new SerialDataReceivedEventHandler(m_Port_DataReceived);
                }
                this.btnOpen.FlatStyle = FlatStyle.Flat;
                this.chkAutoSend_CheckedChanged(null, null);
                this.btnOpen.Text = "关闭(&R)";
            }
            else
            {
                this.m_Port.DataReceived -= this.m_Port_DataReceived;
                this.ClosePort();
                this.btnOpen.FlatStyle = FlatStyle.Standard;
                this.btnOpen.Text = "打开(&O)";
            }
        }
        // 串口收到数据
        void m_Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (this.m_Pause) return;
            if (this.checkBox3.Checked)
            {
                byte[] buff = new byte[this.m_Port.BytesToRead];
                this.m_Mutex.WaitOne();
                this.m_Port.Read(buff, 0, buff.Length);
                this.m_Mutex.ReleaseMutex();
                this.AppendData(buff);
            }
            else
            {
                this.m_Mutex.WaitOne();
                string txt = this.m_Port.ReadExisting();
                this.m_Mutex.ReleaseMutex();
                this.Invoke((Action)(() =>
                {
                    this.txtRecive.AppendText(txt);
                    this.txtSumRecive.Text = (this.sum_Recive += txt.Length).ToString();
                }));
            }
        }
        // 窗口关闭
        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (this.m_Port != null) this.m_Port.DataReceived -= this.m_Port_DataReceived;
            this.ClosePort();
            base.OnHandleDestroyed(e);
        }
        // 释放串口
        private void ClosePort()
        {
            this.StopThread();
            if (this.m_Model != null) this.m_Model.Stop();
            if (this.m_Port != null)
            {
                this.m_Mutex.WaitOne();
                if (this.m_Port.IsOpen)
                {
                    this.m_Port.Close();
                    this.m_Port.Dispose();
                }
                this.m_Port = null;
                this.m_Mutex.ReleaseMutex();
            }
        }
        private void StopThread()
        {
            if (this.m_Send != null)
            {
                if (this.m_Send.IsAlive) this.m_Send.Abort();
                this.m_Send = null;
            }
        }
        // 发送数据
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.m_Port == null || !this.m_Port.IsOpen) return;
            if (this.checkBox2.Checked)
            {
                this.Send(this.txtSend.Text = this.txtSend.Text.Trim());
            }
            else
            {
                this.m_Port.Write(this.txtSend.Text);
                this.txtSumSend.Text = (this.sum_Send += this.txtSend.TextLength).ToString();
            }
        }
        // 获取编码
        private Encoding GetSelectedEncod()
        {
            switch (this.comEncod.SelectedIndex)
            {
                case 0: return Encoding.Default;
                case 1: return Encoding.ASCII;
                case 2: return Encoding.Unicode;
                case 3: return Encoding.UTF32;
                default: return Encoding.UTF8;
            }
        }
        // 选择编码
        private void comEncod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_Port == null) return;
            this.m_Port.Encoding = this.GetSelectedEncod();
        }
        // 输入时间
        private void txtAutoTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(e.KeyChar == 8 || e.KeyChar == 13 || char.IsNumber(e.KeyChar));
        }

        private int inter = 500;
        private int sum_Send, sum_Recive;

        // 自动发送
        private void chkAutoSend_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAutoSend.Checked)
            {
                if (this.m_Port == null || this.m_Model != null) return;
                (this.m_Send = new Thread(this.AutoSend) { IsBackground = true }).Start();
            }
            else this.StopThread();
        }
        private void AutoSend()
        {
            while (this.chkAutoSend.Checked)
            {
                Thread.Sleep(inter);
                if (this.checkBox2.Checked)
                {
                    this.Send(this.txtSend.Text.Trim());
                }
                else
                {
                    this.m_Port.Write(this.txtSend.Text);
                    this.Invoke((Action)(() => this.txtSumSend.Text = (this.sum_Send += this.txtSend.TextLength).ToString()));
                }
            }
        }
        private void Send(string txt)
        {
            if (string.IsNullOrEmpty(txt)) return;
            string[] hexStr = System.Text.RegularExpressions.Regex.Split(txt, @"[ ]+");
            try
            {
                byte[] data = (from b in hexStr select byte.Parse(b, System.Globalization.NumberStyles.HexNumber)).ToArray();
                this.m_Port.Write(data, 0, data.Length);
                this.sum_Send += data.Length;
                this.Invoke((Action)(() => this.txtSumSend.Text = this.sum_Send.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 暂停显示
        private void btnPause_Click(object sender, EventArgs e) { this.btnPause.Text = (this.m_Pause = !this.m_Pause) ? "恢复(&R)" : "暂停(&P)"; }

        // 清空收到的内容
        private void btnClearReciev_Click(object sender, EventArgs e) { this.txtRecive.Text = ""; }

        // 保存数据
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtRecive.TextLength == 0) return;
            using (SaveFileDialog dlg = new SaveFileDialog() { Title = "", Filter = "文本|*.txt", AutoUpgradeEnabled = true, CheckFileExists = true, CheckPathExists = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(dlg.FileName, this.txtRecive.Text);
                }
            }
        }

        // 清空发送内容
        private void btnClearSend_Click(object sender, EventArgs e) { this.txtSend.Clear(); }

        // 清空计数
        private void btnClearSum_Click(object sender, EventArgs e)
        {
            this.txtSumRecive.Text = (this.sum_Recive = 0).ToString();
            this.txtSumSend.Text = (this.sum_Send = 0).ToString();
        }

        private void chkDTR_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_Port != null) this.m_Port.DtrEnable = this.chkDTR.Checked;
        }

        private void chkRTS_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_Port != null) this.m_Port.RtsEnable = this.chkRTS.Checked;
        }

        private void chkBreak_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_Port != null) this.m_Port.BreakState = this.chkBreak.Checked;
        }
        // 读取文件
        private void btnRead_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "文本|*.txt" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if ((new System.IO.FileInfo(dlg.FileName).Length >> 20) > 1)
                    {
                        MessageBox.Show("文件大于1M");
                        return;
                    }
                    this.txtSend.Text = System.IO.File.ReadAllText(dlg.FileName, this.GetSelectedEncod());
                }
            }
        }

        private void AppendData(params byte[] buff)
        {
            if (this.InvokeRequired) this.Invoke(new Action<byte[]>(this.AppendData), buff);
            else
            {
                this.txtSumRecive.Text = (this.sum_Recive += buff.Length).ToString();
                if (this.checkBox3.Checked)
                    this.txtRecive.AppendText(string.Join(" ", from item in buff select item.ToString("X").PadLeft(2, '0')) + " ");
                else this.txtRecive.AppendText(this.m_Port.Encoding.GetString(buff));
            }
        }

        #region 模型接口

        public int BytesToRead { get { return this.m_Port == null ? 0 : this.m_Port.BytesToRead; } }

        public void Write(byte[] data, int offset, int len)
        {
            if (this.m_Port == null || !this.m_Port.IsOpen) return;
            this.m_Port.Write(data, offset, len);
            byte[] buff = new byte[len];
            Buffer.BlockCopy(data, offset, buff, 0, len);
            this.AppendData(buff);
        }

        public void Write(string text)
        {
            if (this.m_Port == null || !this.m_Port.IsOpen) return;
            this.m_Port.Write(text);
            this.Invoke((Action)(() => this.txtRecive.AppendText(text)));
        }

        public void Read(byte[] data, int offset, int len)
        {
            if (this.m_Port == null || !this.m_Port.IsOpen) return;
            this.m_Port.Read(data, offset, len);
            byte[] buff = new byte[len];
            Buffer.BlockCopy(data, offset, buff, 0, len);
            this.AppendData(buff);
        }

        public int ReadByte()
        {
            if (this.m_Port == null || !this.m_Port.IsOpen || this.m_Port.BytesToRead == 0) return -1;
            int d = this.m_Port.ReadByte();
            if (d >= 0) this.AppendData((byte)d);
            return d;
        }

        private BindingList<SerialPortModal> m_Models = new BindingList<SerialPortModal>();

        private void btnBindModal_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Title = "选择文件", Filter = "动态库|*.dll" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var ass = System.Reflection.Assembly.LoadFile(dlg.FileName);
                        var tf = ass.GetCustomAttributes(typeof(System.Runtime.Versioning.TargetFrameworkAttribute), false);
                        if (tf.Length == 0) MessageBox.Show("选中的动态库没有平台版本信息");
                        else
                        {
                            if ((tf[0] as System.Runtime.Versioning.TargetFrameworkAttribute).FrameworkDisplayName.Split(' ')[2] != "4")
                            {
                                MessageBox.Show("所选动态库的 Framework 版本不是4.0");
                            }
                            else
                            {
                                this.m_Model = null;
                                this.m_Models.Clear();
                                this.m_Models.Add(new NullPortModal() { Panel = this });
                                Type m = typeof(SerialPortModal);
                                int id = 1;
                                foreach (Type t in ass.GetExportedTypes())
                                {
                                    if (t.IsSubclassOf(m))
                                    {
                                        var con = t.GetConstructor(new Type[] { });
                                        if (con != null)
                                        {
                                            this.m_Models.Add(con.Invoke(null) as SerialPortModal);
                                            this.m_Models[id++].Panel = this;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch { MessageBox.Show("选中的动态库不是DotNet的程序集"); }
                }
            }
        }

        private void comModals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comModals.SelectedIndex > 0) this.m_Model = this.m_Models[this.comModals.SelectedIndex];
            else this.m_Model = null;
        }

        #endregion

        #region 自动监测串口变化

        private void ComChanged(bool add, string com)
        {
            string name = null;
            if (add)
            {
                name = this.m_Port != null ? this.m_Port.PortName : this.comNames.Text;
            }
            else
            {
                if (this.m_Port != null && this.m_Port.PortName == com) this.btnOpen_Click(null, null);
            }
            this.comNames.Items.Clear();
            PortPanel.PortNames = SerialPort.GetPortNames();
            this.comNames.Items.Clear();
            this.comNames.Items.AddRange(PortPanel.PortNames);
            this.comNames.Text = name;
        }
        
        #endregion

        private void comProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool refuse = this.status;
            if (this.status) this.btnOpen_Click(null, null);
            if (refuse) this.btnOpen_Click(null, null);
        }
    }
}
