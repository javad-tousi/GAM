using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GAM.Modules
{
    public class UDF
    {
        public static string CheckCommand(System.Data.OleDb.OleDbCommand cmd)
        {
            string result = cmd.CommandText.ToString();
            int counter = 0;
            foreach (System.Data.OleDb.OleDbParameter param in cmd.Parameters)
            {
                counter++;
                string dataType = param.Value.GetType().FullName;
                if (dataType == "System.String")
                    result = result.Replace(param.ParameterName, counter.ToString());
                else if (dataType == "System.DBNull")
                    result = result.Replace(param.ParameterName, counter.ToString());
                else
                    result = result.Replace(param.ParameterName, counter.ToString());
            }
            return result;
        }

        public static string ShowCmdValues(System.Data.OleDb.OleDbCommand cmd)
        {
            string result = cmd.CommandText.ToString();
            foreach (System.Data.OleDb.OleDbParameter param in cmd.Parameters)
            {
                string dataType = param.Value.GetType().FullName;
                if (dataType == "System.String")
                    result = result.Replace('@' + param.ParameterName, string.Format("'{0}'", param.Value.ToString()));
                else if (dataType == "System.DBNull")
                    result = result.Replace('@' + param.ParameterName, "NULL");
                else
                    result = result.Replace('@' + param.ParameterName, param.Value.ToString());
            }
            return result;
        }

        public static void ToFarsiLanguage()
        {
            try
            {
                var myCurrentLanguage = new System.Globalization.CultureInfo("fa-IR", true);
                System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(myCurrentLanguage);
            }
            catch { }
        }
        public static void ToEnglishLanguage()
        {
            try
            {
                var myCurrentLanguage = new System.Globalization.CultureInfo("en-US", true);
                System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(myCurrentLanguage);
            }
            catch { }
        }

        public static System.Drawing.Bitmap GrayscaleImage(System.Drawing.Bitmap original)
        {
            //create a blank bitmap the same size as original
            System.Drawing.Bitmap newBitmap = new System.Drawing.Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(
               new float[][] 
                            {
                               new float[] {.3f, .3f, .3f, 0, 0},
                               new float[] {.59f, .59f, .59f, 0, 0},
                               new float[] {.11f, .11f, .11f, 0, 0},
                               new float[] {0, 0, 0, 1, 0},
                               new float[] {0, 0, 0, 0, 1}
                            });

            //create some image attributes
            System.Drawing.Imaging.ImageAttributes attributes = new System.Drawing.Imaging.ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new System.Drawing.Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, System.Drawing.GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        public static string[] SplitString(string inputStr)
        {
            string[] output = inputStr.Split('[', ']');
            List<string> list = new List<string>();
            for (int i = 0; i <= output.Length - 1; i++)
            {
                if (i % 2 != 0)
                {
                    list.Add(output[i]);
                }
            }
            return list.ToArray();
        }

        public static string StrUnionAll(string[] tablesName, string cmd)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(cmd + " FROM [" + tablesName[0] + "] ");
            if (tablesName.Length > 1)
            {
                for (int i = 0; i < tablesName.Length - 1; i++)
                {
                    sb.Append(" UNION ALL " + cmd + " FROM [" + tablesName[i + 1] + "] ");
                }
            }
            return sb.ToString();
        }
        public static string StrUnionAll(string[] tablesName, string cmd, string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(cmd + " FROM [" + tablesName[0] + "] " + where);
            if (tablesName.Length > 1)
            {
                for (int i = 0; i < tablesName.Length - 1; i++)
                {
                    sb.Append(" UNION ALL " + cmd + " FROM [" + tablesName[i + 1] + "] " + where);
                }
            }
            return sb.ToString();
        }

        public static Stream StringToStream(string str)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(str);
            MemoryStream stream = new MemoryStream(byteArray);
            return stream;
        }
        public static string StreamToString(MemoryStream stream)
        {
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static DataTable CopyTableCaptions(DataTable newDataTable, DataTable masterDataTable)
        {
            try
            {
                foreach (DataColumn col in masterDataTable.Columns)
                {
                    if (newDataTable.Columns.Contains(col.ColumnName))
                    {
                        newDataTable.Columns[col.ColumnName].Caption = col.Caption;
                    }
                }
                return newDataTable;
            }
            catch
            {
                return null;
            }
        }

        public static string GetMonthName(string number)
        {
            switch (int.Parse(number))
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
                default:
                    return "";
            }
        }

        public static bool IsValidCodeMeli(string input)
        {
            string text = input.Replace("-","");
            // input has 10 digits that all of them are not equal
            if (!System.Text.RegularExpressions.Regex.IsMatch(text, @"^(?!(\d)\1{9})\d{10}$"))
                return false;

            var check = Convert.ToInt32(text.Substring(9, 1));
            var sum = Enumerable.Range(0, 9)
                .Select(x => Convert.ToInt32(text.Substring(x, 1)) * (10 - x))
                .Sum() % 11;

            return sum < 2 && check == sum || sum >= 2 && check + sum == 11;
        }

        public static bool IsValidShenaseMeli(string input)
        {
            Int64 L = input.Length;

            if (L < 11 || Convert.ToInt64(input, 10) == 0) return false;

            if (Convert.ToInt64(input.Substring(3, 6), 10) == 0) return false;
            Int64 c = Convert.ToInt64(input.Substring(10, 1), 10);
            Int64 d = Convert.ToInt64(input.Substring(9, 1), 10) + 2;
            Int64[] z = new Int64[] { 29, 27, 23, 19, 17 };
            Int64 s = 0;
            for (int i = 0; i < 10; i++)
                s += (d + Convert.ToInt64(input.Substring(i, 1), 10)) * z[i % 5];
            s = s % 11; if (s == 10) s = 0;
            return (c == s);
        }

        private static Random random = new Random();
        public static string GetRndStr(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string rndStr = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            if (char.IsDigit(rndStr[0]))
            {
                rndStr.Remove(0);
                rndStr = rndStr + random.Next(chars.Length);
            }

            return rndStr;
        }

        public static string ConvertDatatableToXML(DataTable dt, string name)
        {
            dt.TableName = name;
            System.IO.MemoryStream str = new System.IO.MemoryStream();
            dt.WriteXml(str, true);
            str.Seek(0, System.IO.SeekOrigin.Begin);
            System.IO.StreamReader sr = new System.IO.StreamReader(str);
            string xmlstr;
            xmlstr = sr.ReadToEnd();
            return (xmlstr);
        }

        public static DataTable GetXmlToDatatable(string xml)
        {
            System.IO.StringReader strReader = new System.IO.StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(strReader);
            if (ds != null && ds.Tables.Count == 1)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static bool IsFileLocked(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            if (file.Exists)
            {
                FileStream stream = null;

                try
                {
                    stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
                }
                catch (IOException)
                {
                    return true;
                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }

                return false;
            }
            else
                return false;
        }

        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        public static System.Drawing.Point StringToPoint(string str)
        {
            System.Drawing.Point point = System.Drawing.Point.Empty;
            if (str.Contains(","))
            {
                string[] array = str.Split(',');
                point = new System.Drawing.Point(int.Parse(array[0]), int.Parse(array[1]));
            }
            return point;
        }

        public static string GetNodeXPath(XmlNode xmlNode)
        {
            string pathName = "";
            XmlNode node = xmlNode;
            while (node.ParentNode.Name != "#document")
            {
                if (node.ParentNode.Attributes.Count > 0)
                {
                    pathName = node.ParentNode.Attributes["Name"].Value + "." + pathName;
                    node = node.ParentNode;
                }
                else
                    node = node.ParentNode;
            }
            return pathName;
        }
        public static string GetNodeXPath(XmlNode xmlNode, int number)
        {
            string pathName = "";
            XmlNode node = xmlNode;
            while (node.ParentNode.Name != "#document")
            {
                if (node.ParentNode.Attributes.Count > 0)
                {
                    pathName = node.ParentNode.Attributes["Name"].Value + number + "." + pathName;
                    node = node.ParentNode;
                }
                else
                    node = node.ParentNode;
            }
            return pathName;
        }


        public static string GetDateString(string date) 
        {
            if (PersianDateTime.IsValidDate(date))
            {
                return PersianDateTime.Parse(int.Parse(date)).ToShortDateString();
            }
            else 
            {
                if (date.Length == 6 & Numeral.IsNumber(date))
                {
                    string yyyy = date.Substring(0, 4);
                    string mm = date.Substring(4, 2);
                    return GetMonthName(mm) + " " + yyyy;
                }
            }
            return date;
        }

        public static string GetDateSerialAsFormated(int date)
        {
            if (date > 0)
            {
                if (date.ToString().Length == 8)
                {
                    var pd = PersianDateTime.Parse(date);
                    return pd.ToShortDateString();
                }
                if (date.ToString().Length == 6)
                {
                    return date.ToString().Substring(0, 4) + "/" + date.ToString().Substring(4, 2);
                }
            }

            return date.ToString();
        }

        public static string SetSheetName(string text)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= 30; i++)
            {
                if (i < text.Length)
                    sb.Append(text[i]);
            }
            return sb.ToString();
        }

    
    }

}
