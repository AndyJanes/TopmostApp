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
        public FlyoutWindow FlyoutWindow { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateTopmostWindowButton_Click(object sender, RoutedEventArgs e)
        {
            FlyoutWindow = new FlyoutWindow
            {
                Activatable = false,
                Content = new FlyoutView(),
                ZBandID = GetZBandID()
            };

            FlyoutWindow.CreateWindow();
            FlyoutWindow.Show();
        }

        private ZBandID GetZBandID()
        {
            var zbid = ZBandID.Default;

            using var proc = Process.GetCurrentProcess();

            var isImmersive = IsImmersiveProcess(proc.Handle);
            var hasUiAccess = HasUiAccessProcess(proc.Handle);

            zbid = isImmersive ? ZBandID.AboveLockUX : hasUiAccess ? ZBandID.UIAccess : ZBandID.Desktop;

            return zbid;
        }

        private void ChangeContentButton_Click(object sender, RoutedEventArgs e)
        {
            if (FlyoutWindow is null)
                return;

            FlyoutWindow.Content = FlyoutWindow.Content is FlyoutView ? new SecondView() : (object)new FlyoutView();
        }

        private void ChangeVisibilityButton_Click(object sender, RoutedEventArgs e)
        {
            if (FlyoutWindow is null)
                return;

            if (FlyoutWindow.IsVisible)
            {
                FlyoutWindow.Hide();
            }
            else
            {
                FlyoutWindow.Show();
            }
        }
    }
}
