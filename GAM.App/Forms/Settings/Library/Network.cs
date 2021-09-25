using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAM.Forms.Settings.Library
{
    public class Network
    {
        public static IPAddress GetThisPCIPv4()
        {
            try
            {
                List<IPAddress> IPv4Addresses = new List<IPAddress>();
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface adapter in nics)
                {
                    if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback
                        || adapter.OperationalStatus != OperationalStatus.Up)
                    {
                        continue;
                    }
                    // Only get informatin for interfaces that support IPv4.
                    if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                    {
                        IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                        foreach (UnicastIPAddressInformation ipAddress in adapterProperties.UnicastAddresses)
                        {
                            if (ipAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                IPv4Addresses.Add(ipAddress.Address);
                            }
                        }
                    }
                }

                return IPv4Addresses.First();
            }
            catch
            {
                throw new Exception("لطفا اتصالات شبکه خود را کنترل نمایید");
            }
        }

        public static string GetMachineName()
        {
            return Environment.MachineName;
        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }


        public static string GetNowDateTimeString()
        {
            DateTime nowDateTime = DateTime.Now;
            bool isDaylight = TimeZoneInfo.Local.IsDaylightSavingTime(nowDateTime);
            if (isDaylight)
            {
                return new PersianDate(nowDateTime).ToString("S");
            }
            else
            {
                return new PersianDate(nowDateTime.AddHours(1)).ToString("S");
            }
        }

        public static string GetNowTimeString()
        {
            DateTime nowDateTime = DateTime.Now;
            bool isDaylight = TimeZoneInfo.Local.IsDaylightSavingTime(nowDateTime);
            if (isDaylight)
            {
                return nowDateTime.ToString("HH:mm");
            }
            else
            {
                return nowDateTime.AddHours(1).ToString("HH:mm");
            }
        }

        public static string GetNowDateFormat()
        {
            DateTime nowDateTime = DateTime.Now;
            return new PersianDate(nowDateTime).ToStandard();
        }

        public static int GetNowDateSerial()
        {
            DateTime nowDateTime = DateTime.Now;
            return new PersianDate(nowDateTime).ToSerial();
        }

        public static PersianDate GetNowPersianDate()
        {
            DateTime nowDateTime = DateTime.Now;
            return new PersianDate(nowDateTime);
        }

        public static bool IsAdmin()
        {
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                return true;
            else
                return false;
        }
    }


    public class NoServerFoundException : System.Exception
    {
        public NoServerFoundException() : base() { }
        public NoServerFoundException(string message) : base(message) { }
        public NoServerFoundException(string message,
            System.Exception inner)
            : base(message, inner) { }
        protected NoServerFoundException(SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) { }
    }

    public class NTP
    {
        private const int requestTimeout = 500;
        private const int timesForEachServer = 5;
        private const byte offTime = 40; //Transmit Time (see RFC-2030)
        private static uint lastSrv;

        //NIST Servers
        public static string[] servers = {"001-020-026-202.krz.mellat.bm",
                                          "www.time.bm" 
                                         };
        private static IPAddress getServer()
        {
            lastSrv = (uint)((lastSrv + 1) % servers.Length);
            IPAddress[] address = Dns.GetHostEntry(servers[lastSrv]).AddressList;
            if (address == null || address.Length == 0)
                throw new NoServerFoundException("no ip found");
            return address[0];
        }

        public static DateTime GetDateTime() { return GetDateTime(false); }
        public static DateTime GetDateTime(bool utc)
        {
            //Examine all servers until we find a server that responds
            for (int st = 0; st < servers.Length * timesForEachServer; st++)
            {
                try
                {
                    IPAddress ip = getServer();
                    IPEndPoint ipEndP = new IPEndPoint(ip, 123);

                    Socket sk = new Socket(AddressFamily.InterNetwork,
                                SocketType.Dgram,
                                ProtocolType.Udp);
                    sk.ReceiveTimeout = requestTimeout;

                    sk.Connect(ipEndP);

                    byte[] data = new byte[48];
                    data[0] = 0x23;
                    for (int i = 1; i < 48; i++) data[i] = 0;
                    sk.Send(data);

                    sk.Receive(data);
                    byte[] integerPart = new byte[4];
                    integerPart[0] = data[offTime + 3];
                    integerPart[1] = data[offTime + 2];
                    integerPart[2] = data[offTime + 1];
                    integerPart[3] = data[offTime + 0];
                    byte[] fractPart = new byte[4];
                    fractPart[0] = data[offTime + 7];
                    fractPart[1] = data[offTime + 6];
                    fractPart[2] = data[offTime + 5];
                    fractPart[3] = data[offTime + 4];
                    long ms = (long)(
                          (ulong)BitConverter.ToUInt32(integerPart, 0) * 1000
                         + ((ulong)BitConverter.ToUInt32(fractPart, 0) * 1000)
                          / 0x100000000L);
                    sk.Close();

                    /* DateTime*/
                    DateTime date = new DateTime(1900, 1, 1);
                    date += TimeSpan.FromTicks(ms * TimeSpan.TicksPerMillisecond);

                    return utc ? date : date.ToLocalTime();

                }
                catch { }
            }

            return utc ? DateTime.Now : DateTime.Now.ToLocalTime();
        }
    }

}
