using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using secondTrial.Helpers;
using System.Diagnostics;
using System.Windows.Controls;


namespace secondTrial.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand LoginCommand { get; set; }


        //public MainViewModel(Border Stage)
        public MainViewModel()
        {
            LoginCommand = new RelayCommand(DoLogin);
        }

        public MainViewModel(Border Stage)
        {
            LoginCommand = new RelayCommand(DoLogin);
        }

        private void DoLogin(object obj)
        {
            Trace.WriteLine("text");
            //AuthVM.Authenticate();
        }

    }
}
