using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.CommandWpf;

namespace Movie.Net.ViewModel
{
    public class HelpersViewModel
    {
        private AuthenticationViewModel AuthVM { get; set; }

        public HelpersViewModel()
        {
            //Movies = new ObservableCollection<Movies>(ctx.Movies.ToList());
            AuthVM = new AuthenticationViewModel();
        }

        public static Window GetCurrentFocusedWindow()
        {
            Window window = null;

            Control currentControl = System.Windows.Input.Keyboard.FocusedElement as Control;

            if (currentControl != null)
            {
                window = Window.GetWindow(currentControl);
            }

            return window;
        }

        public void LogoutAndExitExecute()
        {
            AuthVM.LogOff();
            GetCurrentFocusedWindow().Close();
            GetCurrentFocusedWindow().Close();
        }
    }
}
