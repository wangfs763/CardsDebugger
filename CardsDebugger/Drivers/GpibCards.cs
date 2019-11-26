using NationalInstruments.NI4882;
using System.Windows.Forms;

namespace Wangfs763.Cards.Drivers
{
    class GpibCards : BaseCardIniter
    {
        public static void InitCards(TabControl tab)
        {
            TabPage page = new TabPage("GPIB设备");
            TabControl tc = new TabControl() { Dock = DockStyle.Fill };
            for (int num = 0; num < 5; num++)
            {
                for (byte add = 0; add < 32; add++)
                {
                    for (byte sec = 0; sec < 32; sec++)
                    {
                        try
                        {
                            Device d = new Device(num, add, sec);
                            if (d.GetCurrentStatus() != GpibStatusFlags.Error)
                            {
                                d.Write("*IDN?");
                                tc.TabPages.Add(d.ReadString());
                                tc.TabPages[tc.TabPages.Count - 1].Controls.Add(new ControlPanel.GpibPanel(d) { Dock = DockStyle.Fill });
                            }
                        }
                        catch { break; }
                    }
                }
            }
            if (tc.TabPages.Count > 0)
            {
                page.Controls.Add(tc);
                tab.TabPages.Add(page);
            }
        }
    }
}
