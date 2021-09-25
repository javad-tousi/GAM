using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Connections
{
    public class OLEDB
    {
        public enum ConnectionModeType { Master, Backup, Local }
        public static ConnectionModeType ConnectionMode { get; set; }
        private static string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password=1190";
        private static string NetworkPath { get; set; }
        private static string LocalPath { get; set; }

        public static void Startup(string serverName, string shareFolder, string localPath)
        {
            NetworkPath = string.Format(@"\\{0}\{1}", serverName , shareFolder);
            LocalPath = localPath;
        }

        public static string GetNetworkPath()
        {
            return NetworkPath;
        }

        public static string GetLocalPath()
        {
            return LocalPath;
        }

        public static string GetDatabase(string dbName)
        {
            switch (ConnectionMode)
            {
                case ConnectionModeType.Master:
                    return string.Format(ConnectionString, NetworkPath + @"\GAM.Databases\" + dbName);
                case ConnectionModeType.Backup:
                    return string.Format(ConnectionString, NetworkPath + @"\GAM.Backup.Databases\" + dbName);
                case ConnectionModeType.Local:
                    return string.Format(ConnectionString, LocalPath + @"\GAM.Databases\" + dbName);
                default:
                    return string.Empty;
            }
        }

        public static string GetMasterDatabase(string dbName)
        {
            switch (ConnectionMode)
            {
                case ConnectionModeType.Master:
                    return string.Format(ConnectionString, NetworkPath + @"\GAM.Databases\" + dbName);
                case ConnectionModeType.Backup:
                    return string.Format(ConnectionString, NetworkPath + @"\GAM.Databases\" + dbName);
                case ConnectionModeType.Local:
                    return string.Format(ConnectionString, LocalPath + @"\GAM.Databases\" + dbName);
                default:
                    return string.Empty;
            }
        }

        public static string GetFormFile(string formId)
        {
            switch (ConnectionMode)
            {
                case ConnectionModeType.Master:
                    return NetworkPath + @"\GAM.Forms\" + formId;
                case ConnectionModeType.Backup:
                    return NetworkPath + @"\GAM.Forms\" + formId;
                case ConnectionModeType.Local:
                    return LocalPath + @"\GAM.Forms\" + formId;
                default:
                    return string.Empty;
            }
        }

        public static string GetTemplateFile(string templateName)
        {
            switch (ConnectionMode)
            {
                case ConnectionModeType.Master:
                    return NetworkPath + @"\GAM.Templates\" + templateName;
                case ConnectionModeType.Backup:
                    return NetworkPath + @"\GAM.Templates\" + templateName;
                case ConnectionModeType.Local:
                    return LocalPath + @"\GAM.Templates\" + templateName;
                default:
                    return string.Empty;
            }
        }

        public static string GetResourceFile(string fileName)
        {
            switch (ConnectionMode)
            {
                case ConnectionModeType.Master:
                    return NetworkPath + @"\GAM.Resources\" + fileName;
                case ConnectionModeType.Backup:
                    return NetworkPath + @"\GAM.Resources\" + fileName;
                case ConnectionModeType.Local:
                    return LocalPath + @"\GAM.Resources\" + fileName;
                default:
                    return string.Empty;
            }
        }

        public static string GetResourcesRoot()
        {
            switch (ConnectionMode)
            {
                case ConnectionModeType.Master:
                    return NetworkPath + @"\GAM.Resources\";
                case ConnectionModeType.Backup:
                    return NetworkPath + @"\GAM.Resources\";
                case ConnectionModeType.Local:
                    return LocalPath + @"\GAM.Resources\";
                default:
                    return string.Empty;
            }
        }

        public static Uri GetInstallFile(string fileName)
        {
            return new Uri(NetworkPath + @"\GAM.Install\" + fileName);
        }

        public static System.Diagnostics.FileVersionInfo GetInstallFileVersion()
        {
            string filePath = OLEDB.GetInstallFile("GAM.exe").LocalPath;
            if (System.IO.File.Exists(filePath))
                return System.Diagnostics.FileVersionInfo.GetVersionInfo(filePath);
            return null;
        }

        public static string GetFormsRoot()
        {
            return NetworkPath + @"\GAM.Forms\";
        }

        public static string GetInstallRoot()
        {
            return NetworkPath + @"\GAM.Install\";
        }

        public static string GetDatabasesRoot()
        {
            switch (ConnectionMode)
            {
                case ConnectionModeType.Master:
                    return NetworkPath + @"\GAM.Databases\";
                case ConnectionModeType.Backup:
                    return NetworkPath + @"\GAM.Backup.Databases\";
                case ConnectionModeType.Local:
                    return LocalPath + @"\GAM.Databases\";
                default:
                    return null;
            }
        }

        public static string GetShareRoot()
        {
            switch (ConnectionMode)
            {
                case ConnectionModeType.Master:
                    return NetworkPath + @"\GAM.Share\";
                case ConnectionModeType.Backup:
                    return NetworkPath + @"\GAM.Share\";
                case ConnectionModeType.Local:
                    return LocalPath + @"\GAM.Share\";
                default:
                    return null;
            }
        }

    }
}
