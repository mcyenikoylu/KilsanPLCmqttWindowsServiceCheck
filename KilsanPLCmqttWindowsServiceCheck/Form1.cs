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
using Quartz;
using Quartz.Impl;
using System.Threading;

namespace KilsanPLCmqttWindowsServiceCheck
{
    public partial class Form1 : Form
    {
        public static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                logger.Info(" BEGIN --- Form1_Load()");

                Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
                scheduler.Start();

                IJobDetail job = JobBuilder.Create<ServiceRestart>()
                       .WithIdentity("job1", "group1")
                       .Build();
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group1")
                    .WithCronSchedule("59 45 * * * ?")
                    .ForJob("job1", "group1")
                    .Build();
                scheduler.ScheduleJob(job, trigger);

                //Thread.Sleep(TimeSpan.FromSeconds(60));
            }
            catch (SchedulerException se)
            {
                logger.Error(se, " Form1_Load()");
            }
        }

        public class ServiceRestart : IJob
        {
            public void Execute(IJobExecutionContext context)
            {
                try
                {
                    RestartWindowsService("Kilsan PLC Service");
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "");
                }
            }
        }

        private void btnPLC_Click(object sender, EventArgs e)
        {
            try
            {
                RestartWindowsService("Kilsan PLC Service");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "");
            }
        }

        public static void RestartWindowsService(string serviceName)
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
                logger.Error(ex, "");
            }
        }

        private void btnNetsis_Click(object sender, EventArgs e)
        {
            RestartWindowsService("Kilsan Netsis Service");
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
