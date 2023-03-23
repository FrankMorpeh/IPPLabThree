using System.Windows;
using System.Windows.Controls;

namespace IPPLabThree.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private Frame frame;
        public MainPage(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
        }
        private void Pads_Clicked(object sender, RoutedEventArgs e)
        {
            frame.Content = new ControllerPage();
        }
        private void Player_Clicked(object sender, RoutedEventArgs e)
        {
            frame.Content = new GamePage();
        }
    }
}