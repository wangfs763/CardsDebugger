using System;
using System.Windows.Forms;

namespace Wangfs763.Cards.Drivers
{
    class General : BaseCardIniter
    {
        public static void InitCards(TabControl tab)
        {
            // 串口
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            tab.TabPages.Add("串口助手");
            tab.TabPages[tab.TabPages.Count - 1].Controls.Add(new ControlPanel.PortPanel(ports));
            Control ctrl;
            tab.TabPages[tab.TabPages.Count - 1].Controls.Add(ctrl = new Button() { Text = "新建窗口", Dock = DockStyle.Top, Height = 32 });
            ctrl.Click += new EventHandler(btnNewCom_Click);
            tab.TabPages[tab.TabPages.Count - 1].Padding = new Padding(6);

            // 网络
            tab.TabPages.Add("网络助手");
            tab.TabPages[tab.TabPages.Count - 1].Controls.Add(new ControlPanel.NetPanel());
            tab.TabPages[tab.TabPages.Count - 1].Controls.Add(ctrl = new Button() { Text = "新建窗口", Dock = DockStyle.Top, Height = 32 });
            ctrl.Click += new EventHandler(btnNewNet_Click);
            tab.TabPages[tab.TabPages.Count - 1].Padding = new Padding(6);
        }

        // 新建串口调试界面
        static void btnNewCom_Click(object sender, EventArgs e)
        {
            Form form = new Form() { Text = "串口助手", Size = new System.Drawing.Size(650, 496) };
            form.Controls.Add(new ControlPanel.PortPanel(ControlPanel.PortPanel.PortNames));
            form.Show();
        }

        // 新建网络调试界面
        static void btnNewNet_Click(object sender, EventArgs e)
        {
            Form form = new Form() { Text = "网络助手", Size = new System.Drawing.Size(650, 496) };
            form.Controls.Add(new ControlPanel.NetPanel());
            form.Show();
        }
    }
}
