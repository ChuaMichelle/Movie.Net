using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Movie.Net
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Name = "Hello MVVM!";
            MyCommand = new RelayCommand(MycommandExecute, MyCommandCanExecute);
        }

        public string _name;

        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand MyCommand { get; }

        void MycommandExecute()
        {
            Name = "Hello click!";
        }

        bool MyCommandCanExecute()
        {
            return Name != "Hello click!";
        }

    }
}
