using GAM.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Profile.Etebarat.Print
{
    public partial class dlgFormNo : Form
    {
        string Wordtext = "";
        public dlgFormNo(string text)
        {
            InitializeComponent();
            Wordtext = text;
            txtFormNo.Select();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Numeral.AnyToDouble(txtFormNo.Text) > 100 & Numeral.AnyToDouble(txtFormNo.Text) < 200)
            {
                CreatePrintDocument(txtFormNo.Text + ".docx", Wordtext, false);
                this.Close();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (txtFormNo.Text.Length > 0)
            {
                CreatePrintDocument(txtFormNo.Text + ".docx", Wordtext, true);
                this.Close();
            }
        }

        private void CreatePrintDocument(string formName, string text, bool printPreview)
        {

            var doc = WordDocument.OpenWordFile(OLEDB.GetFormFile(formName), true, false, true);
            if (doc.Tables[1].Cell(2, 1).Range.InlineShapes.Count >= 1)
                doc.Tables[1].Cell(2, 1).Range.InlineShapes[0].Delete();

            if (text.Length == 0)
                doc.Tables[1].Cell(1, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
            else
                doc.Tables[1].Cell(1, 1).Range.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;

            doc.Tables[1].Cell(2, 1).Range.Text = text.Trim();

            long totalPageNum = doc.ComputeStatistics(Microsoft.Office.Interop.Word.WdStatistic.wdStatisticPages);

            if (!printPreview)
            {
                if (totalPageNum == 1)
                    doc.PrintOut(true, false, Microsoft.Office.Interop.Word.WdPrintOutRange.wdPrintCurrentPage, Copies: "2", Pages: "1");
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("فرم چاپ مصوبه بیش از یک صفحه می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
