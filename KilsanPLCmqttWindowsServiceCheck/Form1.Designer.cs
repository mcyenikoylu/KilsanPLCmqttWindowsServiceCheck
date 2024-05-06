
namespace KilsanPLCmqttWindowsServiceCheck
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPLC = new System.Windows.Forms.Button();
            this.btnNetsis = new System.Windows.Forms.Button();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHide = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPLC
            // 
            this.btnPLC.Location = new System.Drawing.Point(12, 12);
            this.btnPLC.Name = "btnPLC";
            this.btnPLC.Size = new System.Drawing.Size(271, 23);
            this.btnPLC.TabIndex = 0;
            this.btnPLC.Text = "Manual Restart \"Kilsan PLC Service\"";
            this.btnPLC.UseVisualStyleBackColor = true;
            this.btnPLC.Click += new System.EventHandler(this.btnPLC_Click);
            // 
            // btnNetsis
            // 
            this.btnNetsis.Location = new System.Drawing.Point(12, 41);
            this.btnNetsis.Name = "btnNetsis";
            this.btnNetsis.Size = new System.Drawing.Size(271, 23);
            this.btnNetsis.TabIndex = 1;
            this.btnNetsis.Text = "Manual Restart \"Kilsan Netsis Service\"";
            this.btnNetsis.UseVisualStyleBackColor = true;
            this.btnNetsis.Click += new System.EventHandler(this.btnNetsis_Click);
            // 
            // notify
            // 
            this.notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notify.ContextMenuStrip = this.menuTray;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "Ketencek Windows Services";
            this.notify.Visible = true;
            this.notify.DoubleClick += new System.EventHandler(this.notify_DoubleClick);
            // 
            // menuTray
            // 
            this.menuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemShow,
            this.menuItemHide});
            this.menuTray.Name = "contextMenuStrip1";
            this.menuTray.Size = new System.Drawing.Size(104, 48);
            // 
            // menuItemShow
            // 
            this.menuItemShow.Name = "menuItemShow";
            this.menuItemShow.Size = new System.Drawing.Size(180, 22);
            this.menuItemShow.Text = "Show";
            this.menuItemShow.Click += new System.EventHandler(this.menuItemShow_Click);
            // 
            // menuItemHide
            // 
            this.menuItemHide.Name = "menuItemHide";
            this.menuItemHide.Size = new System.Drawing.Size(180, 22);
            this.menuItemHide.Text = "Hide";
            this.menuItemHide.Click += new System.EventHandler(this.menuItemHide_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 76);
            this.Controls.Add(this.btnNetsis);
            this.Controls.Add(this.btnPLC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Windows Service Check";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPLC;
        private System.Windows.Forms.Button btnNetsis;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ContextMenuStrip menuTray;
        private System.Windows.Forms.ToolStripMenuItem menuItemShow;
        private System.Windows.Forms.ToolStripMenuItem menuItemHide;
    }
}

