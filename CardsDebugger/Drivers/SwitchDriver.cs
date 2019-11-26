using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Wangfs763.Cards.Drivers
{
    class SwitchDevice : BaseCardIniter
    {
        public string Info { get; private set; }
        public int Bus { get; private set; }
        public int Slot { get; private set; }
        public int CardNum { get; private set; }
        public bool Usable { get; private set; }
        public bool Opened { get; private set; }
        private byte m_Count;
        public byte ChanCount { get { return this.m_Count; } }
        private string Index;

        private SwitchDevice(string info, int bus, int slot, int num, bool usable)
        {
            this.Info = info;
            this.Bus = bus;
            this.Slot = slot;
            this.Index = (this.CardNum = num).ToString();
            this.Usable = usable;
        }


        private static List<SwitchDevice> m_Devices;
        public static List<SwitchDevice> FindDevices()
        {
            if (m_Devices != null) return m_Devices;
            m_Devices = new List<SwitchDevice>();

            int[] busList = new int[30];
            int[] slots = new int[30];
            int result = FindFreeCards(30, busList, slots);
            if (result == 0)
            {
                byte sum = 0;
                for (int i = 0; i < 30; i++)
                {
                    if (busList[i] > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        int ptr = 0;
                        if (OpenSpecifiedCard(busList[i], slots[i], ref ptr) == 0)
                        {
                            if (CardId(ptr, sb) == 0)
                            {
                                m_Devices.Add(new SwitchDevice(sb.ToString(), busList[i], slots[i], ptr, Status(ptr) == 0));
                            }
                            ClosureLimit(ptr, 1, ref sum);
                            m_Devices[m_Devices.Count - 1].m_Count = sum;
                            CloseSpecifiedCard(ptr);
                        }
                        continue;
                    }
                    break;
                }
            }
            return m_Devices;
        }

        public bool Open()
        {
            if (this.Opened) return true;
            int ptr = 0;
            this.Opened = OpenSpecifiedCard(this.Bus, this.Slot, ref ptr) == 0;
            this.Usable = Status(ptr) == 0;
            return this.Opened;
        }

        public bool Clear() { if (!this.Opened) return false; return ClearCard(this.CardNum) == 0; }

        public bool Close()
        {
            this.Clear();
            if (this.Opened) this.Opened = CloseSpecifiedCard(this.CardNum) > 0;
            return !this.Opened;
        }

        public bool SetState(int index, bool state) { return OpBit(this.CardNum, 1, index, state) == 0; }

        ~SwitchDevice() { this.Close(); }

        #region API

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="maxCount"></param>
        /// <param name="busList"></param>
        /// <param name="slotList"></param>
        /// <returns></returns>
        [DllImport("Pilpxi.dll", EntryPoint = "PIL_FindFreeCards")]
        static extern int FindFreeCards(int maxCount, int[] busList, int[] slotList);

        /// <summary>
        /// 打开指定的板卡，返回0表示成功，否则返回错误码
        /// </summary>
        /// <param name="bus">总线号</param>
        /// <param name="slot">插槽号</param>
        /// <param name="cardPtr">卡号</param>
        [DllImport("Pilpxi.dll", EntryPoint = "PIL_OpenSpecifiedCard")]
        static extern int OpenSpecifiedCard(int bus, int slot, ref int cardPtr);

        /// <summary>
        /// 获取板卡信息
        /// </summary>
        /// <param name="cardPtr">卡号</param>
        /// <param name="info">信息</param>
        [DllImport("Pilpxi.dll", EntryPoint = "PIL_CardId")]
        static extern int CardId(int cardPtr, StringBuilder info);

        /// <summary>
        /// 释放板卡
        /// </summary>
        /// <param name="cardPtr">卡号</param>
        [DllImport("Pilpxi.dll", EntryPoint = "PIL_CloseSpecifiedCard")]
        static extern int CloseSpecifiedCard(int cardPtr);

        /// <summary>
        /// 复位
        /// </summary>
        /// <param name="cardPtr">卡号</param>
        [DllImport("Pilpxi.dll", EntryPoint = "PIL_ClearCard")]
        static extern int ClearCard(int cardPtr);

        /// <summary>
        /// 卡状态
        /// </summary>
        /// <param name="cardPtr">卡号</param>
        [DllImport("Pilpxi.dll", EntryPoint = "PIL_Status")]
        static extern int Status(int cardPtr);

        /// <summary>
        /// 设置某个通道的状态
        /// </summary>
        /// <param name="cardPtr">卡号</param>
        /// <param name="outSub">模块号</param>
        /// <param name="index">通道号</param>
        /// <param name="state">设置状态</param>
        [DllImport("Pilpxi.dll", EntryPoint = "PIL_OpBit")]
        static extern int OpBit(int cardPtr, int outSub, int index, bool state);

        /// <summary>
        /// 获取某个通道的状态
        /// </summary>
        /// <param name="cardPtr">卡号</param>
        /// <param name="outSub">模块号</param>
        /// <param name="index">通道号</param>
        /// <param name="state">获取的状态</param>
        [DllImport("Pilpxi.dll", EntryPoint = "PIL_ViewBit")]
        static extern int ViewBit(int cardPtr, int outSub, int index, ref bool state);

        /// <summary>
        /// 获取板卡通道数
        /// </summary>
        /// <param name="cardPtr">板卡句柄</param>
        /// <param name="outSub">子地址</param>
        /// <param name="count">板卡通道数</param>
        [DllImport("Pilpxi.dll", EntryPoint = "PIL_ClosureLimit")]
        static extern int ClosureLimit(int cardPtr, int outSub, ref byte count);

        #endregion

        private static Dictionary<string, Dictionary<int, string>> chan_Name;

        public static void InitCards(TabControl tab)
        {
            if (!System.IO.File.Exists(@"c:\windows\system32\pilpxi.dll")) return;
            if (System.IO.File.Exists("switch.ini") && new System.IO.FileInfo("switch.ini").Length < 1024)
            {
                // 继电器通道名称配置
                chan_Name = new Dictionary<string, Dictionary<int, string>>();
                Dictionary<int, string> cfg = null;
                string[] names;
                foreach (string line in System.IO.File.ReadAllLines("switch.ini"))
                {
                    if (line.EndsWith(":"))
                    {
                        cfg = chan_Name[line.Split(':')[0]] = new Dictionary<int, string>();
                        continue;
                    }
                    if (cfg == null) continue;
                    names = line.Split(':');
                    if (names.Length != 2) continue;
                    try { cfg[int.Parse(names[0])] = names[1]; }
                    finally { }
                }
            }
            var devs = FindDevices();
            if (devs.Count > 0)
            {
                TabPage page = new TabPage("Pickering继电器");
                if (devs.Count == 1)
                {
                    devs[0].InitPage(page);
                }
                else
                {
                    TabControl container = new TabControl() { Dock = DockStyle.Fill };
                    page.Controls.Add(container);
                    foreach (var d in devs)
                    {
                        container.TabPages.Add("板卡" + d.CardNum);
                        d.InitPage(container.TabPages[container.TabPages.Count - 1]);
                    }
                }
                tab.TabPages.Add(page);
            }
        }

        private void InitPage(Control ctrl)
        {
            container = new Panel() { Enabled = false, Dock = DockStyle.Fill };
            int rows = this.ChanCount >> 3;
            Control btn;
            int index;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    container.Controls.Add(btn = new Button() { Tag = index = (x << 3) + y + 1, Left = 48 * y + 6, Top = 48 * x + 6, Width = 48, Height = 48 });
                    if (chan_Name != null && chan_Name.ContainsKey(this.Index) && chan_Name[this.Index].ContainsKey(index))
                    {
                        btn.Text = chan_Name[this.Index][index];
                    }
                    else btn.Text = index.ToString();
                    btn.Click += new System.EventHandler(btn_Click);
                }
            }
            ctrl.Controls.Add(container);
            ctrl.Controls.Add(btn = new Panel() { Dock = DockStyle.Top, Height = ctrl.Font.Height + 20, Padding = new Padding(3) });
            btn.Controls.Add(new Label() { Text = string.Format("Bus:{0} Slot:{1}    {2}", this.Bus, this.Slot, this.Info), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft });
            btn.Controls.Add(btn = new Button() { Text = "打开", Dock = DockStyle.Left });
            btn.Click += new System.EventHandler(open_Click);
        }

        private Panel container;

        void open_Click(object sender, System.EventArgs e)
        {
            if (this.Usable)
            {
                if (this.Opened)
                {
                    if (this.Close())
                    {
                        (sender as Control).Text = "打开";
                        this.container.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("关闭失败");
                    }
                }
                else
                {
                    if (this.Open())
                    {
                        if (!this.Usable) goto alert;
                        (sender as Control).Text = "关闭";
                        this.container.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("打开失败");
                    }
                }
                return;
            }
        alert:
            MessageBox.Show("设备窗口异常，请确保设备没有被其它程序占用或其它异常");
        }

        void btn_Click(object sender, System.EventArgs e)
        {
            Button btn = sender as Button;
            int index = (int)btn.Tag;
            if (btn.BackColor == Color.LightBlue)
            {
                if (!this.SetState((int)btn.Tag, false)) goto alert;
                btn.BackColor = Color.FromArgb(255, 240, 240, 240);
                btn.FlatStyle = FlatStyle.System;
            }
            else
            {
                if (!this.SetState((int)btn.Tag, true)) goto alert;
                btn.BackColor = Color.LightBlue;
                btn.FlatStyle = FlatStyle.Standard;
            }
            return;
        alert:
            MessageBox.Show("状态切换失败");
        }

    }
}
