﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace Demo2022.Common
{
    public class WindowBehavior : Behavior<Window>
    {
        public static readonly DependencyProperty CloseProperty =
            DependencyProperty.Register("Close", typeof(bool),
                typeof(WindowBehavior), new PropertyMetadata(false, OnCloseChanged));

        private static void OnCloseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = ((WindowBehavior)d).AssociatedObject;
            var newValue = (bool)e.NewValue;
            if (newValue)
            {
                window.Close();
            }
        }

        // <summary>
        /// 关闭窗口
        /// </summary>
        public bool Close
        {
            get { return (bool)GetValue(CloseProperty); }
            set { SetValue(CloseProperty, value); }
        }
    }
}
