using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using GAM.Dialogs;
using GAM.Forms.Information.Library;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace GAM.Forms.Profile
{
    public partial class dlgAlerts : XtraFormCenterText
    {
        public dlgAlerts(bool startTimer)
        {
            InitializeComponent();

            if (startTimer)
            {
                btnClose.Text = string.Format("خروج ({0})", 20);
                timer.Start();
            }
            else
            {
                btnClose.Text = "خروج";
                btnClose.Enabled = true;
            }
        }

        private void repositorybtnDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(msgLoopLoading), true, true, false);
            Application.DoEvents();
            if (gridView.FocusedRowHandle >= 0)
            {
                DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
                bool queryResult = MessagesSys.DeleteQuery(row["ID"].ToString(), row["DeletedUsers"].ToString());
                if (queryResult)
                {
                    gridView.DeleteRow(gridView.FocusedRowHandle);
                }
            }
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }

        private void dlgAlerts_Shown(object sender, System.EventArgs e)
        {
            RepositoryItemImageComboBox imgCombo = gridControl.RepositoryItems.Add("ImageComboBoxEdit") as RepositoryItemImageComboBox;
            imgCombo.SmallImages = this.imageCollection;
            imgCombo.Items.Add(new ImageComboBoxItem(0));
            imgCombo.Items.Add(new ImageComboBoxItem(1));
            imgCombo.Items.Add(new ImageComboBoxItem(2));
            imgCombo.Items.Add(new ImageComboBoxItem(3));
            imgCombo.Items.Add(new ImageComboBoxItem(4));

            imgCombo.Buttons[0].Kind = ButtonPredefines.Glyph;
            imgCombo.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["Category"].ColumnEdit = imgCombo;
            gridControl.DataSource = MessagesSys.AllMessagesTable;
        }

        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow row = gridView.GetDataRow(e.RowHandle);
                if (row != null && !row["ReadUsers"].ToString().Contains(Users.MyUserID.ToString()))
                    e.Appearance.BackColor2 = System.Drawing.SystemColors.Info;
                else
                    e.Appearance.BackColor2 = System.Drawing.Color.WhiteSmoke;
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            MessagesSys.ReadMessagesQuery(MessagesSys.AllMessagesTable);
            this.Close();
        }

        int counter = 20;
        private void timer_Tick(object sender, System.EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                timer.Stop();
                btnClose.Text = string.Format("بله، متوجه شدم", counter);
                btnClose.Enabled = true;
            }
            else
                btnClose.Text = string.Format("بله، متوجه شدم ({0})", counter);
        }

        private void dlgAlerts_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !btnClose.Enabled;
        }
    }
}

