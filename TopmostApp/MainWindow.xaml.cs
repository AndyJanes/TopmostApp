using System.Diagnostics;
using System.Windows;
using TopmostApp.Interop;
using TopmostApp.Views;
using static TopmostApp.Interop.NativeMethods;

namespace TopmostApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FlyoutWindow OnScreenFlyoutWindow { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnScreenFlyoutWindow = new FlyoutWindow
            {
                Activatable = false,
                Content = new FlyoutView(),
                ZBandID = GetZBandID()
            };

            OnScreenFlyoutWindow.CreateWindow();
            OnScreenFlyoutWindow.Show();
        }

        private ZBandID GetZBandID()
        {
            var zbid = ZBandID.Default;

            using (var proc = Process.GetCurrentProcess())
            {
                var isImmersive = IsImmersiveProcess(proc.Handle);
                var hasUiAccess = HasUiAccessProcess(proc.Handle);

                zbid = isImmersive ? ZBandID.AboveLockUX : hasUiAccess ? ZBandID.UIAccess : ZBandID.Desktop;
            }

            return zbid;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OnScreenFlyoutWindow.Content = new SecondView();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (OnScreenFlyoutWindow.IsVisible)
            {
                OnScreenFlyoutWindow.Hide();
            }
            else
            {
                OnScreenFlyoutWindow.Show();
            }
        }
    }
}
