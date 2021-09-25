using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Reports.Master
{
    public partial class dlgSortList : DevExpress.XtraEditors.XtraForm
    {
        public DataTable OutTable { set; get; }

        public dlgSortList(DataTable table)
        {
            InitializeComponent();
            this.OutTable = table.Clone();

            foreach (DataRow r in table.Rows)
            {
                list1.Items.Add(new DevExpress.XtraEditors.Controls.ImageListBoxItem(r, r["ReportName"].ToString()));
            }

            list1.MouseMove += event_MouseMove;
            list1.MouseDown += event_MouseDown;
            list1.DragOver += event_DragOver;
            list1.DragDrop += event_DragDrop;


            list2.DragOver += event_DragOver;
            list2.DragDrop += event_DragDrop;
            list2.MouseMove += event_MouseMove;
            list2.MouseDown += event_MouseDown;
        }

        Point sourcePoint = Point.Empty;
        ImageListBoxControl listSource;

        private void event_MouseDown(object sender, MouseEventArgs e)
        {
            listSource = sender as ImageListBoxControl;
            sourcePoint = new Point(e.X, e.Y);
            int selectedIndex = listSource.IndexFromPoint(sourcePoint);
            if (selectedIndex == -1)
                sourcePoint = Point.Empty;
            else
                sourcePoint = new Point(e.X, e.Y);
        }

        private void event_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                listSource = sender as ImageListBoxControl;

                if ((sourcePoint != Point.Empty) && ((Math.Abs(e.X - sourcePoint.X) > SystemInformation.DragSize.Width) || (Math.Abs(e.Y - sourcePoint.Y) > SystemInformation.DragSize.Height)))
                    listSource.DoDragDrop(sender, DragDropEffects.Move);
            }


        }

        private void event_DragOver(object sender, DragEventArgs e)
        {
            ImageListBoxControl list = sender as ImageListBoxControl;
            if (list != listSource)
                e.Effect = DragDropEffects.Move;

        }

        private void event_DragDrop(object sender, DragEventArgs e)
        {
            ImageListBoxControl listTarget = sender as ImageListBoxControl;
            if (listSource != listTarget)
            {
                Point targetPoint = new Point(e.X, e.Y);
                targetPoint = listTarget.PointToClient(targetPoint);
                int sourceIndex = listSource.IndexFromPoint(sourcePoint);
                int targetIndex = listTarget.IndexFromPoint(targetPoint);
                if (sourceIndex >= 0)
                {
                    if (targetIndex == -1)
                    {
                        object item = listSource.Items[sourceIndex];
                        listTarget.Items.Add(item);
                        listSource.Items.Remove(item);
                    }
                    else
                    {
                        object item = listSource.Items[sourceIndex];
                        listTarget.Items.Insert(targetIndex, item);
                        listSource.Items.Remove(item);
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (list1.Items.Count > 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("برخی از نمایه های موجود در لیست جاری به لیست خروجی منتقل نشده اند", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (list2.Items.Count > 0)
            {
                foreach (ImageListBoxItem item in list2.Items)
                {
                    ImageListBoxItem obj = (ImageListBoxItem)item.Value;
                    this.OutTable.ImportRow((DataRow)obj.Value);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void group2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button == group2.CustomHeaderButtons[1])
            {
                if (list2.SelectedIndex == 1)
                {
                    object item = list2.SelectedItem;
                    list2.Items.RemoveAt(list2.SelectedIndex);
                    list2.Items.Insert(0, item);
                    list2.SelectedIndex = 0;
                }
                else if (list2.SelectedIndex >= 1)
                {

                    object item = list2.SelectedItem;
                    if (list2.SelectedIndex >= 0)
                    {
                        int i = list2.SelectedIndex;
                        list2.Items.RemoveAt(list2.SelectedIndex);
                        list2.Items.Insert(i - 1, item);
                        list2.SelectedIndex = i - 1;
                    }
                }

            }

            if (e.Button == group2.CustomHeaderButtons[0])
            {
                if (list2.SelectedIndex + 1 < list2.ItemCount)
                {
                    object item = list2.SelectedItem;
                    if (item != null)
                    {
                        if (list2.SelectedIndex + 1 <= list2.ItemCount - 1)
                        {
                            list2.Items.RemoveAt(list2.SelectedIndex);
                            list2.Items.Insert(list2.SelectedIndex + 1, item);
                            list2.SelectedIndex = list2.SelectedIndex + 1;
                        }
                    }
                }
            }
        }

        private void list1_DoubleClick(object sender, EventArgs e)
        {
            if (list1.SelectedIndex >= 0)
            {
                list2.Items.Add(list1.Items[list1.SelectedIndex], -1);
                list1.Items.RemoveAt(list1.SelectedIndex);
            }
        }

        private void list2_DoubleClick(object sender, EventArgs e)
        {
            if (list2.SelectedIndex >= 0)
            {
                list1.Items.Add(list2.Items[list2.SelectedIndex], -1);
                list2.Items.RemoveAt(list2.SelectedIndex);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show("استفاده نمایید Drag یا Double Click برای جابجایی صفحات گزارش بین دو پنجره از روش", "راهنما", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnShiftAllToLeft_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list1.ItemCount; i++)
            {
                list2.Items.Add(list1.Items[i], -1);
            }
            list1.Items.Clear();
        }
    }
}
