﻿using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace TopmostApp.Behaviors
{
    public class DragFlyoutBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var flyoutWindow = FlyoutWindow.GetFlyoutWindow(AssociatedObject);
            if (flyoutWindow != null)
            {
                flyoutWindow.DragMove();
            }
        }
    }
}
