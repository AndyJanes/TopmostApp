using System.Windows;

namespace TopmostApp
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FlyoutHandler.Instance = new FlyoutHandler();
            FlyoutHandler.Instance.Initialize();
        }
    }
}
