using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;

namespace KilsanPLCmqttWindowsServiceCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnPLC_Click(object sender, EventArgs e)
        {
            try
            {
                //using (PowerShell PowerShellInstance = PowerShell.Create())
                //{
                //    // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                //    // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                //    PowerShellInstance.AddScript(@"Restart-Service -Name ''Kilsan PLC Service''");

                //    //// use "AddParameter" to add a single parameter to the last command/script on the pipeline.
                //    //PowerShellInstance.AddParameter("param1", "parameter 1 value!");
                //}

                //System.Diagnostics.Process.Start("net", "stop 'Kilsan PLC Service'").WaitForExit();
                ////System.Diagnostics.Process.Start("net", "start ''Kilsan PLC Service''").WaitForExit();
                
                RestartWindowsService("Kilsan PLC Service");
            }
            catch (Exception ex)
            {

            }
        }

        private void RestartWindowsService(string serviceName)
        {
            ServiceController serviceController = new ServiceController(serviceName);
            try
            {
                if ((serviceController.Status.Equals(ServiceControllerStatus.Running)) || (serviceController.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    serviceController.Stop();
                }
                serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch (Exception ex)
            {
                //ShowMsg(AppTexts.Information, AppTexts.SystematicError, MessageBox.Icon.WARNING);
            }
        }

        //public static void RestartService(string serviceName, int timeoutMilliseconds)
        //{
        //    ServiceController service = new ServiceController(serviceName);
        //    try
        //    {
        //        int millisec1 = Environment.TickCount;
        //        TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

        //        service.Stop();
        //        service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

        //        // count the rest of the timeout
        //        int millisec2 = Environment.TickCount;
        //        timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2 - millisec1));

        //        service.Start();
        //        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
        //    }
        //    catch
        //    {
        //        // ...
        //    }
        //}

        private void btnNetsis_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                MinimizeTray();
        }

        private bool isClose = false;
        private void MinimizeTray()
        {
            this.Hide();
            this.notify.Visible = true;
            this.notify.ShowBalloonTip(1000, this.notify.Text, "The program is running in the background.", ToolTipIcon.Info);
        }
        private void ShowTray()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClose)
            {
                e.Cancel = true;
                MinimizeTray();
            }
        }

        private void notify_DoubleClick(object sender, EventArgs e)
        {
            ShowTray();
        }

        private void menuItemShow_Click(object sender, EventArgs e)
        {
            ShowTray();
        }

        private void menuItemHide_Click(object sender, EventArgs e)
        {
            MinimizeTray();
        }
    }
}
