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
        private bool _IsAuthenticated;


        //public MainViewModel(Border Stage)
        public MainViewModel()
        {
            LoginCommand = new RelayCommand(DoLogin);
        }

        public MainViewModel(Border Stage)
        {
            LoginCommand = new RelayCommand(DoLogin);
        }

        public bool IsAuthenticated
        {
            get { return _IsAuthenticated; }
            set
            {
                if (value != _IsAuthenticated)
                {
                    _IsAuthenticated = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("IsNotAuthenticated");
                    //RaisePropertyChanged("IsAuthenticated");
                    //RaisePropertyChanged("IsNotAuthenticated");
                }
            }
        }
        public bool IsNotAuthenticated
        {
            get
            {
                return !IsAuthenticated;
            }
        }

        private void DoLogin(object obj)
        {
            IsAuthenticated = true;
            Trace.WriteLine("text");
            //AuthVM.Authenticate();
        }

    }
}
