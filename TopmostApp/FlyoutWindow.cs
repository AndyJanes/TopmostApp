using System.Windows;
using TopmostApp.Interop;

namespace TopmostApp
{
    public class FlyoutWindow : BandWindow
    {
        static FlyoutWindow()
        {
            ContentProperty.OverrideMetadata(typeof(BandWindow), new FrameworkPropertyMetadata(OnContentPropertyChanged));
        }

        private static void OnContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FlyoutWindow flyoutWindow)
            {
                if (e.OldValue is FrameworkElement oldContent)
                {
                    SetFlyoutWindow(oldContent, null);
                }
                if (e.NewValue is FrameworkElement newContent)
                {
                    SetFlyoutWindow(newContent, flyoutWindow);
                }
            }
        }

        public static readonly DependencyProperty FlyoutWindowProperty =
            DependencyProperty.RegisterAttached(
            "FlyoutWindow",
            typeof(FlyoutWindow),
            typeof(FlyoutWindow),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        public static FlyoutWindow GetFlyoutWindow(DependencyObject obj)
        {
            return (FlyoutWindow)obj?.GetValue(FlyoutWindowProperty);
        }

        public static void SetFlyoutWindow(DependencyObject obj, FlyoutWindow flyoutWindow)
        {
            obj?.SetValue(FlyoutWindowProperty, flyoutWindow);
        }
    }
}
