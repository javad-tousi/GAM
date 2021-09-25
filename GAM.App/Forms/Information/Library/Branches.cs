using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Xml.Linq;
using System.Data.OleDb;
using System.Data;
using System;
using GAM.Connections;
using GAM.Forms.Profile.Kargozini.Library;

namespace GAM.Forms.Information.Library
{
    public class Branches
    {
        static Dictionary<int, ZoneInfo> ZonesList = new Dictionary<int, ZoneInfo>();
        static Dictionary<int, ProvinceInfo> ProvincesList = new Dictionary<int, ProvinceInfo>();
        static Dictionary<int, DomainInfo> DomainsList = new Dictionary<int, DomainInfo>();
        static Dictionary<int, BranchInfo> BranchesList = new Dictionary<int, BranchInfo>();
        static Dictionary<int, CounterInfo> CountersList = new Dictionary<int, CounterInfo>();
        static Dictionary<int, OfficeInfo> OfficesList = new Dictionary<int, OfficeInfo>();

        #region Properties

        static DataTable _domainsInfo = new DataTable();
        public static DataTable DomainsInfo
        {
            get
            {
                if (_domainsInfo.Columns.Count == 0 & _domainsInfo.Rows.Count == 0)
                {
                    _domainsInfo.Columns.Add("DomainId");
                    _domainsInfo.Columns.Add("DomainName");

                    foreach (var dm in DomainsList.OrderBy(x => x.Value.SortKey))
                    {
                        DomainInfo di = dm.Value;
                        if (di.IsEnable)
                        {
                            DataRow row = _domainsInfo.NewRow();
                            row["DomainId"] = di.DomainId;
                            row["DomainName"] = di.DomainName;
                            _domainsInfo.Rows.Add(row);
                        }
                    }
                }

                return _domainsInfo;
            }
        }

        static DataTable _branchesInfo = new DataTable();
        public static DataTable BranchesInfo
        {
            get
            {
                if (_branchesInfo.Columns.Count == 0 & _branchesInfo.Rows.Count == 0)
                {
                    _branchesInfo.Columns.Add("BranchId");
                    _branchesInfo.Columns.Add("BranchName");
                    _branchesInfo.Columns.Add("BranchDegree");
                    _branchesInfo.Columns.Add("ManagerName");
                    _branchesInfo.Columns.Add("DomainId");
                    _branchesInfo.Columns.Add("DomainName");
                    _branchesInfo.Columns.Add("BranchCity");
                    _branchesInfo.Columns.Add("BranchTells");
                    _branchesInfo.Columns.Add("BranchAddress");

                    foreach (var br in BranchesList.OrderBy(x => x.Value.Domain.SortKey).ThenBy(x => x.Value.BranchId))
                    {
                        BranchInfo bi = br.Value;
                        if (bi.IsEnable & bi.BranchType.Contains("شعبه"))
                        {
                            DataRow row = _branchesInfo.NewRow();
                            DataRow r = PersonelsManager.GetEmployeeInBranchByPostId(int.Parse(bi.BranchId), 35997);
                            row["BranchId"] = bi.BranchId;
                            row["BranchName"] = bi.BranchName;
                            row["BranchDegree"] = bi.BranchDegree;
                            if (r != null)
                                row["ManagerName"] = r["FullName"].ToString();
                            row["DomainId"] = bi.Domain.DomainId;
                            row["DomainName"] = bi.Domain.DomainName;
                            row["BranchCity"] = bi.BranchCity;
                            row["BranchTells"] = bi.BranchTells;
                            row["BranchAddress"] = bi.BranchAddress;

                            _branchesInfo.Rows.Add(row);
                        }
                    }
                }

                return _branchesInfo;
            }
        }

        static DataTable _countersInfo = new DataTable();
        public static DataTable CountersInfo
        {
            get
            {
                if (_countersInfo.Columns.Count == 0 & _countersInfo.Rows.Count == 0)
                {
                    _countersInfo.Columns.Add("CounterId");
                    _countersInfo.Columns.Add("CounterName");
                    _countersInfo.Columns.Add("BranchId");
                    _countersInfo.Columns.Add("BranchName");
                    _countersInfo.Columns.Add("ManagerName");

                    foreach (var co in CountersList.OrderBy(x => x.Key))
                    {
                        CounterInfo ci = co.Value;
                        if (ci.IsEnable)
                        {
                            DataRow row = _countersInfo.NewRow();
                            row["CounterId"] = ci.CounterId;
                            row["CounterName"] = ci.CounterName;
                            row["BranchId"] = ci.Branch.BranchId;
                            row["BranchName"] = ci.Branch.BranchName;
                            _countersInfo.Rows.Add(row);
                        }
                    }
                }

                return _countersInfo;
            }
        }

        static DataTable _officesInfo = new DataTable();
        public static DataTable OfficesInfo
        {
            get
            {
                if (_officesInfo.Columns.Count == 0 & _officesInfo.Rows.Count == 0)
                {
                    _officesInfo.Columns.Add("OfficeId");
                    _officesInfo.Columns.Add("OfficeName");

                    foreach (var co in OfficesList.OrderBy(x => x.Key))
                    {
                        OfficeInfo ci = co.Value;
                        if (ci.IsEnable)
                        {
                            DataRow row = _officesInfo.NewRow();
                            row["OfficeId"] = ci.OfficeId;
                            row["OfficeName"] = ci.OfficeName;
                            _officesInfo.Rows.Add(row);
                        }
                    }
                }

                return _officesInfo;
            }
        }

        #endregion

        #region UnitInfo Classes

        public class ZoneInfo
        {
            public ZoneInfo(object isEnable, object zoneId, object zoneId_key2, object zoneName)
            {
                IsEnable = bool.Parse(isEnable.ToString());
                ZoneId = zoneId.ToString();
                ZoneId_Key2 = zoneId_key2.ToString();
                ZoneName = zoneName.ToString();
            }

            public bool IsEnable;
            public string ZoneId;
            public string ZoneId_Key2;
            public string ZoneName;

            public static ZoneInfo Blank()
            {
                return new ZoneInfo(false, 0, 0, "");
            }
        }

        public class ProvinceInfo
        {
            public ProvinceInfo(object isEnable, object zoneId, object provinceId, object provinceId_key2, object provinceName)
            {
                if (ZonesList.ContainsKey(int.Parse(zoneId.ToString())))
                {
                    Zone = ZonesList[int.Parse(zoneId.ToString())];
                }

                IsEnable = bool.Parse(isEnable.ToString());
                ProvinceId = provinceId.ToString();
                ProvinceId_Key2 = provinceId_key2.ToString();
                ProvinceName = provinceName.ToString();
            }

            public bool IsEnable;
            public ZoneInfo Zone;
            public string ProvinceId;
            public string ProvinceId_Key2;
            public string ProvinceName;

            public static ProvinceInfo Blank()
            {
                return new ProvinceInfo(false, 0, 0, 0, "");
            }
        }

        public class DomainInfo
        {
            public DomainInfo(object isEnable, object provinceId, object domainId, object domainId_key2, object parentDomainId, object domainName, object sortKey)
            {
                if (ProvincesList.ContainsKey(int.Parse(provinceId.ToString())))
                {
                    Province = ProvincesList[int.Parse(provinceId.ToString())];
                    Zone = Province.Zone;
                }

                IsEnable = bool.Parse(isEnable.ToString());
                DomainId = domainId.ToString();
                DomainId_Key2 = domainId_key2.ToString();
                ParentDomainId = parentDomainId.ToString();
                DomainName = domainName.ToString();
                SortKey = Numeral.AnyToInt32(sortKey);
            }

            public ZoneInfo Zone;
            public ProvinceInfo Province;
            public bool IsEnable;
            public string DomainId;
            public string DomainId_Key2;
            public string ParentDomainId;
            public string DomainName;
            public int SortKey;

            public static DomainInfo Blank()
            {
                return new DomainInfo(false, 0, 0, 0, "", "", 99);
            }
        }

        public class BranchInfo
        {
            public BranchInfo(object isEnable, object domainId, object branchId, object branchId_key2, object parentBranchId, object branchName, object branchDegree, object branchType, object branchCity, object branchAddress, object branchTells)
            {
                if (DomainsList.ContainsKey(int.Parse(domainId.ToString())))
                {
                    Domain = DomainsList[int.Parse(domainId.ToString())];
                    Zone = Domain.Zone;
                    Province = Domain.Province;
                }

                IsEnable = bool.Parse(isEnable.ToString());
                BranchId = branchId.ToString();
                BranchId_Key2 = branchId_key2.ToString();
                ParentBranchId = parentBranchId.ToString();
                BranchName = branchName.ToString();
                BranchDegree = branchDegree.ToString();
                BranchType = branchType.ToString();
                BranchCity = branchCity.ToString();
                BranchAddress = branchAddress.ToString();
                BranchTells = branchTells.ToString();
            }

            public ZoneInfo Zone;
            public ProvinceInfo Province;
            public DomainInfo Domain;
            public bool IsEnable;
            public string BranchId;
            public string BranchId_Key2;
            public string ParentBranchId;
            public string BranchName;
            public string BranchDegree;
            public string BranchType;
            public string BranchCity;
            public string BranchAddress;
            public string BranchTells;
            public string ShortBranchID
            {
                get
                {
                    if (this.BranchId.Length == 5)
                        return this.BranchId.Substring(0, 4);
                    else
                        return this.BranchId;
                }
            }

            public static BranchInfo Blank()
            {
                return new BranchInfo(false, 0, 0, 0, "", "", "", "", "", "", "");
            }
        }

        public class CounterInfo
        {
            public CounterInfo(object isEnable, object branchId, object counterId, object counterName)
            {
                if (BranchesList.ContainsKey(int.Parse(branchId.ToString())))
                {
                    Branch = BranchesList[int.Parse(branchId.ToString())];
                    Domain = Branch.Domain;
                    Zone = Domain.Zone;
                    Province = Domain.Province;
                }

                IsEnable = bool.Parse(isEnable.ToString());
                CounterId = counterId.ToString();
                CounterName = counterName.ToString();
            }

            public ZoneInfo Zone;
            public ProvinceInfo Province;
            public DomainInfo Domain;
            public BranchInfo Branch;
            public bool IsEnable;
            public string CounterId;
            public string CounterName;

            public static CounterInfo Blank()
            {
                return new CounterInfo(false, 0, 0, "");
            }
        }

        public class OfficeInfo
        {
            public OfficeInfo(object isEnable, object officeId, object officeId_key2, object officeName)
            {
                IsEnable = bool.Parse(isEnable.ToString());
                OfficeId = officeId.ToString();
                OfficeId_Key2 = officeId_key2.ToString();
                OfficeName = officeName.ToString();
            }

            public bool IsEnable;
            public string OfficeId;
            public string OfficeId_Key2;
            public string OfficeName;

            public static OfficeInfo Blank()
            {
                return new OfficeInfo(false, 0, 0, "");
            }
        }

        #endregion

        public static void Fill()
        {
            ZonesList.Clear();
            ProvincesList.Clear();
            DomainsList.Clear();
            BranchesList.Clear();
            CountersList.Clear();
            OfficesList.Clear();

            using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetMasterDatabase("DB_Master.mdb")))
            {
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [Zones]";
                var dataReader = cmd.ExecuteReader();
                DataTable dataZones = new DataTable();
                dataZones.Load(dataReader);

                cmd.CommandText = "SELECT * FROM [Provinces]";
                dataReader = cmd.ExecuteReader();
                DataTable dataProvinces = new DataTable();
                dataProvinces.Load(dataReader);

                cmd.CommandText = "SELECT * FROM [Domains] ORDER BY [SortKey]";
                dataReader = cmd.ExecuteReader();
                DataTable dataDomains = new DataTable();
                dataDomains.Load(dataReader);

                cmd.CommandText = "SELECT * FROM [Branches] ORDER BY [BranchID]";
                dataReader = cmd.ExecuteReader();
                DataTable dataBranches = new DataTable();
                dataBranches.Load(dataReader);

                cmd.CommandText = "SELECT * FROM [Counters]";
                dataReader = cmd.ExecuteReader();
                DataTable dataCounters = new DataTable();
                dataCounters.Load(dataReader);

                cmd.CommandText = "SELECT * FROM [Offices]";
                dataReader = cmd.ExecuteReader();
                DataTable dataOffices = new DataTable();
                dataOffices.Load(dataReader);

                objConn.Close();

                ZonesList.Clear();
                ProvincesList.Clear();
                DomainsList.Clear();
                BranchesList.Clear();
                CountersList.Clear();
                OfficesList.Clear();

                foreach (DataRow r in dataZones.Rows)
                    ZonesList.Add(Numeral.AnyToInt32(r["ZoneID"]), new ZoneInfo(r["IsEnable"], r["ZoneID"], r["ZoneID_Key2"], r["ZoneName"]));
                foreach (DataRow r in dataProvinces.Rows)
                    ProvincesList.Add(Numeral.AnyToInt32(r["ProvinceID"]), new ProvinceInfo(r["IsEnable"], r["ZoneID"], r["ProvinceID"], r["ProvinceID_Key2"], r["ProvinceName"]));
                foreach (DataRow r in dataDomains.Rows)
                    DomainsList.Add(Numeral.AnyToInt32(r["DomainID"]), new DomainInfo(r["IsEnable"], r["ProvinceID"], r["DomainID"], r["DomainID_Key2"], r["ParentDomainID"], r["DomainName"], r["SortKey"]));
                foreach (DataRow r in dataBranches.Rows)
                    BranchesList.Add(Numeral.AnyToInt32(r["BranchID"]), new BranchInfo(r["IsEnable"], r["DomainID"], r["BranchID"], r["BranchID_Key2"], r["ParentBranchID"], r["BranchName"], r["BranchDegree"], r["BranchType"], r["BranchCity"], r["BranchAddress"], r["BranchTells"]));
                foreach (DataRow r in dataCounters.Rows)
                    CountersList.Add(Numeral.AnyToInt32(r["CounterID"]), new CounterInfo(r["IsEnable"], r["BranchID"], r["CounterID"], r["CounterName"]));
                foreach (DataRow r in dataOffices.Rows)
                    OfficesList.Add(Numeral.AnyToInt32(r["OfficeID"]), new OfficeInfo(r["IsEnable"], r["OfficeID"], r["OfficeID_Key2"], r["OfficeName"]));
            }
        }

        public static DataTable GetBranchTells(string branchId)
        {
            DataTable tablePhones = new DataTable();
            tablePhones.Columns.Add("Name");
            tablePhones.Columns.Add("Tells");

            string strConnection = OLEDB.GetMasterDatabase("DB_Master.mdb");
            OleDbConnection objConn = new OleDbConnection(strConnection);
            objConn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = objConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("SELECT * FROM [Branches] WHERE [BranchID] = {0}", branchId);
            var dataReader = cmd.ExecuteReader();
            DataTable dtable = new DataTable();
            dtable.Load(dataReader);
            objConn.Close();
            if (dtable != null && dtable.Rows.Count == 1)
            {
                tablePhones.Rows.Add("ریاست", dtable.Rows[0]["Tell1"].ToString());
                tablePhones.Rows.Add("معاونت", dtable.Rows[0]["Tell2"].ToString());
                tablePhones.Rows.Add("اعتبارات", dtable.Rows[0]["TellETB"].ToString());
                tablePhones.Rows.Add("واحد ارزی", dtable.Rows[0]["TellARZ"].ToString());
                tablePhones.Rows.Add("گروه سپرده و خدمات", dtable.Rows[0]["TellSEP"].ToString());
                tablePhones.Rows.Add("فاکس", dtable.Rows[0]["TellFAX"].ToString());
            }
            else 
            {
                tablePhones.Rows.Add("ریاست", "");
                tablePhones.Rows.Add("معاونت", "");
                tablePhones.Rows.Add("اعتبارات", "");
                tablePhones.Rows.Add("واحد ارزی", "");
                tablePhones.Rows.Add("گروه سپرده و خدمات", "");
                tablePhones.Rows.Add("فاکس", "");
            }

            return tablePhones;
        }

        public static bool UpdateBranchTells(string branchId, string tell1, string tell2, string tellEtb, string tellArz, string tellSep, string tellFax)
        {
            string strConnection = OLEDB.GetMasterDatabase("DB_Master.mdb");
            OleDbConnection objConn = new OleDbConnection(strConnection);
            objConn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = objConn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE [Branches] SET [Tell1]=@Tell1, [Tell2]=@Tell2, [TellETB]=@TellETB, [TellARZ]=@TellARZ, [TellSEP]=@TellSEP, [TellFAX]=@TellFAX WHERE [BranchID]=@BranchID";
            cmd.Parameters.AddWithValue("Tell1", tell1);
            cmd.Parameters.AddWithValue("Tell2", tell2);
            cmd.Parameters.AddWithValue("TellETB", tellEtb);
            cmd.Parameters.AddWithValue("TellARZ", tellArz);
            cmd.Parameters.AddWithValue("TellSEP", tellSep);
            cmd.Parameters.AddWithValue("TellFAX", tellFax);
            cmd.Parameters.AddWithValue("BranchID", branchId);

            int queryResult = cmd.ExecuteNonQuery();
            objConn.Close();
            if (queryResult == 1)
                return true;

            return false;
        }
     
        public static bool IsProvince(string str)
        {
            if (Numeral.IsNumber(str))
            {
                if (ProvincesList.ContainsKey(int.Parse(str)))
                    return true;
                if (ProvincesList.Count(x => x.Value.ProvinceId_Key2 == str) == 1)
                    return true;
            }
            return false;
        }
    
        public static bool IsDomain(string str)
        {
            if (Numeral.IsNumber(str))
            {
                if (DomainsList.ContainsKey(int.Parse(str)))
                    return true;
                if (DomainsList.Count(x => x.Value.DomainId_Key2 == str) == 1)
                    return true;
            }
            return false;
        }

        public static bool IsBranch(string str)
        {
            if (Numeral.IsNumber(str))
            {
                if (BranchesList.ContainsKey(int.Parse(str)))
                    return true;
                if (BranchesList.Count(x => x.Value.BranchId_Key2 == str) == 1)
                    return true;
            }
            return false;
        }

        public static bool IsCounter(string str)
        {
            if (Numeral.IsNumber(str))
            {
                if (CountersList.ContainsKey(int.Parse(str)))
                    return true;
            }
            return false;
        }

        public static bool IsOffice(string str)
        {
            if (Numeral.IsNumber(str))
            {
                if (OfficesList.ContainsKey(int.Parse(str)))
                    return true;
                if (OfficesList.Count(x => x.Value.OfficeId_Key2 == str) == 1)
                    return true;
            }
            return false;
        }

        public static List<ZoneInfo> GetAllZones()
        {
            return ZonesList.Select(x => x.Value).ToList();
        }

        public static ZoneInfo GetMyZone()
        {
            return ZonesList.First().Value;
        }

        public static ProvinceInfo GetMyProvince()
        {
            if (Users.MyProvinceID.Length > 0)
                return ProvincesList[int.Parse(Users.MyProvinceID)];
            return null;
        }

        public static List<ProvinceInfo> GetProvincesByZoneId(string zoneId)
        {
            if (Numeral.IsNumber(zoneId))
            {
               return ProvincesList.Where(x => x.Value.Zone.ZoneId == zoneId).Select(x => x.Value).ToList();
            }
            throw new Exception(string.Format("Error in GetProvincesByZoneID({0}) function.", zoneId));
        }

        public static List<DomainInfo> GetDomainsByProvinceId(string provinceId)
        {
            if (Numeral.IsNumber(provinceId))
            {
                return DomainsList.Where(x => x.Value.IsEnable & x.Value.Province.ProvinceId == provinceId).Select(x => x.Value).ToList();
            }
            throw new Exception(string.Format("Error in GetDomainsByProvinceID({0}) function.", provinceId));
        }

        public static ProvinceInfo GetProvinceById(string provinceId)
        {
            if (Numeral.IsNumber(provinceId))
            {
                if (ProvincesList.ContainsKey(int.Parse(provinceId)))
                {
                    ProvinceInfo pi = ProvincesList[int.Parse(provinceId)];
                    return pi;
                }
                else
                {
                    if (ProvincesList.Count(x => x.Value.ProvinceId_Key2 == provinceId) == 1)
                        return ProvincesList.Where(x => x.Value.ProvinceId_Key2 == provinceId).First().Value;
                }
            }
            return ProvinceInfo.Blank();

            throw new Exception(string.Format("Error in GetProvinceByID({0}) function.", provinceId));
        }

        public static DomainInfo GetDomainById(string domainId, bool update)
        {
            if (Numeral.IsNumber(domainId))
            {
                if (DomainsList.ContainsKey(int.Parse(domainId)))
                {
                    DomainInfo di = DomainsList[int.Parse(domainId)];
                    if (update)
                    {
                        if (di.ParentDomainId.Length > 0)
                            di = DomainsList[int.Parse(di.ParentDomainId)];
                    }
                    return di;
                }

                if (DomainsList.Count(x => x.Value.DomainId_Key2 == domainId) == 1)
                {
                    DomainInfo di = DomainsList.Where(x => x.Value.DomainId_Key2 == domainId).First().Value;
                    if (update)
                    {
                        if (di.ParentDomainId.Length > 0)
                            di = DomainsList[int.Parse(di.ParentDomainId)];
                    }
                    return di;
                }
            }
            return DomainInfo.Blank();

            throw new Exception(string.Format("Error in GetDomainByID({0}) function.", domainId));
        }

        public static BranchInfo GetBranchById(string branchId, bool update)
        {
            if (Numeral.IsNumber(branchId))
            {
                if (BranchesList.ContainsKey(int.Parse(branchId)))
                {
                    BranchInfo bi = BranchesList[int.Parse(branchId)];
                    if (update)
                    {
                        if (bi.ParentBranchId.Length > 0)
                            bi = BranchesList[int.Parse(bi.ParentBranchId)];
                    }
                    return bi;
                }

                if (BranchesList.Count(x => x.Value.BranchId_Key2 == branchId) == 1)
                {
                    BranchInfo bi = BranchesList.Where(x => x.Value.BranchId_Key2 == branchId).First().Value;
                    if (update)
                    {
                        if (bi.ParentBranchId.Length > 0)
                            bi = BranchesList[int.Parse(bi.ParentBranchId)];
                    }
                    return bi;
                }
            }

           return BranchInfo.Blank();
           throw new Exception(string.Format("Error in GetBranchByID({0}) function.", branchId));
        }

        public static CounterInfo GetCounterById(string counterId)
        {
            if (Numeral.IsNumber(counterId))
            {
                if (CountersList.ContainsKey(int.Parse(counterId)))
                {
                    CounterInfo ci = CountersList[int.Parse(counterId)];
                    return ci;
                }
            }

            return CounterInfo.Blank();
            throw new Exception(string.Format("Error in GetBranchByID({0}) function.", counterId));
        }

        public static OfficeInfo GetOfficeById(string officeId)
        {
            if (Numeral.IsNumber(officeId))
            {
                if (OfficesList.ContainsKey(int.Parse(officeId)))
                {
                    OfficeInfo oi = OfficesList[int.Parse(officeId)];
                    return oi;
                }

                if (OfficesList.Count(x => x.Value.OfficeId_Key2 == officeId) == 1)
                {
                    OfficeInfo oi = OfficesList.Where(x => x.Value.OfficeId_Key2 == officeId).First().Value;
                    return oi;
                }
            }

            return OfficeInfo.Blank();
            throw new Exception(string.Format("Error in GetBranchByID({0}) function.", officeId));
        }

        public static string GetUnitNameById(string id)
        {
            if (Numeral.IsNumber(id))
            {
                if (IsBranch(id))
                    return GetBranchById(id, false).BranchName;
                if (IsDomain(id))
                    return GetDomainById(id, false).DomainName;
                if (IsOffice(id))
                    return GetOfficeById(id).OfficeName;
                if (IsCounter(id))
                    return GetCounterById(id).CounterName;
                if (IsProvince(id))
                    return GetProvinceById(id).ProvinceName;
            }

            return "تعریف نشده";
        }
        public static string GetUnitStandardId(string id)
        {
            if (Numeral.IsNumber(id))
            {
                if (IsBranch(id))
                    return GetBranchById(id, false).BranchId;
                if (IsDomain(id))
                    return GetDomainById(id, false).DomainId;
                if (IsOffice(id))
                    return GetOfficeById(id).OfficeId;
                if (IsCounter(id))
                    return GetCounterById(id).CounterId;
                if (IsProvince(id))
                    return GetProvinceById(id).ProvinceId;
            }

            return id;
        }

        public static string GetBranchTell(string branchId, string postName)//OK
        {
            if (Numeral.IsNumber(branchId))
            {
                if (BranchesList.ContainsKey(int.Parse(branchId)))
                {
                    System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
                    if (BranchesList[int.Parse(branchId)].BranchTells.Length > 0)
                    {
                        xdoc.LoadXml(BranchesList[int.Parse(branchId)].BranchTells);
                        foreach (System.Xml.XmlNode postNode in xdoc.GetElementsByTagName("Post"))
                        {
                            if (postNode.InnerText == postName)
                            {
                                foreach (System.Xml.XmlNode node in postNode.ParentNode.ChildNodes)
                                {
                                    if (node.Name == "Phone")
                                    {
                                        return node.InnerText;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return "-";
        }

        public static List<string> GetAllBranchsId()//OK
        {
            List<string> codes = new List<string>();
            foreach (var b in BranchesList)
            {
                if (b.Value.IsEnable)
                    codes.Add(b.Value.BranchId);
            }
            return codes;
        }

        public static int GetAllBranchsCount()//OK
        {
            return BranchesList.Count(x => x.Value.IsEnable);
        }

        public static List<BranchInfo> GetAllBranchs()//OK
        {
            List<BranchInfo> branches = new List<BranchInfo>();
            foreach (var b in BranchesList)
            {
                if (b.Value.IsEnable)
                    branches.Add(b.Value);
            }
            return branches;
        }
        public static List<BranchInfo> GetAllBranchs(string type)//OK
        {
            List<BranchInfo> branches = new List<BranchInfo>();
            foreach (var b in BranchesList)
            {
                if (b.Value.IsEnable & b.Value.BranchType.Contains(type))
                    branches.Add(b.Value);
            }
            return branches;
        }

        public static string[] GetAllBranchDegree()//OK
        {
            return BranchesList.Select(x => x.Value.BranchDegree).Distinct().ToArray();
        }

        public static List<string> GetDomainsId()//OK
        {
            List<string> codes = new List<string>();
            foreach (var d in DomainsList)
            {
                if (d.Value.IsEnable)
                    codes.Add(d.Value.DomainId);
            }
            return codes.ToList();
        }

        public static List<DomainInfo> GetDomains()//OK
        {
            List<DomainInfo> domains = new List<DomainInfo>();
            foreach (var d in DomainsList)
            {
                if (d.Value.IsEnable)
                    domains.Add(d.Value);
            }
            return domains.ToList();
        }

        public static int GetDomainSort(string domainId)//OK
        {
            if (Numeral.IsNumber(domainId))
            {
                if (DomainsList.ContainsKey(int.Parse(domainId)))
                    return DomainsList[int.Parse(domainId)].SortKey;
            }
            return 99;
        }

        public static List<BranchInfo> GetBranchesByDomainId(string domainId)//OK
        {
            if (Numeral.IsNumber(domainId))
            {
                return BranchesList.Where(x => x.Value.IsEnable & x.Value.Domain.DomainId == domainId).Select(x => x.Value).ToList();
            }
            throw new Exception(string.Format("Error in GetBranchesByDomainID({0}) function.", domainId));
        }

        public static string[] GetDomainBranchesId(string domainId)//OK
        {
            if (Numeral.IsNumber(domainId))
            {
                string[] br = BranchesList.Where(x => x.Value.IsEnable & x.Value.Domain.DomainId == domainId).Select(x => x.Value.BranchId).ToArray();
                if (br != null)
                    return br;
            }
            return new string[0];
        }

        public static int GetDomainBranchesCount(string domainId)//OK
        {
            if (Numeral.IsNumber(domainId))
            {
                int count = BranchesList.Count(x => x.Value.IsEnable & x.Value.Domain.DomainId == domainId);
                return count;
            }
            return 0;
        }
    }
}
