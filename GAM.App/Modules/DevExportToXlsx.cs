using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Modules
{
    class DevExportToXlsx
    {
        public static void SaveAs(GridView gv)
        {
            try
            {
                gv.OptionsPrint.AutoWidth = false;

                DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx();
                options.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                options.ShowGridLines = false;
                options.RightToLeftDocument = DevExpress.Utils.DefaultBoolean.True;

                int index = gv.Columns.Count;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gv.Columns)
                {
                    col.VisibleIndex = index;
                    --index;
                }

                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Title = "Save Report";
                saveDlg.Filter = "Excel File|*.xlsx";
                saveDlg.ShowDialog();
                if (saveDlg.FileName != "")
                {
                    gv.ExportToXlsx(saveDlg.FileName, options);
                }
                index = 0;
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gv.Columns)
                {
                    col.VisibleIndex = index;
                    ++index;
                }
                if (saveDlg.FileName.Length > 0)
                    System.Diagnostics.Process.Start(saveDlg.FileName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DataTableToExcel(DataTable dt)
        {
            GridControl gridControl = new GridControl();
            gridControl.RightToLeft = RightToLeft.Yes;
            GridView view = new GridView();
            gridControl.ViewCollection.Add(view);
            gridControl.MainView = view;
            gridControl.BindingContext = new BindingContext();
            gridControl.DataSource = dt;
            view.PopulateColumns();
            gridControl.ForceInitialize();
            view.BestFitColumns();
            SaveAs(view);
        }
    }
}
