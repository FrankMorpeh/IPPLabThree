using IPPLabThree.Models;
using IPPLabThree.Serializers;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace IPPLabThree.Pages
{
    /// <summary>
    /// Interaction logic for ControllerPage.xaml
    /// </summary>
    public partial class ControllerPage : Page
    {
        public ControllerPage()
        {
            InitializeComponent();
        }
        private void SendMessageToServer(ArrowType arrowType)
        {
            try
            {
                string serializedUserMessage = UserMessageSerializer.SerializeUserMessage(new UserMessage(arrowType));

                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect("26.122.240.185", 8080);

                NetworkStream networkStream = tcpClient.GetStream();
                byte[] buffer = Encoding.UTF8.GetBytes(serializedUserMessage);
                networkStream.Write(buffer, 0, buffer.Length);

                networkStream.Close();
                tcpClient.Close();
            }
            catch (System.Exception) { }
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            SendMessageToServer(ArrowType.ArrowLeft);
        }
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            SendMessageToServer(ArrowType.ArrowUp);
        }
        private void Right_Click(object sender, RoutedEventArgs e)
        {
            SendMessageToServer(ArrowType.ArrowRight);
        }
        private void Down_Click(object sender, RoutedEventArgs e)
        {
            SendMessageToServer(ArrowType.ArrowDown);
        }
    }
}