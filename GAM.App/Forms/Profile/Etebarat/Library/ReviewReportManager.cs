using GAM.Connections;
using GAM.Forms.Information.Library;
using GAM.Forms.Settings.Library;
using GAM.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Forms.Profile.Etebarat.Library
{
    class ReviewReportManager
    {
        public static string Insert(int referralDate, int branchId, string customerId, string customerName, string personalityType, string modirAmel, string noeFaaliyat, string bakhshFaaliyat, string noeMojavezShoghli, string noeMalekiyat, string vazeyatSanad, string tarikhGozaresh, string tarikhEtelaatEtebari, double sarmayeSabti, string tarikhHesabrasi, string tarikhSoratMali, double mojodiKala, double foroshDarSoratMali, double soodYaZiyanJari, double soodYaZiyanAnbashteh, double bedehiKotahmodat, double bedehiBolandmodat, string nesbatJari, string nesbatMalekaneh, string tarikhTaraz, double foroshDarTaraz, double estelamMellat1, double estelamMellat2, double estelamSayer1, double estelamSayer2, double estelamZinaf1, double estelamZinaf2, double estelamZinaf3, double estelamZinaf4, double bedehiPishnehad1, double bedehiPishnehad2, double mosavabeDarrah1, double mosavabeDarrah2, double saghfBedehiHad1, double saghfBedehiHad2, double saghfBedehiSaghf1, double saghfBedehiSaghf2, double saghfBedehiMoredi1, double saghfBedehiMoredi2, double jariBestankar1, double jariBestankar2, double jariMoadel1, double jariMoadel2, double kotahmodatBestankar1, double kotahmodatBestankar2, double kotahmodatMoadel1, double kotahmodatMoadel2, double gharzolhasanehBestankar1, double gharzolhasanehBestankar2, double gharzolhasanehMoadel1, double gharzolhasanehMoadel2, double sepordeh, double jariOldMoadel, double kotahmodatOldMoadel, double gharzolhasanehOldMoadel, string rotbehIranian, double tasviyehGharardad, double tasviyehTashilat, double tasviyehTaahodat, double afzayeshTashilat, double afzayeshTaahodat, double kaheshTashilat, double kaheshTaahodat, double varizTashilat, double varizTaahodat, string ask1, string ask2, string ask3, string ask4, string ask6, string ask7, string ask8, string ask9, string ask10, string ask11, string ask12, string ask13, string sharayetAkharinMosavabeh, string nazariyeKarshenas, string xmlRequests, int requestsCount)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "INSERT INTO [ReviewReports] ([RegisteredUserID], [RegisteredDate], [ModifierUserID], [ModifiedDate], [ModifiedTime], [ToUserID], [ReferralDate], [BranchID], [CustomerID], [CustomerName], [PersonalityType], [ModirAmel], [NoeFaaliyat], [BakhshFaaliyat], [NoeMojavezShoghli], [NoeMalekiyat], [VazeyatSanad], [TarikhGozaresh], [TarikhEtelaatEtebari], [SarmayeSabti], [TarikhHesabrasi], [TarikhSoratMali], [MojodiKala], [ForoshDarSoratMali], [SoodYaZiyanJari], [SoodYaZiyanAnbashteh], [BedehiKotahmodat], [BedehiBolandmodat], [NesbatJari], [NesbatMalekaneh], [TarikhTaraz], [ForoshDarTaraz], [EstelamMellat1], [EstelamMellat2], [EstelamSayer1], [EstelamSayer2], [EstelamZinaf1], [EstelamZinaf2], [EstelamZinaf3], [EstelamZinaf4], [BedehiPishnehad1], [BedehiPishnehad2], [MosavabeDarrah1], [MosavabeDarrah2], [SaghfBedehiHad1], [SaghfBedehiHad2], [SaghfBedehiSaghf1], [SaghfBedehiSaghf2], [SaghfBedehiMoredi1], [SaghfBedehiMoredi2], [JariBestankar1], [JariBestankar2], [JariMoadel1], [JariMoadel2], [KotahmodatBestankar1], [KotahmodatBestankar2], [KotahmodatMoadel1], [KotahmodatMoadel2], [GharzolhasanehBestankar1], [GharzolhasanehBestankar2], [GharzolhasanehMoadel1], [GharzolhasanehMoadel2], [Sepordeh], [JariOldMoadel], [KotahmodatOldMoadel], [GharzolhasanehOldMoadel], [RotbehIranian], [TasviyehGharardad], [TasviyehTashilat], [TasviyehTaahodat], [AfzayeshTashilat], [AfzayeshTaahodat], [KaheshTashilat], [KaheshTaahodat], [VarizTashilat], [VarizTaahodat], [Ask1], [Ask2], [Ask3], [Ask4], [Ask6], [Ask7], [Ask8], [Ask9], [Ask10], [Ask11], [Ask12], [Ask13], [SharayetAkharinMosavabeh], [NazariyeKarshenas], [XmlRequests], [RequestsCount]) VALUES (@RegisteredUserID, @RegisteredDate, @ModifierUserID, @ModifiedDate, @ModifiedTime, @ToUserID, @ReferralDate, @BranchID, @CustomerID, @CustomerName, @PersonalityType, @ModirAmel, @NoeFaaliyat, @BakhshFaaliyat, @NoeMojavezShoghli, @NoeMalekiyat, @VazeyatSanad, @TarikhGozaresh, @TarikhEtelaatEtebari, @SarmayeSabti, @TarikhHesabrasi, @TarikhSoratMali, @MojodiKala, @ForoshDarSoratMali, @SoodYaZiyanJari, @SoodYaZiyanAnbashteh, @BedehiKotahmodat, @BedehiBolandmodat, @NesbatJari, @NesbatMalekaneh, @TarikhTaraz, @ForoshDarTaraz, @EstelamMellat1, @EstelamMellat2, @EstelamSayer1, @EstelamSayer2, @EstelamZinaf1, @EstelamZinaf2, @EstelamZinaf3, @EstelamZinaf4, @BedehiPishnehad1, @BedehiPishnehad2, @MosavabeDarrah1, @MosavabeDarrah2, @SaghfBedehiHad1, @SaghfBedehiHad2, @SaghfBedehiSaghf1, @SaghfBedehiSaghf2, @SaghfBedehiMoredi1, @SaghfBedehiMoredi2, @JariBestankar1, @JariBestankar2, @JariMoadel1, @JariMoadel2, @KotahmodatBestankar1, @KotahmodatBestankar2, @KotahmodatMoadel1, @KotahmodatMoadel2, @GharzolhasanehBestankar1, @GharzolhasanehBestankar2, @GharzolhasanehMoadel1, @GharzolhasanehMoadel2, @Sepordeh, @JariOldMoadel, @KotahmodatOldMoadel, @GharzolhasanehOldMoadel, @RotbehIranian, @TasviyehGharardad, @TasviyehTashilat, @TasviyehTaahodat, @AfzayeshTashilat, @AfzayeshTaahodat, @KaheshTashilat, @KaheshTaahodat, @VarizTashilat, @VarizTaahodat, @Ask1, @Ask2, @Ask3, @Ask4, @Ask6, @Ask7, @Ask8, @Ask9, @Ask10, @Ask11, @Ask12, @Ask13, @SharayetAkharinMosavabeh, @NazariyeKarshenas, @XmlRequests, @RequestsCount)";
                    cmd.Parameters.AddWithValue("RegisteredUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("RegisteredDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                    cmd.Parameters.AddWithValue("ToUserID", Users.MyUserID);

                    cmd.Parameters.AddWithValue("ReferralDate", referralDate);
                    cmd.Parameters.AddWithValue("BranchID", branchId);
                    cmd.Parameters.AddWithValue("CustomerID", customerId);
                    cmd.Parameters.AddWithValue("CustomerName", customerName);
                    cmd.Parameters.AddWithValue("PersonalityType", personalityType);
                    
                    cmd.Parameters.AddWithValue("ModirAmel", modirAmel);
                    cmd.Parameters.AddWithValue("NoeFaaliyat", noeFaaliyat);
                    cmd.Parameters.AddWithValue("BakhshFaaliyat", bakhshFaaliyat);
                    cmd.Parameters.AddWithValue("NoeMojavezShoghli", noeMojavezShoghli);
                    cmd.Parameters.AddWithValue("NoeMalekiyat", noeMalekiyat);
                    cmd.Parameters.AddWithValue("VazeyatSanad", vazeyatSanad);
                    cmd.Parameters.AddWithValue("TarikhGozaresh", tarikhGozaresh);
                    cmd.Parameters.AddWithValue("TarikhEtelaatEtebari", tarikhEtelaatEtebari);
                    cmd.Parameters.AddWithValue("SarmayeSabti", sarmayeSabti);

                    cmd.Parameters.AddWithValue("TarikhHesabrasi", tarikhHesabrasi);
                    cmd.Parameters.AddWithValue("TarikhSoratMali", tarikhSoratMali);
                    cmd.Parameters.AddWithValue("MojodiKala", mojodiKala);
                    cmd.Parameters.AddWithValue("ForoshDarSoratMali", foroshDarSoratMali);

                    cmd.Parameters.AddWithValue("SoodYaZiyanJari", soodYaZiyanJari);
                    cmd.Parameters.AddWithValue("SoodYaZiyanAnbashteh", soodYaZiyanAnbashteh);
                    cmd.Parameters.AddWithValue("BedehiKotahmodat", bedehiKotahmodat);
                    cmd.Parameters.AddWithValue("BedehiBolandmodat", bedehiBolandmodat);
                    cmd.Parameters.AddWithValue("NesbatJari", nesbatJari);
                    cmd.Parameters.AddWithValue("NesbatMalekaneh", nesbatMalekaneh);
                    cmd.Parameters.AddWithValue("TarikhTaraz", tarikhTaraz);
                    cmd.Parameters.AddWithValue("ForoshDarTaraz", foroshDarTaraz);

                    cmd.Parameters.AddWithValue("EstelamMellat1", estelamMellat1);
                    cmd.Parameters.AddWithValue("EstelamMellat2", estelamMellat2);
                    cmd.Parameters.AddWithValue("EstelamSayer1", estelamSayer1);
                    cmd.Parameters.AddWithValue("EstelamSayer2", estelamSayer2);
                    cmd.Parameters.AddWithValue("EstelamZinaf1", estelamZinaf1);
                    cmd.Parameters.AddWithValue("EstelamZinaf2", estelamZinaf2);
                    cmd.Parameters.AddWithValue("EstelamZinaf3", estelamZinaf3);
                    cmd.Parameters.AddWithValue("EstelamZinaf4", estelamZinaf4);
                    cmd.Parameters.AddWithValue("BedehiPishnehad1", bedehiPishnehad1);
                    cmd.Parameters.AddWithValue("BedehiPishnehad2", bedehiPishnehad2);
                    cmd.Parameters.AddWithValue("MosavabeDarrah1", mosavabeDarrah1);
                    cmd.Parameters.AddWithValue("MosavabeDarrah2", mosavabeDarrah2);
                    cmd.Parameters.AddWithValue("SaghfBedehiHad1", saghfBedehiHad1);
                    cmd.Parameters.AddWithValue("SaghfBedehiHad2", saghfBedehiHad2);
                    cmd.Parameters.AddWithValue("SaghfBedehiSaghf1", saghfBedehiSaghf1);
                    cmd.Parameters.AddWithValue("SaghfBedehiSaghf2", saghfBedehiSaghf2);
                    cmd.Parameters.AddWithValue("SaghfBedehiMoredi1", saghfBedehiMoredi1);
                    cmd.Parameters.AddWithValue("SaghfBedehiMoredi2", saghfBedehiMoredi2);

                    cmd.Parameters.AddWithValue("JariBestankar1", jariBestankar1);
                    cmd.Parameters.AddWithValue("JariBestankar2", jariBestankar2);
                    cmd.Parameters.AddWithValue("JariMoadel1", jariMoadel1);
                    cmd.Parameters.AddWithValue("JariMoadel2", jariMoadel2);
                    cmd.Parameters.AddWithValue("KotahmodatBestankar1", kotahmodatBestankar1);
                    cmd.Parameters.AddWithValue("KotahmodatBestankar2", kotahmodatBestankar2);
                    cmd.Parameters.AddWithValue("KotahmodatMoadel1", kotahmodatMoadel1);
                    cmd.Parameters.AddWithValue("KotahmodatMoadel2", kotahmodatMoadel2);
                    cmd.Parameters.AddWithValue("GharzolhasanehBestankar1", gharzolhasanehBestankar1);
                    cmd.Parameters.AddWithValue("GharzolhasanehBestankar2", gharzolhasanehBestankar2);
                    cmd.Parameters.AddWithValue("GharzolhasanehMoadel1", gharzolhasanehMoadel1);
                    cmd.Parameters.AddWithValue("GharzolhasanehMoadel2", gharzolhasanehMoadel2);
                    cmd.Parameters.AddWithValue("Sepordeh", sepordeh);

                    cmd.Parameters.AddWithValue("JariOldMoadel", jariOldMoadel);
                    cmd.Parameters.AddWithValue("KotahmodatOldMoadel", kotahmodatOldMoadel);
                    cmd.Parameters.AddWithValue("GharzolhasanehOldMoadel", gharzolhasanehOldMoadel);

                    cmd.Parameters.AddWithValue("RotbehIranian", rotbehIranian);
                    cmd.Parameters.AddWithValue("TasviyehGharardad", tasviyehGharardad);

                    cmd.Parameters.AddWithValue("TasviyehTashilat", tasviyehTashilat);
                    cmd.Parameters.AddWithValue("TasviyehTaahodat", tasviyehTaahodat);
                    cmd.Parameters.AddWithValue("AfzayeshTashilat", afzayeshTashilat);
                    cmd.Parameters.AddWithValue("AfzayeshTaahodat", afzayeshTaahodat);
                    cmd.Parameters.AddWithValue("KaheshTashilat", kaheshTashilat);
                    cmd.Parameters.AddWithValue("KaheshTaahodat", kaheshTaahodat);
                    cmd.Parameters.AddWithValue("VarizTashilat", varizTashilat);
                    cmd.Parameters.AddWithValue("VarizTaahodat", varizTaahodat);

                    cmd.Parameters.AddWithValue("Ask1", ask1);
                    cmd.Parameters.AddWithValue("Ask2", ask2);
                    cmd.Parameters.AddWithValue("Ask3", ask3);
                    cmd.Parameters.AddWithValue("Ask4", ask4);
                    cmd.Parameters.AddWithValue("Ask6", ask6);
                    cmd.Parameters.AddWithValue("Ask7", ask7);
                    cmd.Parameters.AddWithValue("Ask8", ask8);
                    cmd.Parameters.AddWithValue("Ask9", ask9);
                    cmd.Parameters.AddWithValue("Ask10", ask10);
                    cmd.Parameters.AddWithValue("Ask11", ask11);
                    cmd.Parameters.AddWithValue("Ask12", ask12);
                    cmd.Parameters.AddWithValue("Ask13", ask13);

                    cmd.Parameters.AddWithValue("SharayetAkharinMosavabeh", sharayetAkharinMosavabeh);
                    cmd.Parameters.AddWithValue("NazariyeKarshenas", nazariyeKarshenas);
                    cmd.Parameters.AddWithValue("XmlRequests", xmlRequests);
                    cmd.Parameters.AddWithValue("RequestsCount", requestsCount);

                    int queryResult = cmd.ExecuteNonQuery();
                    if (queryResult == 1)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "Select @@Identity";
                        string serial = cmd.ExecuteScalar().ToString();
                        objConn.Close();
                        return serial.ToString();
                    }
                }
            }
            catch
            {
                throw;
            }
            return string.Empty;
        }

        public static string Update(int referralDate, string id, int branchId, string customerId, string customerName, string personalityType, string modirAmel, string noeFaaliyat, string bakhshFaaliyat, string noeMojavezShoghli, string noeMalekiyat, string vazeyatSanad, string tarikhGozaresh, string tarikhEtelaatEtebari, double sarmayeSabti, string tarikhHesabrasi, string tarikhSoratMali, double mojodiKala, double foroshDarSoratMali, double soodYaZiyanJari, double soodYaZiyanAnbashteh, double bedehiKotahmodat, double bedehiBolandmodat, string nesbatJari, string nesbatMalekaneh, string tarikhTaraz, double foroshDarTaraz, double estelamMellat1, double estelamMellat2, double estelamSayer1, double estelamSayer2, double estelamZinaf1, double estelamZinaf2, double estelamZinaf3, double estelamZinaf4, double bedehiPishnehad1, double bedehiPishnehad2, double mosavabeDarrah1, double mosavabeDarrah2, double saghfBedehiHad1, double saghfBedehiHad2, double saghfBedehiSaghf1, double saghfBedehiSaghf2, double saghfBedehiMoredi1, double saghfBedehiMoredi2, double jariBestankar1, double jariBestankar2, double jariMoadel1, double jariMoadel2, double kotahmodatBestankar1, double kotahmodatBestankar2, double kotahmodatMoadel1, double kotahmodatMoadel2, double gharzolhasanehBestankar1, double gharzolhasanehBestankar2, double gharzolhasanehMoadel1, double gharzolhasanehMoadel2, double sepordeh, double jariOldMoadel, double kotahmodatOldMoadel, double gharzolhasanehOldMoadel, string rotbehIranian, double tasviyehGharardad, double tasviyehTashilat, double tasviyehTaahodat, double afzayeshTashilat, double afzayeshTaahodat, double kaheshTashilat, double kaheshTaahodat, double varizTashilat, double varizTaahodat, string ask1, string ask2, string ask3, string ask4, string ask6, string ask7, string ask8, string ask9, string ask10, string ask11, string ask12, string ask13, string sharayetAkharinMosavabeh, string nazariyeKarshenas, string xmlRequests, int requestsCount)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [ReviewReports] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [ReferralDate]=@ReferralDate, [BranchID]=@BranchID, [CustomerID]=@CustomerID, [CustomerName]=@CustomerName, [PersonalityType]=@PersonalityType, [ModirAmel]=@ModirAmel, [NoeFaaliyat]=@NoeFaaliyat, [BakhshFaaliyat]=@BakhshFaaliyat, [NoeMojavezShoghli]=@NoeMojavezShoghli, [NoeMalekiyat]=@NoeMalekiyat, [VazeyatSanad]=@VazeyatSanad, [TarikhGozaresh]=@TarikhGozaresh, [TarikhEtelaatEtebari]=@TarikhEtelaatEtebari, [SarmayeSabti]=@SarmayeSabti, [TarikhHesabrasi]=@TarikhHesabrasi, [TarikhSoratMali]=@TarikhSoratMali, [MojodiKala]=@MojodiKala, [ForoshDarSoratMali]=@ForoshDarSoratMali, [SoodYaZiyanJari]=@SoodYaZiyanJari, [SoodYaZiyanAnbashteh]=@SoodYaZiyanAnbashteh, [BedehiKotahmodat]=@BedehiKotahmodat, [BedehiBolandmodat]=@BedehiBolandmodat, [NesbatJari]=@NesbatJari, [NesbatMalekaneh]=@NesbatMalekaneh, [TarikhTaraz]=@TarikhTaraz, [ForoshDarTaraz]=@ForoshDarTaraz, [EstelamMellat1]=@EstelamMellat1, [EstelamMellat2]=@EstelamMellat2, [EstelamSayer1]=@EstelamSayer1, [EstelamSayer2]=@EstelamSayer2, [EstelamZinaf1]=@EstelamZinaf1, [EstelamZinaf2]=@EstelamZinaf2, [EstelamZinaf3]=@EstelamZinaf3, [EstelamZinaf4]=@EstelamZinaf4, [BedehiPishnehad1]=@BedehiPishnehad1, [BedehiPishnehad2]=@BedehiPishnehad2, [MosavabeDarrah1]=@MosavabeDarrah1, [MosavabeDarrah2]=@MosavabeDarrah2, [SaghfBedehiHad1]=@SaghfBedehiHad1, [SaghfBedehiHad2]=@SaghfBedehiHad2, [SaghfBedehiSaghf1]=@SaghfBedehiSaghf1, [SaghfBedehiSaghf2]=@SaghfBedehiSaghf2, [SaghfBedehiMoredi1]=@SaghfBedehiMoredi1, [SaghfBedehiMoredi2]=@SaghfBedehiMoredi2, [JariBestankar1]=@JariBestankar1, [JariBestankar2]=@JariBestankar2, [JariMoadel1]=@JariMoadel1, [JariMoadel2]=@JariMoadel2, [KotahmodatBestankar1]=@KotahmodatBestankar1, [KotahmodatBestankar2]=@KotahmodatBestankar2, [KotahmodatMoadel1]=@KotahmodatMoadel1, [KotahmodatMoadel2]=@KotahmodatMoadel2, [GharzolhasanehBestankar1]=@GharzolhasanehBestankar1, [GharzolhasanehBestankar2]=@GharzolhasanehBestankar2, [GharzolhasanehMoadel1]=@GharzolhasanehMoadel1, [GharzolhasanehMoadel2]=@GharzolhasanehMoadel2, [Sepordeh]=@Sepordeh, [JariOldMoadel]=@JariOldMoadel, [KotahmodatOldMoadel]=@KotahmodatOldMoadel, [GharzolhasanehOldMoadel]=@GharzolhasanehOldMoadel, [RotbehIranian]=@RotbehIranian, [TasviyehGharardad]=@TasviyehGharardad, [TasviyehTashilat]=@TasviyehTashilat, [TasviyehTaahodat]=@TasviyehTaahodat, [AfzayeshTashilat]=@AfzayeshTashilat, [AfzayeshTaahodat]=@AfzayeshTaahodat, [KaheshTashilat]=@KaheshTashilat, [KaheshTaahodat]=@KaheshTaahodat, [VarizTashilat]=@VarizTashilat, [VarizTaahodat]=@VarizTaahodat, [Ask1]=@Ask1, [Ask2]=@Ask2, [Ask3]=@Ask3, [Ask4]=@Ask4, [Ask6]=@Ask6, [Ask7]=@Ask7, [Ask8]=@Ask8, [Ask9]=@Ask9, [Ask10]=@Ask10, [Ask11]=@Ask11, [Ask12]=@Ask12, [Ask13]=@Ask13, [SharayetAkharinMosavabeh]=@SharayetAkharinMosavabeh, [NazariyeKarshenas]=@NazariyeKarshenas, [XmlRequests]=@XmlRequests WHERE ([ID]={0})", id);
                    cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                    cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());

                    cmd.Parameters.AddWithValue("ReferralDate", referralDate);
                    cmd.Parameters.AddWithValue("BranchID", branchId);
                    cmd.Parameters.AddWithValue("CustomerID", customerId);
                    cmd.Parameters.AddWithValue("CustomerName", customerName);
                    cmd.Parameters.AddWithValue("PersonalityType", personalityType);
                  
                    cmd.Parameters.AddWithValue("ModirAmel", modirAmel);
                    cmd.Parameters.AddWithValue("NoeFaaliyat", noeFaaliyat);
                    cmd.Parameters.AddWithValue("BakhshFaaliyat", bakhshFaaliyat);
                    cmd.Parameters.AddWithValue("NoeMojavezShoghli", noeMojavezShoghli);
                    cmd.Parameters.AddWithValue("NoeMalekiyat", noeMalekiyat);
                    cmd.Parameters.AddWithValue("VazeyatSanad", vazeyatSanad);
                    cmd.Parameters.AddWithValue("TarikhGozaresh", tarikhGozaresh);
                    cmd.Parameters.AddWithValue("TarikhEtelaatEtebari", tarikhEtelaatEtebari);
                    cmd.Parameters.AddWithValue("SarmayeSabti", sarmayeSabti);

                    cmd.Parameters.AddWithValue("TarikhHesabrasi", tarikhHesabrasi);
                    cmd.Parameters.AddWithValue("TarikhSoratMali", tarikhSoratMali);
                    cmd.Parameters.AddWithValue("MojodiKala", mojodiKala);
                    cmd.Parameters.AddWithValue("ForoshDarSoratMali", foroshDarSoratMali);
                    cmd.Parameters.AddWithValue("SoodYaZiyanJari", soodYaZiyanJari);
                    cmd.Parameters.AddWithValue("SoodYaZiyanAnbashteh", soodYaZiyanAnbashteh);
                    cmd.Parameters.AddWithValue("BedehiKotahmodat", bedehiKotahmodat);
                    cmd.Parameters.AddWithValue("BedehiBolandmodat", bedehiBolandmodat);
                    cmd.Parameters.AddWithValue("NesbatJari", nesbatJari);
                    cmd.Parameters.AddWithValue("NesbatMalekaneh", nesbatMalekaneh);
                    cmd.Parameters.AddWithValue("TarikhTaraz", tarikhTaraz);
                    cmd.Parameters.AddWithValue("ForoshDarTaraz", foroshDarTaraz);

                    cmd.Parameters.AddWithValue("EstelamMellat1", estelamMellat1);
                    cmd.Parameters.AddWithValue("EstelamMellat2", estelamMellat2);
                    cmd.Parameters.AddWithValue("EstelamSayer1", estelamSayer1);
                    cmd.Parameters.AddWithValue("EstelamSayer2", estelamSayer2);
                    cmd.Parameters.AddWithValue("EstelamZinaf1", estelamZinaf1);
                    cmd.Parameters.AddWithValue("EstelamZinaf2", estelamZinaf2);
                    cmd.Parameters.AddWithValue("EstelamZinaf3", estelamZinaf3);
                    cmd.Parameters.AddWithValue("EstelamZinaf4", estelamZinaf4);
                    cmd.Parameters.AddWithValue("BedehiPishnehad1", bedehiPishnehad1);
                    cmd.Parameters.AddWithValue("BedehiPishnehad2", bedehiPishnehad2);
                    cmd.Parameters.AddWithValue("MosavabeDarrah1", mosavabeDarrah1);
                    cmd.Parameters.AddWithValue("MosavabeDarrah2", mosavabeDarrah2);
                    cmd.Parameters.AddWithValue("SaghfBedehiHad1", saghfBedehiHad1);
                    cmd.Parameters.AddWithValue("SaghfBedehiHad2", saghfBedehiHad2);
                    cmd.Parameters.AddWithValue("SaghfBedehiSaghf1", saghfBedehiSaghf1);
                    cmd.Parameters.AddWithValue("SaghfBedehiSaghf2", saghfBedehiSaghf2);
                    cmd.Parameters.AddWithValue("SaghfBedehiMoredi1", saghfBedehiMoredi1);
                    cmd.Parameters.AddWithValue("SaghfBedehiMoredi2", saghfBedehiMoredi2);

                    cmd.Parameters.AddWithValue("JariBestankar1", jariBestankar1);
                    cmd.Parameters.AddWithValue("JariBestankar2", jariBestankar2);
                    cmd.Parameters.AddWithValue("JariMoadel1", jariMoadel1);
                    cmd.Parameters.AddWithValue("JariMoadel2", jariMoadel2);
                    cmd.Parameters.AddWithValue("KotahmodatBestankar1", kotahmodatBestankar1);
                    cmd.Parameters.AddWithValue("KotahmodatBestankar2", kotahmodatBestankar2);
                    cmd.Parameters.AddWithValue("KotahmodatMoadel1", kotahmodatMoadel1);
                    cmd.Parameters.AddWithValue("KotahmodatMoadel2", kotahmodatMoadel2);
                    cmd.Parameters.AddWithValue("GharzolhasanehBestankar1", gharzolhasanehBestankar1);
                    cmd.Parameters.AddWithValue("GharzolhasanehBestankar2", gharzolhasanehBestankar2);
                    cmd.Parameters.AddWithValue("GharzolhasanehMoadel1", gharzolhasanehMoadel1);
                    cmd.Parameters.AddWithValue("GharzolhasanehMoadel2", gharzolhasanehMoadel2);
                    cmd.Parameters.AddWithValue("Sepordeh", sepordeh);

                    cmd.Parameters.AddWithValue("JariOldMoadel", jariOldMoadel);
                    cmd.Parameters.AddWithValue("KotahmodatOldMoadel", kotahmodatOldMoadel);
                    cmd.Parameters.AddWithValue("GharzolhasanehOldMoadel", gharzolhasanehOldMoadel);

                    cmd.Parameters.AddWithValue("RotbehIranian", rotbehIranian);
                    cmd.Parameters.AddWithValue("TasviyehGharardad", tasviyehGharardad);

                    cmd.Parameters.AddWithValue("TasviyehTashilat", tasviyehTashilat);
                    cmd.Parameters.AddWithValue("TasviyehTaahodat", tasviyehTaahodat);
                    cmd.Parameters.AddWithValue("AfzayeshTashilat", afzayeshTashilat);
                    cmd.Parameters.AddWithValue("AfzayeshTaahodat", afzayeshTaahodat);
                    cmd.Parameters.AddWithValue("KaheshTashilat", kaheshTashilat);
                    cmd.Parameters.AddWithValue("KaheshTaahodat", kaheshTaahodat);
                    cmd.Parameters.AddWithValue("VarizTashilat", varizTashilat);
                    cmd.Parameters.AddWithValue("VarizTaahodat", varizTaahodat);

                    cmd.Parameters.AddWithValue("Ask1", ask1);
                    cmd.Parameters.AddWithValue("Ask2", ask2);
                    cmd.Parameters.AddWithValue("Ask3", ask3);
                    cmd.Parameters.AddWithValue("Ask4", ask4);
                    cmd.Parameters.AddWithValue("Ask6", ask6);
                    cmd.Parameters.AddWithValue("Ask7", ask7);
                    cmd.Parameters.AddWithValue("Ask8", ask8);
                    cmd.Parameters.AddWithValue("Ask9", ask9);
                    cmd.Parameters.AddWithValue("Ask10", ask10);
                    cmd.Parameters.AddWithValue("Ask11", ask11);
                    cmd.Parameters.AddWithValue("Ask12", ask12);
                    cmd.Parameters.AddWithValue("Ask13", ask13);

                    cmd.Parameters.AddWithValue("SharayetAkharinMosavabe", sharayetAkharinMosavabeh);
                    cmd.Parameters.AddWithValue("NazariyeKarshenas", nazariyeKarshenas);
                    cmd.Parameters.AddWithValue("XmlRequests", xmlRequests);
                    cmd.Parameters.AddWithValue("RequestsCount", requestsCount);
                    int queryResult = cmd.ExecuteNonQuery();
                    if (queryResult == 1)
                    {
                        objConn.Close();
                        return id;
                    }
                }
            }
            catch
            {
                throw;
            }
            return string.Empty;
        }

        public static bool UpdateExpertId(string[] ids, int newUserId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    foreach (string id in ids)
                    {
                        OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                        cmd.Connection = objConn;
                        cmd.CommandText = string.Format("UPDATE [ReviewReports] SET [ModifierUserID]=@ModifierUserID, [ModifiedDate]=@ModifiedDate, [ModifiedTime]=@ModifiedTime, [FromUserID]=@FromUserID, [ToUserID]=@ToUserID, [ReferralDate]=@ReferralDate, [DateEnd]=@DateEnd WHERE ([ID]={0})", id);
                        cmd.Parameters.AddWithValue("ModifierUserID", Users.MyUserID);
                        cmd.Parameters.AddWithValue("ModifiedDate", Network.GetNowDateSerial());
                        cmd.Parameters.AddWithValue("ModifiedTime", Network.GetNowTimeString());
                        cmd.Parameters.AddWithValue("FromUserID", Users.MyUserID);
                        cmd.Parameters.AddWithValue("ToUserID", newUserId);
                        cmd.Parameters.AddWithValue("ReferralDate", Network.GetNowDateSerial());
                        cmd.Parameters.AddWithValue("DateEnd", DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                    objConn.Close();
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }
        public static bool UpdateExpertId(string id, int newUserId)
        {
            return UpdateExpertId(new string[] { id }, newUserId);
        }

        public static bool UpdateReviewNo(string serial, long reviewNo)
        {
            try
            {
                string tableName = serial.Substring(0, 4);
                string rowId = serial.Substring(4);
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [{0}] SET [RequestStatus]=@RequestStatus, [ReviewNo]=@ReviewNo WHERE ([ID]={1})", tableName, rowId);
                    cmd.Parameters.AddWithValue("RequestStatus", RequestStatus.Barasi);
                    cmd.Parameters.AddWithValue("ReviewNo", reviewNo);

                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool DeleteReviewNo(string serial)
        {
            try
            {
                string tableName = serial.Substring(0, 4);
                string rowId = serial.Substring(4);
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [{0}] SET [ReviewNo]=@ReviewNo WHERE ([ID]={1})", tableName, rowId);
                    cmd.Parameters.AddWithValue("ReviewNo", DBNull.Value);

                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool DeleteExpertNo(string serial)
        {
            try
            {
                string tableName = serial.Substring(0, 4);
                string rowId = serial.Substring(4);
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [{0}] SET [ExpertNo]=@ExpertNo WHERE ([ID]={1})", tableName, rowId);
                    cmd.Parameters.AddWithValue("ExpertNo", DBNull.Value);

                    int queryResult = cmd.ExecuteNonQuery();
                    objConn.Close();
                    if (queryResult == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool UpdateDateEnd(string id, int referralDate, int? dateEnd)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("UPDATE [ReviewReports] SET ToUserID=@ToUserID, [ReferralDate]=@ReferralDate, [DateEnd]=@DateEnd WHERE ([ID]={0})", id);
                    cmd.Parameters.AddWithValue("ToUserID", Users.MyUserID);
                    cmd.Parameters.AddWithValue("ReferralDate", referralDate);
                    if (dateEnd.HasValue)
                        cmd.Parameters.AddWithValue("DateEnd", Network.GetNowDateSerial());
                    else
                        cmd.Parameters.AddWithValue("DateEnd", DBNull.Value);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    foreach (string tblName in RequestManager.GetTablesName())
                    {
                        cmd.CommandText = string.Format("UPDATE [{0}] SET [ExpertID]=@ExpertID, [ReferralDate]=@ReferralDate, [DateEnd]=@DateEnd WHERE ([ReviewNo]={1})", tblName, id);
                        cmd.Parameters.AddWithValue("ExpertID", Users.MyUserID);
                        cmd.Parameters.AddWithValue("ReferralDate", referralDate);
                        if (dateEnd.HasValue)
                            cmd.Parameters.AddWithValue("DateEnd", Network.GetNowDateSerial());
                        else
                            cmd.Parameters.AddWithValue("DateEnd", DBNull.Value);
                     cmd.ExecuteNonQuery();
                    }
                    objConn.Close();
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        public static DataTable GetReviewReportByNo(string reviewNo)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = string.Format("SELECT * FROM [ReviewReports] WHERE ([ID]={0})", reviewNo);
                    var dataReader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    objConn.Close();
                    return dataTable;
                }
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetReviewReports(int? userId, string requestStatus)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();

                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;

                    if (userId.HasValue)
                    {
                        if (requestStatus == "پرونده های جاری")
                            cmd.CommandText = "SELECT ID, RegisteredDate, ModifiedDate, ModifiedTime, ToUserID, ReferralDate, BranchID, CustomerName, RequestsCount, XmlRequests, DateEnd FROM [ReviewReports] WHERE ([ToUserID]=@ToUserID) AND (([DateEnd] IS NULL) OR (LEN([DateEnd]) = 0))";
                        if (requestStatus == "پرونده های مختومه")
                            cmd.CommandText = "SELECT ID, RegisteredDate, ModifiedDate, ModifiedTime, ToUserID, ReferralDate, BranchID, CustomerName, RequestsCount, XmlRequests, DateEnd FROM [ReviewReports] WHERE ([ToUserID]=@ToUserID) AND LEN([DateEnd]) > 0";
                        if (requestStatus == "*")
                            cmd.CommandText = "SELECT ID, RegisteredDate, ModifiedDate, ModifiedTime, ToUserID, ReferralDate, BranchID, CustomerName, RequestsCount, XmlRequests, DateEnd FROM [ReviewReports] WHERE ([ToUserID]=@ToUserID)";
                        cmd.Parameters.AddWithValue("ToUserID", userId);
                    }
                    else
                    {
                        if (requestStatus == "پرونده های جاری")
                            cmd.CommandText = "SELECT ID, RegisteredDate, ModifiedDate, ModifiedTime, ToUserID, ReferralDate, BranchID, CustomerName, RequestsCount, DateEnd FROM [ReviewReports] WHERE ([DateEnd] IS NULL) OR (LEN([DateEnd]) = 0)";
                        if (requestStatus == "پرونده های مختومه")
                            cmd.CommandText = "SELECT ID, RegisteredDate, ModifiedDate, ModifiedTime, ToUserID, ReferralDate, BranchID, CustomerName, RequestsCount, DateEnd FROM [ReviewReports] WHERE LEN([DateEnd]) > 0";
                        if (requestStatus == "*")
                            cmd.CommandText = "SELECT ID, RegisteredDate, ModifiedDate, ModifiedTime, ToUserID, ReferralDate, BranchID, CustomerName, RequestsCount, DateEnd FROM [ReviewReports]";
                    }
                   

                    var dataReader = cmd.ExecuteReader();

                    //while (dataReader.HasRows)
                    //{
                    //    Console.WriteLine("\t{0}\t{1}", dataReader.GetName(0),
                    //        dataReader.GetName(1));

                    //    while (dataReader.Read())
                    //    {
                    //        Console.WriteLine("\t{0}\t{1}", dataReader.GetInt32(0),
                    //            dataReader.GetString(1));
                    //    }
                    //    dataReader.NextResult();
                    //}

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("BranchName");
                    dataTable.Columns.Add("ModifiedDateTime");
                    dataTable.Columns.Add("ReviewNo", typeof(int));
                    dataTable.Load(dataReader);

                    objConn.Close();

                    if (dataTable.Rows.Count > 0)
                    {
                        dataTable = dataTable.AsEnumerable().OrderByDescending(x => x["RegisteredDate"].ToString()).CopyToDataTable();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                            row["BranchID"] = br.BranchId;
                            row["BranchName"] = br.BranchName;
                            row["ModifiedDateTime"] = PersianDate.Parse(row["ModifiedDate"].ToString()).ToStandard() + " - " + row["ModifiedTime"].ToString();
                            row["ReviewNo"] = ChkSum.GetFull(row["ID"].ToString());
                        }
                    }
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

        public static DataTable GetReviewReportsByCustomerId(string customerId)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable dataTable = new DataTable();
                    cmd.CommandText = string.Format("SELECT * FROM [ReviewReports] WHERE ([CustomerID]={0}) ORDER BY [ModifiedDate] DESC", customerId);
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    objConn.Close();
                    return dataTable;
                }
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetRequestsByReviewNo(ulong reviewNo)
        {
            try
            {
                string docId = Textual.RemoveFromLast(reviewNo.ToString(), 2);
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    DataTable masterTable = new DataTable();
                    foreach (string tblName in RequestManager.GetTablesName())
                    {
                        cmd.CommandText = string.Format("SELECT TOP 1 [ID] FROM [{0}] WHERE ([ReviewNo]={1})", tblName, docId);
                        if (cmd.ExecuteScalar() != null)
                        {
                            cmd.CommandText = string.Format("SELECT {0} AS TableName, TableName & [ID] AS RequestSerial, * FROM [{0}] WHERE ([ReviewNo]={1})", tblName, docId);
                            var dataReader = cmd.ExecuteReader();
                            DataTable dataTable = new DataTable();
                            dataTable.Load(dataReader);
                            masterTable.Merge(dataTable);
                        }
                    }
                    objConn.Close();

                    if (masterTable.Rows.Count > 0)
                        masterTable = masterTable.AsEnumerable().OrderByDescending(x => x["ModifiedDate"]).ThenByDescending(x => x["ModifiedTime"]).CopyToDataTable();

                    masterTable.Columns.Add("ModifiedDateTime");
                    masterTable.Columns.Add("CustomerName2");
                    masterTable.Columns.Add("BranchName");
                    masterTable.Columns.Add("FacilityName");
                    masterTable.Columns.Add("ExpertName");

                    for (int i = 0; i < masterTable.Rows.Count; i++)
                    {
                        DataRow row = masterTable.Rows[i];
                        int modifiedDate = int.Parse(row["ModifiedDate"].ToString());
                        if (Network.GetNowDateSerial() == modifiedDate)
                            row["ModifiedDateTime"] = "امروز - " + row["ModifiedTime"].ToString();
                        else if (Network.GetNowPersianDate().AddDays(-1).ToSerial() == modifiedDate)
                            row["ModifiedDateTime"] = "دیروز - " + row["ModifiedTime"].ToString();
                        else
                            row["ModifiedDateTime"] = PersianDate.Parse(modifiedDate).ToStandard() + " - " + row["ModifiedTime"].ToString();

                        row["CustomerName2"] = row["CustomerName"].ToString().Replace("آ", "ا").Replace("ئ", "ی").Replace(" ", "");
                        row["FacilityName"] = Facilitys.GetFacilityNameById(row["FacilityID"].ToString());
                        row["ExpertName"] = Users.GetUserNameById(Numeral.AnyToInt32(row["ExpertID"]));
                        Branches.BranchInfo br = Branches.GetBranchById(row["BranchID"].ToString(), true);
                        row["BranchID"] = br.BranchId;
                        row["BranchName"] = br.BranchName;
                    }
                    return masterTable;
                }
            }
            catch
            {
                throw;
            }
        }

        public static DataTable RRRR()
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(OLEDB.GetDatabase("DB_Requests.mdb")))
                {
                    objConn.Open();
                    OleDbCommand cmd = new OleDbCommand() { CommandType = CommandType.Text };
                    cmd.Connection = objConn;
                    cmd.CommandText = "SELECT * FROM [ReviewReports]";
                    var dataReader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(dataReader);
                    foreach (DataRow r in dataTable.Rows)
                    {
                        OleDbCommand cmd2 = new OleDbCommand() { CommandType = CommandType.Text };
                        cmd2.Connection = objConn;

                        string xml = r["XmlRequests"].ToString();
                        DataTable tbl = UDF.GetXmlToDatatable(xml);
                        DataColumn c = tbl.Columns.Add("FacilityID");
                        c.SetOrdinal(5);

                        foreach (DataRow row in  tbl.Rows)
                        {
                            row["FacilityID"] = Facilitys.GetFacilityIdByName(row["FacilityName"].ToString());
                        }

                        string xml2 = UDF.ConvertDatatableToXML(tbl, "Request");
                       
                        string ii =  string.Format("UPDATE [ReviewReports] SET [XmlRequests]='{0}' WHERE ([ID]={1})", xml2, r["ID"].ToString());;
                        cmd2.CommandText = ii;

                        cmd2.ExecuteNonQuery();
                    }
                    objConn.Close();

                    return dataTable;
                }
            }
            catch
            {
                return null;
            }
        }

    
    }
}
