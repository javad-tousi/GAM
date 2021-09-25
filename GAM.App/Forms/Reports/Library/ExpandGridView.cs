using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTab;
using GAM.Forms.Information.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Forms.Reports.Library
{
    class ExpandGridView
    {
        public static void Expand(XtraTabPage page, string unitId)
        {
            GridControl gc = page.Controls["gridControl"] as GridControl;
            if (gc == null)
                return;

            string branchId = string.Empty;
            string domainId = string.Empty;
            string provinceId = string.Empty;

            try
            {
                #region Level 1

                if (Branches.IsBranch(unitId))
                {
                    Branches.BranchInfo bi = Branches.GetBranchById(unitId, false);
                    branchId = bi.BranchId;
                    domainId = bi.Domain.DomainId;
                    provinceId = bi.Province.ProvinceId;
                }
                if (Branches.IsDomain(unitId))
                {
                    Branches.DomainInfo di = Branches.GetDomainById(unitId, false);
                    domainId = di.DomainId;
                    provinceId = di.Province.ProvinceId;
                }
                if (Branches.IsProvince(unitId))
                {
                    Branches.ProvinceInfo pi = Branches.GetProvinceById(unitId);
                    provinceId = pi.ProvinceId;
                }

                if (branchId.Length == 0 & domainId.Length == 0 & provinceId.Length == 0)
                    return;

                #endregion

                #region Level 2
                foreach (BaseView bv in gc.ViewCollection)
                {
                    if (bv is BandedGridView)
                    {
                        BandedGridView view = bv as BandedGridView;
                        if (view.Name == "Province")
                        {
                            view.CollapseAllDetails();
                            break;
                        }
                    }
                }
                #endregion

                #region Level 3
                foreach (BaseView bv in gc.ViewCollection)
                {
                    if (bv is BandedGridView)
                    {
                        BandedGridView view = bv as BandedGridView;
                        if (provinceId.Length > 0 & view.Name == "Province")
                        {
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                string id = "";
                                if (view.GetRowCellValue(i, "Province.ProvinceId") != null)
                                    id = view.GetRowCellValue(i, "Province.ProvinceId").ToString();

                                if (id == provinceId)
                                {
                                    view.ExpandMasterRow(i);
                                    view.Focus();
                                    view.TopRowIndex = i;
                                    view.FocusedRowHandle = i;
                                    goto step2;
                                }
                            }
                        }
                    }
                }
            step2:
                ////////////////////////////
                foreach (BaseView bv in gc.ViewCollection)
                {
                    if (bv is BandedGridView)
                    {
                        BandedGridView view = bv as BandedGridView;

                        if (domainId.Length > 0 & view.Name == "Domains")
                        {
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                string id = "";
                                if (view.GetRowCellValue(i, "Domains.DomainId") != null)
                                    id = view.GetRowCellValue(i, "Domains.DomainId").ToString();

                                if (id == domainId)
                                {
                                    if (branchId.Length > 0)
                                        view.ExpandMasterRow(i);

                                    view.Focus();
                                    view.TopRowIndex = i;
                                    view.FocusedRowHandle = i;
                                    goto step3;
                                }
                            }
                        }
                    }
                }
            step3:
                ////////////////////////////
                foreach (BaseView bv in gc.ViewCollection)
                {
                    if (bv is BandedGridView)
                    {
                        BandedGridView view = bv as BandedGridView;

                        if (domainId.Length > 0 & view.Name == "Branches")
                        {
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                string id = "";
                                if (view.GetRowCellValue(i, "Branches.BranchId") != null)
                                    id = view.GetRowCellValue(i, "Branches.BranchId").ToString();

                                if (id == branchId)
                                {
                                    view.ExpandMasterRow(i);
                                    view.Focus();
                                    view.TopRowIndex = i;
                                    view.FocusedRowHandle = i;
                                    break;
                                }
                            }
                        }
                    }
                }
                //////////////////////////// 
                #endregion
            }
            catch
            {
            }
        }
    }
}
