using System.Net;

namespace IPPLabThree.Servers
{
    public static class IpDefiner
    {
        public static IPAddress DefineIp()
        {
            IPAddress foundIPAddress = null;
            IPHostEntry iPHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress address in iPHostEntry.AddressList)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    foundIPAddress = address;
                    break;
                }
            }
            return foundIPAddress;
        }
    }
}