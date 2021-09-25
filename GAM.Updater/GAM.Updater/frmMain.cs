using GAM.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Updater
{
    public partial class frmMain : FadeForm
    {
        public frmMain()
        {
            InitializeComponent();
            this.Opacity = 0;
        }

        private async void Main_Shown(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(3000);
                
                OLEDB.Startup("KRZ-7687634", "Data$", string.Empty);
                OLEDB.ConnectionMode = OLEDB.ConnectionModeType.Master;

                foreach (string file in System.IO.Directory.GetFiles(OLEDB.GetInstallRoot()))
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient.DownloadFileAsync(new Uri(file), System.IO.Path.Combine(Application.StartupPath, System.IO.Path.GetFileName(file)));
                }

                progressBarControl.Position = 100;
                this.Hide();
                new dlgFinish().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "102", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarControl.Position = e.ProgressPercentage;
            Application.DoEvents();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
