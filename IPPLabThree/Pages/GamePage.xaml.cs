using IPPLabThree.Servers;
using IPPLabThree.Views;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IPPLabThree.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private GamePageView gamePageView;
        public GamePage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            gamePageView = new GamePageView(player);
            AcceptMessagesAsync();
        }
        private async Task AcceptMessagesAsync()
        {
            await Task.Run(() =>
            {
                ServerController serverController = new ServerController(gamePageView);
                TcpListener serverListener = null;

                try
                {
                    serverListener = new TcpListener(serverController.IpAddress, serverController.Port);
                    serverListener.Start();

                    while (true)
                    {
                        try
                        {
                            serverController.HandleMessage(serverListener);
                        }
                        catch (WebException exc) { }
                    }
                }
                catch (WebException exc)
                {
                    serverListener.Stop();
                }
            });
        }
    }
}