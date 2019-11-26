using System.Linq;
using System.Windows.Forms;
using NationalInstruments.DAQmx;

namespace Wangfs763.Cards.Drivers
{
    class NICards : BaseCardIniter
    {
        public static void InitCards(TabControl tab)
        {
            var groups = from item in
                             (from d in DaqSystem.Local.Devices select DaqSystem.Local.LoadDevice(d))
                         group item by item.ProductCategory into tmp
                         select new
                         {
                             Type = tmp.Key,
                             Devices = tmp.ToArray()
                         };
            TabPage cardPage;
            foreach (var g in groups)
            {
                switch (g.Type)
                {
                    case ProductCategory.DigitalIO:
                        cardPage = new TabPage("NI 可控离散量");
                        if (g.Devices.Length == 1)
                        {
                            cardPage.Controls.Add(new ControlPanel.IOPanel(g.Devices[0]));
                        }
                        else
                        {
                            TabControl ioTab = new TabControl();
                            for (int i = 0; i < g.Devices.Length; i++)
                            {
                                tab.TabPages.Add("板卡" + (i + 1));
                                tab.TabPages[i].Controls.Add(new ControlPanel.IOPanel(g.Devices[i]));
                            }
                            cardPage.Controls.Add(ioTab);
                        }
                        tab.TabPages.Add(cardPage);
                        break;
                    default:
                        MessageBox.Show("未实现控制操作的板卡类型：" + g.Type);
                        break;
                }
            }
        }

    }
}
