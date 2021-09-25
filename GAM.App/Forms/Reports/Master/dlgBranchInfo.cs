using DevExpress.XtraVerticalGrid.Rows;
using GAM.Forms.Information.Library;
using GAM.Forms.Profile.Kargozini.Library;
using MD.PersianDateTime;
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
    public partial class dlgBranchInfo : DevExpress.XtraEditors.XtraForm
    {
        public dlgBranchInfo(string unitId)
        {
            InitializeComponent();
            if (Branches.IsBranch(unitId))
            {
                Branches.BranchInfo bi = Branches.GetBranchById(unitId, false);
                vGridControl.Rows.Add(AddCategory("مشخصات اصلی"));
                vGridControl.Rows.Add(AddRow("UnitId", "کد", bi.BranchId));
                vGridControl.Rows.Add(AddRow("UnitName", "نام", bi.BranchName));
                vGridControl.Rows.Add(AddRow("BranchDegree", "درجه", bi.BranchDegree));
                DataRow r = PersonelsManager.GetEmployeeInBranchByPostId(int.Parse(bi.BranchId), 35997);
                if (r != null)
                {
                    vGridControl.Rows.Add(AddCategory("اطلاعات مسئول"));
                    vGridControl.Rows.Add(AddRow("FullName", "نام مسئول", r["FullName"].ToString()));
                    if (PersianDateTime.IsValidDate(r["DateNewBranch"].ToString()))
                        vGridControl.Rows.Add(AddRow("DateNewBranch", "تاریخ جابجایی", PersianDateTime.Parse(int.Parse(r["DateNewBranch"].ToString())).ToShortDateString()));
                    if (PersianDateTime.IsValidDate(r["DateNewPost"].ToString()))
                        vGridControl.Rows.Add(AddRow("DateNewPost", "تاریخ تغییر پست", PersianDateTime.Parse(int.Parse(r["DateNewPost"].ToString())).ToShortDateString()));
                }
            }
            else if (Branches.IsDomain(unitId))
            {
                Branches.DomainInfo di = Branches.GetDomainById(unitId, false);
                vGridControl.Rows.Add(AddCategory("مشخصات اصلی"));
                vGridControl.Rows.Add(AddRow("UnitId", "کد", di.DomainId));
                vGridControl.Rows.Add(AddRow("UnitName", "نام", di.DomainName));
                DataRow r = PersonelsManager.GetEmployeeInBranchByPostId(int.Parse(di.DomainId), 30100);
                if (r != null)
                {
                    vGridControl.Rows.Add(AddCategory("اطلاعات مسئول"));
                    vGridControl.Rows.Add(AddRow("FullName", "نام مسئول", r["FullName"].ToString()));
                    if (PersianDateTime.IsValidDate(r["DateNewBranch"].ToString()))
                        vGridControl.Rows.Add(AddRow("DateNewBranch", "تاریخ جابجایی", PersianDateTime.Parse(int.Parse(r["DateNewBranch"].ToString())).ToShortDateString()));
                    if (PersianDateTime.IsValidDate(r["DateNewPost"].ToString()))
                        vGridControl.Rows.Add(AddRow("DateNewPost", "تاریخ تغییر پست", PersianDateTime.Parse(int.Parse(r["DateNewPost"].ToString())).ToShortDateString()));
                }
            }
            else if (Branches.IsProvince(unitId))
            {
                Branches.ProvinceInfo pi = Branches.GetProvinceById(unitId);
                vGridControl.Rows.Add(AddCategory("مشخصات اصلی"));
                vGridControl.Rows.Add(AddRow("UnitId", "کد", pi.ProvinceId ));
                vGridControl.Rows.Add(AddRow("UnitName", "نام", pi.ProvinceName));
            }
        }

        private EditorRow AddRow(string name, string caption, string value)
        {
            EditorRow row = new EditorRow();
            row.Properties.Caption = caption;
            row.Properties.Value = value;
            row.Properties.FieldName = name;
            return row;
        }
        private EditorRow AddHeader(string name, string caption, object value)
        {
            EditorRow row = new EditorRow();
            row.Properties.Caption = caption;
            row.Properties.Value = value;
            row.Properties.FieldName = name;
            row.Visible = false;
            return row;
        }

        private CategoryRow AddCategory(string caption)
        {
            CategoryRow row = new CategoryRow();
            row.Properties.Caption = caption;
            return row;
        }
    }
}
