using GAM.Connections;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAM.Modules
{
    class Backup
    {
        public static void Full()
        {
            string path = System.IO.Directory.CreateDirectory(@"D:\GAM.Backup\" + PersianDateTime.Now.ToShortDateInt()).FullName;

            string[] dirctories = System.IO.Directory.GetDirectories(OLEDB.GetNetworkPath(), "*.*", SearchOption.TopDirectoryOnly);
            foreach (string dr in dirctories)
            {
                string name = System.IO.Path.GetFileName(dr);
                new System.Threading.Thread(delegate() { ThreadCopy(dr, Path.Combine(path, name)); }).Start();
            }
        }

        private static bool CopyFileStream(string fileName, string destination)
        {
            byte[] buffer = new byte[4 * 1024]; // 4K buffer

            long reportsize = (128 * 1024); // report only on each 128K block
            long reporttally = 0;
            long OnProgressChanged = 0;
            try
            {
                using (FileStream source = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    long filelength = source.Length;

                    using (FileStream dest = new FileStream(destination, FileMode.Create, FileAccess.Write))
                    {
                        long totalBytes = 0;
                        int currentBlockSize = 0;

                        while ((currentBlockSize = source.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            dest.Write(buffer, 0, currentBlockSize);

                            totalBytes += currentBlockSize;

                            reporttally += currentBlockSize;
                            if (reporttally >= reportsize)
                            {
                                OnProgressChanged = (int)((double)totalBytes * 100 / (double)filelength);
                                reporttally = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private static void ThreadCopy(string src, string des)
        {
            DirectoryCopy.Start(src, des, true);
        }
    }
}
