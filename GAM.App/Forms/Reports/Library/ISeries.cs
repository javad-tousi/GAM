using GAM.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GAM.Forms.Reports.Library
{
    public class ISeries
    {
        public class DataPoint : ICloneable
        {
            public DataPoint()
            { }
            public DataPoint(string branchId, string reportDate, string caption, double value)
            {
                this.BranchId = branchId;
                this.ReportDate = reportDate;
                this.Argument = UDF.GetDateString(reportDate);
                this.Caption = caption;
                this.Value = value;
            }
            public string BranchId;
            public string ReportDate;
            public string Argument;
            public string Caption;
            public double Value;

            public string Format
            {
                get
                {
                    if (Caption.Contains("درصد") | Caption == "نسبت" | Caption == "NPL")
                        return "'%'0.0";
                    else
                        return "#,##0";
                }
            }

            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        public class DatePoints
        {
            //اطلاعات نقطه - تاریخ
            public IDictionary<string, DataPoint> Points = new Dictionary<string, DataPoint>();
        }

        public class BranchSeries
        {
            //مقاطع - نوع مقایسه
            public string Year = string.Empty;
            public bool Visible = true;
            public IDictionary<string, DatePoints> Comparisons = new Dictionary<string, DatePoints>();
        }

        public static string XmlSerializer(object obj, string docName) 
        {
            if (obj is IDictionary<int, ISeries.BranchSeries>)
            {
                IDictionary<int, ISeries.BranchSeries> bs = (IDictionary<int, ISeries.BranchSeries>)obj;
                if (bs != null)
                {
                    StringBuilder sb = new StringBuilder();
                    XmlWriter xmlWriter = XmlWriter.Create(sb);

                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement(docName);
                    foreach (var b in bs)
                    {
                        xmlWriter.WriteStartElement("Branch");
                        xmlWriter.WriteElementString("Key", b.Key.ToString());
                        xmlWriter.WriteElementString("Visible", b.Value.Visible.ToString());
                        xmlWriter.WriteElementString("Year", b.Value.Year);

                        foreach (var c in b.Value.Comparisons)
                        {
                            xmlWriter.WriteStartElement("Comparisons");
                            xmlWriter.WriteElementString("Key", c.Key);

                            foreach (var p in c.Value.Points)
                            {
                                xmlWriter.WriteStartElement("Date");
                                xmlWriter.WriteElementString("Key", p.Key);

                                xmlWriter.WriteStartElement("Point");
                                xmlWriter.WriteElementString("ReportDate", p.Value.ReportDate.ToString());
                                xmlWriter.WriteElementString("BranchId", p.Value.BranchId);
                                xmlWriter.WriteElementString("Value", p.Value.Value.ToString());
                                xmlWriter.WriteElementString("Argument", p.Value.Argument);
                                xmlWriter.WriteElementString("Caption", p.Value.Caption);
                             
                                xmlWriter.WriteEndElement();
                                xmlWriter.WriteEndElement();
                            }

                            xmlWriter.WriteEndElement();
                        }

                        xmlWriter.WriteEndElement();
                    }

                    xmlWriter.WriteEndDocument();
                    xmlWriter.Close();
                    return sb.ToString();
                }
            }

            return string.Empty;
        }

        public static IDictionary<int, ISeries.BranchSeries> XmlDeserializes(string xml, string docName)
        {
            if (xml.Length > 0)
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(xml);
                IDictionary<int, ISeries.BranchSeries> bs = new Dictionary<int, ISeries.BranchSeries>();

                foreach (XmlNode xn in xdoc.GetElementsByTagName(docName))
                {
                    foreach (XmlNode xb in xn.SelectNodes("Branch"))
                    {
                        BranchSeries br = new BranchSeries();
                        br.Year = xb["Year"].InnerText;
                        br.Visible = bool.Parse(xb["Visible"].InnerText);
                        foreach (XmlNode xc in xb.SelectNodes("Comparisons"))
                        {
                            IDictionary<string, DatePoints> comparisons = new Dictionary<string, DatePoints>();
                            DatePoints datePoints = new DatePoints();

                            foreach (XmlNode xd in xc.SelectNodes("Date"))
                            {
                                foreach (XmlNode xp in xd.SelectNodes("Point"))
                                {
                                    DataPoint dp = new DataPoint();
                                    dp.Argument = xp["Argument"].InnerText;
                                    dp.BranchId = xp["BranchId"].InnerText;
                                    dp.Caption = xp["Caption"].InnerText;
                                    dp.ReportDate = xp["ReportDate"].InnerText;
                                    dp.Value = double.Parse(xp["Value"].InnerText);
                                    datePoints.Points.Add(xd["Key"].InnerText, dp);
                                }
                            }
                            br.Comparisons.Add(xc["Key"].InnerText, datePoints);
                        }
                        bs.Add(int.Parse(xb["Key"].InnerText), br);
                    }
                }
                return bs;
            }

            return null;
        }

    }
}
