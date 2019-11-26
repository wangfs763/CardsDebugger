namespace Wangfs763.Cards
{
    partial class CardsDebugger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabCards = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tabCards
            // 
            this.tabCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCards.Location = new System.Drawing.Point(0, 0);
            this.tabCards.Name = "tabCards";
            this.tabCards.SelectedIndex = 0;
            this.tabCards.Size = new System.Drawing.Size(749, 518);
            this.tabCards.TabIndex = 0;
            // 
            // CardsDebugger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 518);
            this.Controls.Add(this.tabCards);
            this.Name = "CardsDebugger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备调试助手";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCards;
    }
}