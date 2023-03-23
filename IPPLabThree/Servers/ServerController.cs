using IPPLabThree.Models;
using IPPLabThree.Serializers;
using IPPLabThree.Views;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace IPPLabThree.Servers
{
    public class ServerController
    {
        private IPAddress itsIpAddress;
        private int itsPort;
        private event Action<ArrowType> itsPlayerChangedEvent;

        public IPAddress IpAddress { get { return itsIpAddress; } }
        public int Port { get { return itsPort; } }

        public ServerController(GamePageView gamePageView)
        {
            itsIpAddress = IpDefiner.DefineIp();
            itsPort = 8080;
            itsPlayerChangedEvent += gamePageView.ChangePositionOfPlayer;
        }
        public void HandleMessage(TcpListener serverListener)
        {
            TcpClient tcpClient = serverListener.AcceptTcpClient();
            NetworkStream clientStream = tcpClient.GetStream();
            string serializedUserMessage = ReadBytes(clientStream);
            UserMessage userMessage = UserMessageSerializer.DeserializeUserMessage(serializedUserMessage);
            itsPlayerChangedEvent(userMessage.ArrowType);
        }
        private string ReadBytes(NetworkStream clientStream)
        {
            StringBuilder messageFromClientSb = new StringBuilder();
            int size = 0;
            byte[] buffer = new byte[6000000];
            do
            {
                size = clientStream.Read(buffer, 0, buffer.Length);
                messageFromClientSb.Append(Encoding.UTF8.GetString(buffer, 0, size));
            } while (clientStream.DataAvailable);

            return messageFromClientSb.ToString();
        }
    }
}