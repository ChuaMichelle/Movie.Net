using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Movie.Net.ViewModel
{
    public class HelpersViewModel
    {
        public static Window GetCurrentFocusedWindow()
        {
            Window window = null;

            Control currentControl = System.Windows.Input.Keyboard.FocusedElement as Control;

            if (currentControl != null)
                window = Window.GetWindow(currentControl);

            return window;
        }
    }
}
