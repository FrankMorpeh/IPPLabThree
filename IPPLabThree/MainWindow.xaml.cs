using IPPLabThree.Pages;
using System.Windows;

namespace IPPLabThree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frame.Content = new MainPage(frame);
        }
    }
}