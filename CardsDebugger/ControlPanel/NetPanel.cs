using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Wangfs763.Cards.ControlPanel
{
    [ToolboxItem(false)]
    public partial class NetPanel : UserControl
    {
        private bool m_Pause;
        private int m_SumSend, m_SumRecive;
        private int inter = 500;
        private Thread m_Send, m_View;
        private System.Collections.Concurrent.ConcurrentQueue<ViewInfo> m_Datas;
        private Models.NetModal m_Model;
        private System.Collections.Generic.List<Socket> m_Clients;
        UdpClient m_Udp;
        TcpClient m_Tcp_C;
        TcpListener m_Tcp_S;
        Mutex m_Mutex;
        System.Net.IPEndPoint m_Point;
        System.Text.Encoding m_Encoding;


        public NetPanel()
        {
            InitializeComponent();
            this.btnClearSum_Click(null, null);
            this.Dock = DockStyle.Fill;
            this.comboBox1.SelectedIndex = 0;
            this.m_Mutex = new Mutex();
            this.coboxEncoding.SelectedIndex = 0;
            this.m_Clients = new System.Collections.Generic.List<Socket>();
            this.m_Datas = new System.Collections.Concurrent.ConcurrentQueue<ViewInfo>();
            (this.m_View = new Thread(this.viewThread) { IsBackground = true }).Start();
        }

        // 暂停/恢复
        private void btnPause_Click(object sender, EventArgs e) { this.btnPause.Text = (this.m_Pause = !this.m_Pause) ? "恢复(R)" : "暂停(&P)"; }
        // 清空接收区
        private void btnClearRec_Click(object sender, EventArgs e) { this.txtReceive.Clear(); }
        // 保存收到的数据
        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog() { Filter = "文本文件|*.txt", Title = "保存数据", CheckFileExists = true })
                if (dlg.ShowDialog() == DialogResult.OK) System.IO.File.WriteAllText(dlg.FileName, this.txtReceive.Text);
        }
        // 打开文件
        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "文本文件|*.txt", CheckFileExists = true, Title = "选择数据文件" })
                if (dlg.ShowDialog() == DialogResult.OK) this.txtSend.Text = System.IO.File.ReadAllText(dlg.FileName);
        }
        // 清空发送区
        private void btnClearSnd_Click(object sender, EventArgs e) { this.txtSend.Clear(); }
        // 输入时间
        private void txtAutoTime_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = !(e.KeyChar == 8 || e.KeyChar == 13 || char.IsNumber(e.KeyChar)); }
        // 清空计数
        private void btnClearSum_Click(object sender, EventArgs e)
        {
            this.txtSumSend.Text = this.txtSumRecive.Text = "0";
            this.m_SumRecive = this.m_SumSend = 0;
        }
        // 选择编码
        private void coboxEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.coboxEncoding.SelectedIndex)
            {
                case 0:
                    this.m_Encoding = System.Text.Encoding.ASCII;
                    break;
                case 1:
                    this.m_Encoding = System.Text.Encoding.BigEndianUnicode;
                    break;
                case 2:
                    this.m_Encoding = System.Text.Encoding.Default;
                    break;
                case 3:
                    this.m_Encoding = System.Text.Encoding.Unicode;
                    break;
                case 4:
                    this.m_Encoding = System.Text.Encoding.UTF32;
                    break;
                default:
                    this.m_Encoding = System.Text.Encoding.UTF8;
                    break;
            }
        }

        // 开始连接
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (this.txtLocalPort.Enabled)
            {
                // 新建连接
                if (string.IsNullOrEmpty(this.ipEditBox1.Text) || this.txtLocalPort.TextLength == 0)
                {
                    MessageBox.Show("请正确填写【IP】和【端口】设置");
                    return;
                }
                switch (this.comboBox1.SelectedIndex)
                {
                    case 0:     // UDP
                        this.m_Udp = new UdpClient(this.m_Point = new System.Net.IPEndPoint(this.ipEditBox1.IP, int.Parse(this.txtLocalPort.Text)));
                        //uint IOC_IN = 0x80000000;
                        //uint IOC_VENDOR = 0x18000000;
                        //uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;
                        //this.m_Udp.Client.IOControl((int)SIO_UDP_CONNRESET, new byte[] { Convert.ToByte(false) }, null);
                        this.m_Udp.Client.IOControl(-1744830452, new byte[] { 0 }, null);
                        this.m_Udp.BeginReceive(this.udp_Callback, this.m_Udp);
                        this.label5.Text = "远端IP：";
                        this.comboBox2.Hide();
                        this.ipEditBox2.Show();
                        this.label7.Show();
                        this.txtRemotePort.Show();
                        this.panel4.Show();
                        break;
                    case 1:     // Client
                        this.m_Tcp_C = new TcpClient();
                        try { this.m_Tcp_C.Connect(this.m_Point = new System.Net.IPEndPoint(this.ipEditBox1.IP, int.Parse(this.txtLocalPort.Text))); }
                        catch (Exception ex) { MessageBox.Show(ex.Message); return; }
                        SocketParam para = new SocketParam(this.m_Tcp_C.Client);
                        this.m_Tcp_C.Client.BeginReceive(para.Buffer, 0, 65536, SocketFlags.None, this.client_Callback, para);
                        break;
                    default:    // Server
                        this.m_Tcp_S = new TcpListener(this.m_Point = new System.Net.IPEndPoint(this.ipEditBox1.IP, int.Parse(this.txtLocalPort.Text)));
                        this.m_Tcp_S.Start();
                        this.m_Tcp_S.BeginAcceptSocket(this.server_Callback, this.m_Tcp_S);
                        this.label5.Text = "客户端：";
                        this.comboBox2.Items.Clear();
                        this.comboBox2.Show();
                        this.ipEditBox2.Hide();
                        this.label7.Hide();
                        this.txtRemotePort.Hide();
                        this.panel4.Show();
                        break;
                }
                this.txtLocalPort.Enabled = this.ipEditBox1.Enabled = this.comboBox1.Enabled = false;
                this.btnConnect.Text = "断开(&N)";
                this.chkAutoSend_CheckedChanged(null, null);
            }
            else
            {
                // 断开连接
                this.StopThread();  // 停止自动发送
                this.m_Mutex.WaitOne();
                this.panel4.Hide();
                switch (this.comboBox1.SelectedIndex)
                {
                    case 0:     // UDP
                        this.m_Udp.Close();
                        (this.m_Udp as IDisposable).Dispose();
                        this.m_Udp = null;
                        break;
                    case 1:     // Client
                        this.m_Tcp_C.Close();
                        (this.m_Tcp_C as IDisposable).Dispose();
                        this.m_Tcp_C = null;
                        break;
                    default:    // Server
                        this.m_Mutex.ReleaseMutex();
                        for (int i = this.m_Clients.Count - 1; i >= 0; i--) this.m_Clients[i].Dispose();
                        this.m_Mutex.WaitOne();
                        this.comboBox2.Items.Clear();
                        this.m_Tcp_S.Stop();
                        this.m_Tcp_S = null;
                        break;
                }
                this.m_Clients.Clear();
                this.m_Mutex.ReleaseMutex();
                this.txtLocalPort.Enabled = this.ipEditBox1.Enabled = this.comboBox1.Enabled = true;
                this.btnConnect.Text = "连接(&N)";
            }
        }

        // 发送数据
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.ipEditBox1.Enabled) return;
            if (this.txtSend.TextLength == 0)
            {
                MessageBox.Show("请填写要发送的内容");
                this.txtSend.Focus();
                return;
            }
            switch (this.comboBox1.SelectedIndex)
            {
                case 0: // UDP
                    this.SendUDP(new System.Net.IPEndPoint(this.ipEditBox2.IP, int.Parse(this.txtRemotePort.Text)), this.txtSend.Text);
                    break;
                case 1:     // Client
                    byte[] data = this.GetData(this.txtSend.Text);
                    if (data.Length == 0) return;
                    this.m_Tcp_C.Client.Send(data);
                    this.setSendSum(data.Length);
                    break;
                default:    // Server
                    this.SendServer(new System.Net.IPEndPoint(this.ipEditBox2.IP, int.Parse(this.txtRemotePort.Text)), this.txtSend.Text);
                    break;
            }
        }

        #region 数据发送

        // 自动发送周期
        private void txtAutoTime_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtAutoTime.Text)) return;
            int i = int.Parse(this.txtAutoTime.Text);
            if (i > 1) this.inter = i;
        }

        // 自动发送
        private void chkAutoSend_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ipEditBox1.Enabled || this.m_Model != null) return;
            if (this.chkAutoSend.Checked)
            {
                switch (this.comboBox1.SelectedIndex)
                {
                    case 0:     // UDP
                        (this.m_Send = new Thread(this.autoSendUDP) { IsBackground = true }).Start();
                        break;
                    case 1:     // Client
                        (this.m_Send = new Thread(this.autoSendClient) { IsBackground = true }).Start();
                        break;
                    default:    // Server
                        (this.m_Send = new Thread(this.autoSendServer) { IsBackground = true }).Start();
                        break;
                }
            }
            else this.StopThread();
        }
        void autoSendUDP()
        {
            while (this.chkAutoSend.Checked)
            {
                Thread.Sleep(this.inter);
                if (this.txtSend.Text.Length == 0) continue;
                this.SendUDP(new System.Net.IPEndPoint(this.ipEditBox2.IP, int.Parse(this.txtRemotePort.Text)), this.txtSend.Text);
            }
        }
        void autoSendServer()
        {
            while (this.chkAutoSend.Checked)
            {
                Thread.Sleep(this.inter);
                if (this.txtSend.Text.Length == 0) continue;
                this.SendServer(new System.Net.IPEndPoint(this.ipEditBox2.IP, int.Parse(this.txtRemotePort.Text)), this.txtSend.Text);
            }
        }
        void autoSendClient()
        {
            while (this.chkAutoSend.Checked)
            {
                Thread.Sleep(this.inter);
                byte[] data = this.GetData(this.txtSend.Text);
                if (data.Length == 0) continue;
                this.m_Tcp_C.Client.Send(data);
                this.setSendSum(data.Length);
            }
        }

        byte[] GetData(string txt)
        {
            if (this.checkBox2.Checked)
            {
                string[] hexStr = System.Text.RegularExpressions.Regex.Split(txt, @"[ ]+");
                try { return (from b in hexStr select byte.Parse(b, System.Globalization.NumberStyles.HexNumber)).ToArray(); }
                catch (Exception ex) { MessageBox.Show(ex.Message); return new byte[0]; }
            }
            else return this.m_Encoding.GetBytes(txt);
        }

        void SendUDP(System.Net.IPEndPoint remote, string txt)
        {
            byte[] data = this.GetData(txt);
            if (data.Length == 0) return;
            this.m_Udp.Send(data, data.Length, remote);
            this.setSendSum(data.Length);
        }

        void SendServer(System.Net.EndPoint remote, string txt)
        {
            byte[] data = this.GetData(txt);
            if (data.Length == 0) return;
            foreach (Socket s in this.m_Clients)
            {
                if (s.RemoteEndPoint.Equals(remote))
                {
                    s.Send(data);
                    this.setSendSum(data.Length);
                    return;
                }
            }
        }

        #endregion

        #region 模型方法

        // UDP 方法
        public void SendUdpData(System.Net.IPEndPoint remote, byte[] data)
        {
            this.m_Mutex.WaitOne();
            if (this.m_Udp == null || remote == null || data == null || data.Length == 0) return;
            this.m_Udp.Send(data, data.Length, remote);
            this.setSendSum(data.Length);
            if (this.m_Pause) goto release;
            this.m_Datas.Enqueue(new ViewInfo(remote, "模型发给 ") { Data = data });
        release:
            this.m_Mutex.ReleaseMutex();
        }
        public void SendUdpData(System.Net.IPEndPoint remote, string data)
        {
            this.m_Mutex.WaitOne();
            if (this.m_Udp == null || remote == null || data == null || data.Length == 0) return;
            this.m_Udp.Connect(remote);
            byte[] d = this.m_Encoding.GetBytes(data);
            this.m_Udp.Send(d, d.Length);
            this.setSendSum(data.Length);
            if (this.m_Pause) goto release;
            this.m_Datas.Enqueue(new ViewInfo(remote, "模型发给 ", data));
        release:
            this.m_Mutex.ReleaseMutex();
        }

        // TCP 服务方法
        public void SendClientData(System.Net.EndPoint point, byte[] data)
        {
            if (data == null || point == null || this.m_Tcp_S == null) return;
            this.m_Mutex.WaitOne();
            if (this.m_Tcp_S == null) goto release;
            foreach (Socket s in this.m_Clients)
            {
                if (s.RemoteEndPoint.Equals(point))
                {
                    s.Send(data);
                    this.setSendSum(data.Length);
                    break;
                }
            }
        release:
            this.m_Mutex.ReleaseMutex();
        }
        public void SendClientData(System.Net.EndPoint point, string data)
        {
            if (data == null || data.Length == 0 || point == null || this.m_Tcp_S == null) return;
            this.SendClientData(point, this.m_Encoding.GetBytes(data));
        }


        // TCP 客户端方法
        public void SendClientData(byte[] data)
        {
            if (data == null || this.m_Tcp_C == null) return;
            this.m_Mutex.WaitOne();
            if (this.m_Tcp_C == null) goto release;
            this.m_Tcp_C.Client.Send(data);
            this.setSendSum(data.Length);
        release:
            this.m_Mutex.ReleaseMutex();
        }
        public void SendClientData(string data)
        {
            if (data == null || data.Length == 0 || this.m_Tcp_C == null) return;
            this.SendClientData(this.m_Encoding.GetBytes(data));
        }


        private BindingList<Models.NetModal> m_Models = new BindingList<Models.NetModal>();
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
                                this.m_Models.Add(new Models.NullNetModal() { m_Panel = this });
                                Type m = typeof(Models.NetModal);
                                int id = 1;
                                foreach (Type t in ass.GetExportedTypes())
                                {
                                    if (t.IsSubclassOf(m))
                                    {
                                        var con = t.GetConstructor(new Type[] { });
                                        if (con != null)
                                        {
                                            this.m_Models.Add(con.Invoke(null) as Models.NetModal);
                                            this.m_Models[id++].m_Panel = this;
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

        #region 异步方法

        // 收到 UDP 数据
        void udp_Callback(IAsyncResult ar)
        {
            this.m_Mutex.WaitOne();
            if (this.m_Udp == null) goto release;
            byte[] data = this.m_Udp.EndReceive(ar, ref this.m_Point);
            this.setReciSum(data.Length);
            if (this.m_Pause) goto release;
            this.m_Datas.Enqueue(new ViewInfo(this.m_Point) { Data = data });
            this.m_Udp.BeginReceive(this.udp_Callback, this.m_Udp);
            if (this.m_Model != null) this.m_Model.OnUdpDataArrived(this.m_Point, data);
        release:
            this.m_Mutex.ReleaseMutex();
        }

        // TCP 服务
        void server_Callback(IAsyncResult ar)
        {
            this.m_Mutex.WaitOne();
            if (this.m_Tcp_S == null) goto release;
            Socket socket = this.m_Tcp_S.EndAcceptSocket(ar);
            this.Invoke((Action)(() => this.comboBox2.Items.Add(socket.RemoteEndPoint)));
            this.m_Clients.Add(socket);
            SocketParam para = new SocketParam(socket);
            if (this.m_Model != null) this.m_Model.OnClientConnect(socket.RemoteEndPoint);
            socket.BeginReceive(para.Buffer, 0, 65536, SocketFlags.None, this.socket_Callback, para);
            this.m_Tcp_S.BeginAcceptSocket(this.server_Callback, this.m_Tcp_S);
        release:
            this.m_Mutex.ReleaseMutex();
        }
        void socket_Callback(IAsyncResult ar)
        {
            SocketParam para = ar.AsyncState as SocketParam;
            this.m_Mutex.WaitOne();
            if (this.m_Tcp_S == null) goto disconnected;
            byte[] data = new byte[para.Socket.EndReceive(ar)];
            if (data.Length == 0) goto disconnected;
            Buffer.BlockCopy(para.Buffer, 0, data, 0, data.Length);
            this.m_Datas.Enqueue(new ViewInfo(para.Socket.RemoteEndPoint) { Data = data });
            this.setReciSum(data.Length);
            if (this.m_Model != null) this.m_Model.OnClientDataArrived(para.Socket.RemoteEndPoint, data);
            para.Socket.BeginReceive(para.Buffer, 0, 65536, SocketFlags.None, this.socket_Callback, para);
        release:
            this.m_Mutex.ReleaseMutex();
            return;
        disconnected:
            if (!para.Socket.Connected) goto release;
            this.Invoke((Action)(() => this.comboBox2.Items.Remove(para.Socket.RemoteEndPoint)));
            this.m_Clients.Remove(para.Socket);
            if (this.m_Model != null) this.m_Model.OnClientDisconnect(para.Socket.RemoteEndPoint);
            this.comboBox2_SelectedValueChanged(null, EventArgs.Empty);
            goto release;
        }

        // TCP 客户端
        void client_Callback(IAsyncResult ar)
        {
            SocketParam para = ar.AsyncState as SocketParam;
            this.m_Mutex.WaitOne();
            if (this.m_Tcp_C == null) goto release;
            try
            {
                byte[] data = new byte[para.Socket.EndReceive(ar)];
                if (data.Length == 0) goto release;
                Buffer.BlockCopy(para.Buffer, 0, data, 0, data.Length);
                this.m_Datas.Enqueue(new ViewInfo(para.Socket.RemoteEndPoint) { Data = data });
                this.setReciSum(data.Length);
                if (this.m_Model != null) this.m_Model.OnClientDataArrived(data);
                para.Socket.BeginReceive(para.Buffer, 0, 65536, SocketFlags.None, this.client_Callback, para);
            }
            catch { goto disconnected; }
        release:
            this.m_Mutex.ReleaseMutex();
            return;
        disconnected:
            this.m_Mutex.ReleaseMutex();
            this.Invoke((Action)(() => this.btnConnect_Click(null, null)));
        }

        #endregion

        #region 内部类

        class SocketParam
        {
            public SocketParam(Socket socket) { this.Socket = socket; this.Buffer = new byte[65536]; }

            public Socket Socket { get; set; }

            public byte[] Buffer { get; private set; }
        }

        class ViewInfo
        {
            public ViewInfo(System.Net.EndPoint ip, string top = "", string end = "") { this.Text = top + "客户端：" + ip.ToString() + "\r\n" + end; }
            public string Text;
            public byte[] Data;
        }

        #endregion

        #region  数据显示方法

        //void appendClientInfo(System.Net.EndPoint ip) { this.txtReceive.AppendText("客户端：" + ip.ToString() + "\r\n"); }
        //void appendData(byte[] data)
        //{
        //    if (this.checkBox1.Checked)
        //    {
        //        // 16进制显示
        //        this.Invoke((Action<string>)this.appendText, string.Join(" ", from d in data select d.ToString("X2")));
        //    }
        //    else
        //    {
        //        // 文本
        //        this.Invoke((Action<string>)this.appendText, this.m_Encoding.GetString(data));
        //    }
        //}
        //void appendText(string txt) { this.txtReceive.AppendText(txt + "\r\n\r\n"); }
        void setSendSum(int len)
        {
            this.m_SumSend += len;
            this.Invoke((Action)(() => this.txtSumSend.Text = this.m_SumSend.ToString()));
        }
        void setReciSum(int len)
        {
            this.m_SumRecive += len;
            this.Invoke((Action)(() => this.txtSumRecive.Text = this.m_SumRecive.ToString()));
        }
        void viewThread()
        {
            ViewInfo info;
            while (!this.IsHandleCreated) System.Threading.Thread.Sleep(5);
            while (this.IsHandleCreated)
            {
                System.Threading.Thread.Sleep(5);
                if (!this.m_Datas.TryDequeue(out info)) continue;
                this.Invoke((Action)(() =>
                {
                    this.txtReceive.AppendText(info.Text);
                    if (info.Data != null)
                    {
                        if (this.checkBox1.Checked)
                        {
                            // 16进制
                            this.txtReceive.AppendText(string.Join(" ", from d in info.Data select d.ToString("X2")));
                        }
                        else
                        {
                            // 文本
                            this.txtReceive.AppendText(this.m_Encoding.GetString(info.Data));
                        }
                    }
                    this.txtReceive.AppendText("\r\n\r\n");
                }));
            }
        }

        #endregion

        #region 释放

        private void StopThread()
        {
            if (this.m_Send != null)
            {
                if (this.m_Send.IsAlive) this.m_Send.Abort();
                this.m_Send = null;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 2 && !this.ipEditBox1.Enabled)
            {
                this.btnConnect_Click(null, null);
                if (this.m_View.IsAlive) this.m_View.Abort();
                this.m_View = null;
            }
            base.WndProc(ref m);
        }

        #endregion

        // 选择 TCP 客户端
        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.Items.Count == 0) return;
            if (this.InvokeRequired) this.Invoke((Action<object, EventArgs>)this.comboBox2_SelectedValueChanged, sender, e);
            else
            {
                if (this.comboBox2.Items.Count == 0) return;
                string[] para = (this.comboBox2.SelectedItem as System.Net.EndPoint).ToString().Split(':');
                this.ipEditBox2.Text = para[0];
                this.txtRemotePort.Text = para[1];
            }
        }

    }
}
