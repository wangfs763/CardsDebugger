using NationalInstruments.NI4882;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Wangfs763.Cards.ControlPanel
{
    [ToolboxItem(false)]
    public partial class GpibPanel : UserControl
    {
        private Device m_Device;

        public GpibPanel(Device d)
        {
            InitializeComponent();
            this.m_Device = d;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            this.m_Device.Dispose();
            this.m_Device = null;
        }

        private void btnWrite_Click(object sender, EventArgs e) { this.Write(); }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try { this.txtReceive.Text = this.m_Device.ReadString(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e) { if (this.Write()) this.btnRead_Click(null, null); }

        private bool Write()
        {
            if (string.IsNullOrEmpty(this.txtCmd.Text = this.txtCmd.Text.Trim())) return false;
            try { this.m_Device.Write(this.txtCmd.Text); }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
            return true;
        }
    }
}
