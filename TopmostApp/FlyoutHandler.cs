using System.Diagnostics;
using TopmostApp.Interop;
using static TopmostApp.Interop.NativeMethods;

namespace TopmostApp
{
    public class FlyoutHandler
    {
        public static FlyoutHandler Instance { get; set; }

        public FlyoutWindow OnScreenFlyoutWindow { get; set; }

        public FlyoutView OnScreenFlyoutView { get; set; }

        public void Initialize()
        {
            CreateOnScreenFlyoutWindow();

            CreateWndProc();
            OnScreenFlyoutWindow.Show();
        }

        private void CreateOnScreenFlyoutWindow()
        {
            OnScreenFlyoutView = new();

            var zbid = ZBandID.Default;

            using (var proc = Process.GetCurrentProcess())
            {
                var isImmersive = IsImmersiveProcess(proc.Handle);
                var hasUiAccess = HasUiAccessProcess(proc.Handle);

                zbid = isImmersive ? ZBandID.AboveLockUX : hasUiAccess ? ZBandID.UIAccess : ZBandID.Desktop;
            }

            var flyoutWindow = new FlyoutWindow()
            {
                Activatable = false,
                Content = OnScreenFlyoutView,
                ZBandID = zbid
            };

            OnScreenFlyoutWindow = flyoutWindow;
        }

        private void CreateWndProc()
        {
            OnScreenFlyoutWindow.CreateWindow();
        }
    }
}
