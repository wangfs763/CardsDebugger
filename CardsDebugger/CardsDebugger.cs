using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Wangfs763.Cards
{
    public partial class CardsDebugger : Form
    {

        public CardsDebugger()
        {
            InitializeComponent();
            Type card = typeof(BaseCardIniter);
            foreach (Type t in this.GetType().Assembly.GetTypes())
            {
                if (t.IsSubclassOf(card))
                {
                    try { t.GetMethod("InitCards", (System.Reflection.BindingFlags)24).Invoke(null, new object[] { this.tabCards }); }
                    catch { }
                }
            }
        }

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    for (int i = Application.OpenForms.Count - 1; i > 0; i--)
        //    {
        //        Application.OpenForms[i].Close();
        //    }
        //}

        public static event ComChangedEventHandler ComChanged;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x219)
            {
                if (ComChanged == null)
                {
                    return;
                }
                if (m.LParam.ToInt32() > 0)
                {
                    DevHeader header = (DevHeader)Marshal.PtrToStructure(m.LParam, typeof(DevHeader));
                    if (header.DeviceType == 3)
                    {
                        DevPort port = (DevPort)Marshal.PtrToStructure(m.LParam, typeof(DevPort));
                        switch (m.WParam.ToInt32())
                        {
                            case 0x8000:
                                ComChanged(true, Encoding.Unicode.GetString(port.Name).Replace('\0', ' ').Trim());
                                break;

                            case 0x8004:
                                ComChanged(false, Encoding.Unicode.GetString(port.Name).Replace('\0', ' ').Trim());
                                break;
                        }
                    }
                }
            }
            base.WndProc(ref m);
        }


        [StructLayout(LayoutKind.Sequential)]
        private struct DevHeader
        {
            public int Size;
            public int DeviceType;
            public int Reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct DevPort
        {
            public int Size;
            public int DeviceType;
            public int Reserved;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public byte[] Name;
        }

    }

    public delegate void ComChangedEventHandler(bool add, string com);

    abstract class BaseCardIniter { }
}
