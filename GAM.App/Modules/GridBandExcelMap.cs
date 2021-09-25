using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Modules
{
    public class XCell
    {
        public XCell(int row, int column, int length, int height, string text)
        {
            Row = row;
            Column = column;
            Length = length;
            Height = height;
            Text = text;
        }

        public int Row = 0;
        public int Column = 0;
        public int Length = 0;
        public int Height = 0;
        public string Text = "";

    }

    class GridBandExcelMap
    {
        public int LastBandLevelNo { get; set; }
        public List<XCell> BandCells { get; set; }
        public List<DataColumn> BandColumns { get; set; }

        public void Fill(BandedGridView bgv, DataTable tblMaster, int lastLevelNo)
        {
            this.BandColumns = new List<DataColumn>();
            if (tblMaster != null)
            {
                foreach (BandedGridColumn c in bgv.Columns.AsEnumerable().OrderBy(x => x.VisibleIndex))
                {
                    if (c.Visible)
                        this.BandColumns.Add(tblMaster.Columns[c.FieldName]);
                }
            }

            this.BandCells = new List<XCell>();
            List<GridBand> bands = new List<GridBand>();
            bands = GetAllBands(bgv.Bands[0]);
            bands.Insert(0, bgv.Bands.FirstVisibleBand);
            if (lastLevelNo == 0)
                this.LastBandLevelNo = bands.Select(x => x.BandLevel).Max() + 1;
            else
                this.LastBandLevelNo = lastLevelNo;

            Dictionary<GridBand, XCell> bands0 = new Dictionary<GridBand, XCell>();
            Dictionary<GridBand, XCell> bands1 = new Dictionary<GridBand, XCell>();
            Dictionary<GridBand, XCell> bands2 = new Dictionary<GridBand, XCell>();
            Dictionary<GridBand, XCell> bands3 = new Dictionary<GridBand, XCell>();

            foreach (GridBand band in bands)
            {
                if (band.Visible & band.BandLevel == 0)
                {
                    if (bands0.Count == 0)
                        bands0.Add(band, new XCell(band.BandLevel + 1, 1, new GridBandExcelMap().GetBandColumnsCount(band) - 1, 0, band.Caption));
                    else
                        bands0.Add(band, new XCell(band.BandLevel + 1, bands0.Last().Value.Column + bands0.Last().Value.Length + 1, new GridBandExcelMap().GetBandColumnsCount(band) - 1, 0, band.Caption));
                }
            }

            foreach (GridBand band in bands)
            {
                if (band.Visible & band.BandLevel == 1)
                {
                    foreach (var item in bands1.Reverse())
                    {
                        if (item.Key.ParentBand == band.ParentBand)
                        {
                            bands1.Add(band, new XCell(band.BandLevel + 1, item.Value.Column + item.Value.Length + 1, new GridBandExcelMap().GetBandColumnsCount(band) - 1, 0, band.Caption));
                            break;
                        }
                    }
                    if (!bands1.ContainsKey(band))
                        bands1.Add(band, new XCell(band.BandLevel + 1, bands0[band.ParentBand].Column, new GridBandExcelMap().GetBandColumnsCount(band) - 1, 0, band.Caption));
                }
            }

            foreach (GridBand band in bands)
            {
                if (band.Visible & band.BandLevel == 2)
                {
                    foreach (var item in bands2.Reverse())
                    {
                        if (item.Key.ParentBand == band.ParentBand)
                        {
                            bands2.Add(band, new XCell(band.BandLevel + 1, item.Value.Column + item.Value.Length + 1, new GridBandExcelMap().GetBandColumnsCount(band) - 1, 0, band.Caption));
                            break;
                        }
                    }
                    if (!bands2.ContainsKey(band))
                        bands2.Add(band, new XCell(band.BandLevel + 1, bands1[band.ParentBand].Column, new GridBandExcelMap().GetBandColumnsCount(band) - 1, 0, band.Caption));
                }
            }

            foreach (GridBand band in bands)
            {
                if (band.Visible & band.BandLevel == 3)
                {
                    foreach (var item in bands3.Reverse())
                    {
                        if (item.Key.ParentBand == band.ParentBand)
                        {
                            bands3.Add(band, new XCell(band.BandLevel + 1, item.Value.Column + item.Value.Length + 1, new GridBandExcelMap().GetBandColumnsCount(band) - 1, 0, band.Caption));
                            break;
                        }
                    }
                    if (!bands3.ContainsKey(band))
                        bands3.Add(band, new XCell(band.BandLevel + 1, bands2[band.ParentBand].Column, new GridBandExcelMap().GetBandColumnsCount(band) - 1, 0, band.Caption));
                }
            }


            foreach (var item in bands0)
            {
                if (!item.Key.HasChildren)
                    item.Value.Height = this.LastBandLevelNo - 1;
                this.BandCells.Add(item.Value);
            }
            foreach (var item in bands1)
            {
                if (!item.Key.HasChildren)
                    item.Value.Height = this.LastBandLevelNo - 2;
                this.BandCells.Add(item.Value);
            }
            foreach (var item in bands2)
            {
                if (!item.Key.HasChildren)
                    item.Value.Height = this.LastBandLevelNo - 3;
                this.BandCells.Add(item.Value);
            }
            foreach (var item in bands3)
            {
                this.BandCells.Add(item.Value);
            }
        }

        List<GridBand> allBands = new List<GridBand>();
        private List<GridBand> GetAllBands(GridBand band)
        {
            if (band.HasChildren) //a parent band  
                foreach (GridBand childBand in band.Children)
                {
                    GetAllBands(childBand);
                    allBands.Add(childBand);
                }
            return allBands;
        }

        int countColumns = 0;
        private int GetBandColumnsCount(GridBand band)
        {
            if (band.Children.Count > 0) //a parent band  
                foreach (GridBand childBand in band.Children)
                    GetBandColumnsCount(childBand);
            else
            {
                foreach (BandedGridColumn column in band.Columns)
                {
                    if (column.Visible)
                        ++countColumns;
                }
            }

            return countColumns;
        }

        public static string GetXlsColNameByNo(int number)
        {
            int D = 0;
            int M = 0;
            string Name = string.Empty;
            D = number;
            while ((D > 0))
            {
                M = (D - 1) % 26;
                Name = Convert.ToChar(65 + M) + Name;
                D = ((D - M) / 26);
            }
            return Name;
        }

    }
}
