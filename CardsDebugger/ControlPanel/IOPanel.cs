using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NationalInstruments.DAQmx;

namespace Wangfs763.Cards.ControlPanel
{
    [ToolboxItem(false)]
    public partial class IOPanel : Control
    {
        private CheckBox m_CheckState;
        private Thread m_Monitor;
        private string m_Channels;
        private Task task;
        private DigitalSingleChannelReader reader;
        int count;

        public IOPanel(Device device)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            Control ctrl;
            this.Controls.Add(ctrl = new Label() { Dock = DockStyle.Left });   // P0.0-Pn.7
            Size size = TextRenderer.MeasureText("Port00", this.Font);
            this.count = device.DIPorts.Count(s => !s.Contains('_'));
            this.m_Channels = device.DeviceID + "";
            ctrl.Text = "Port0";
            for (int i = 1; i < count; i++) ctrl.Text += "\r\nPort" + i.ToString();
            ctrl.Width = size.Width + 2;

            this.Controls.Add(new Label() { Dock = DockStyle.Top, Text = "        0 1 2 3 4 5 6 7" });    // 0-7
            this.Controls.Add(ctrl = new Panel() { Dock = DockStyle.Top, Height = this.Font.Height + 12 });
            ctrl.Controls.Add(new Label() { Dock = DockStyle.Fill, Text = device.DeviceID + "  " + device.ProductType, TextAlign = ContentAlignment.MiddleCenter });
            ctrl.Controls.Add(this.m_CheckState = new CheckBox() { Text = "状态监控", Dock = DockStyle.Left });
            this.m_Channels = string.Format("{0}/port0:{1}", device.DeviceID, count - 1); ;
            this.m_CheckState.CheckedChanged += new EventHandler(m_CheckState_CheckedChanged);
            this.Font = new System.Drawing.Font("宋体", 15);
        }

        void m_CheckState_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_CheckState.Checked)
            {
                this.task = new Task();
                this.task.DIChannels.CreateChannel(this.m_Channels, "", ChannelLineGrouping.OneChannelForAllLines);
                this.reader = new DigitalSingleChannelReader(task.Stream);
                (this.m_Monitor = new Thread(this.Monitor) { IsBackground = true }).Start();
            }
            else
            {
                this.CloseMonitor();
                this.reader = null;
                this.task.Dispose();
                this.task = null;
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            this.Controls[0].Width = TextRenderer.MeasureText("Port11", this.Font).Width + 2;
            this.Controls[2].Height = this.Font.Height + 12;
            base.OnFontChanged(e);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            this.CloseMonitor();
            base.OnHandleDestroyed(e);
        }

        private void Monitor()
        {
            while (true)
            {
                if (this.IsDisposed) return;
                Thread.Sleep(100);
                this.states = this.reader.ReadSingleSampleMultiLine();
                this.Invoke((Action)this.DrawState);
            }
        }

        private void CloseMonitor()
        {
            if (this.m_Monitor != null)
            {
                if (this.m_Monitor.IsAlive) this.m_Monitor.Abort();
                this.m_Monitor = null;
            }
        }

        private bool[] states;

        protected override void OnPaint(PaintEventArgs e) { this.DrawState(e.Graphics); }

        private void DrawState(Graphics g)
        {
            if (this.states == null) return;
            int left = this.Controls[0].Right + 8;
            int top = this.Controls[0].Top;
            int height = this.Font.Height - 3;
            using (Brush tb = new SolidBrush(Color.GreenYellow))
            {
                using (Brush fb = new SolidBrush(Color.LightGray))
                {
                    using (Pen pen = new Pen(Color.Black))
                    {
                        for (int i = 0; i < this.count; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                Rectangle rect = new Rectangle(left + j * height, top + i * height, height, height);
                                g.FillEllipse(this.states[(i << 3) + j] ? tb : fb, rect);
                                g.DrawEllipse(pen, rect);
                            }
                        }
                    }
                }
            }
        }

        private void DrawState() { using (Graphics g = this.CreateGraphics()) this.DrawState(g); }

    }
}
